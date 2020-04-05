using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RyanPenfold.Configuration;
using RyanPenfold.IocContainer.Configuration;

namespace RyanPenfold.IocContainer
{
    public class Resolver
    {
        private static ContainerBuilder _containerBuilder;

        private static IServiceCollection _serviceCollection;

        private static IServiceProvider _serviceProvider;

        public static ConfigurationSettings _configurationSettings;

        static Resolver()
        {
            var assemblyName = MethodBase.GetCurrentMethod()?.DeclaringType?.Assembly.GetName().Name;
            _configurationSettings = SettingsProvider<ConfigurationSettings>.GetSection(assemblyName);
        }

        /// <summary>
        /// Builds the IoC Container
        /// </summary>
        public static IServiceProvider BuildContainer(IServiceCollection services = null)
        {
            if (_serviceProvider != null)
            {
                return _serviceProvider;
            }

            if (services == null)
            {
                if (_serviceCollection == null)
                {
                    _serviceCollection = new ServiceCollection();
                }
            }

            _serviceCollection = services;

            // The Microsoft.Extensions.Logging package provides this one-liner
            // to add logging services.
            _serviceCollection.AddAutofac();

            if (_containerBuilder == null)
            {
                _containerBuilder = new ContainerBuilder();
            }

            // Once you've registered everything in the ServiceCollection, call
            // Populate to bring those registrations into Autofac. This is
            // just like a foreach over the list of things in the collection
            // to add them to Autofac.
            _containerBuilder.Populate(_serviceCollection);

            // Make your Autofac registrations. Order is important!
            // If you make them BEFORE you call Populate, then the
            // registrations in the ServiceCollection will override Autofac
            // registrations; if you make them AFTER Populate, the Autofac
            // registrations will override. You can make registrations
            // before or after Populate, however you choose.
            foreach (var component in _configurationSettings.Components)
            {
                if (component == null)
                {
                    continue;
                }

                Type serviceType = null;

                if (!string.IsNullOrWhiteSpace(component.Service))
                {
                    if (component.Service.Contains("[[") && component.Service.Contains("]]"))
                    {
                        serviceType = MakeGenericType(component.Service);
                    }
                    else
                    {
                        serviceType = Type.GetType(component.Service);
                    }
                }

                if (string.IsNullOrWhiteSpace(component.Type))
                {
                    throw new InvalidOperationException("Component.Type cannot be null, empty or whitespace.");
                }

                Type concreteType;
                if (component.Type.Contains("[[") && component.Type.Contains("]]"))
                {
                    concreteType = MakeGenericType(component.Type);
                }
                else
                {
                    concreteType = Type.GetType(component.Type);
                }

                if (concreteType == null)
                {
                    var segments = component.Type.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    var assemblyName = segments[1];
                    var assembly = Assembly.Load(assemblyName);
                    concreteType = assembly.GetType(segments[0]);
                }

                if (concreteType == null)
                {
                    throw new InvalidOperationException($"String \"{component.Type}\" cannot be resolved to a CLR type.");
                }

                var registrationBuilder = serviceType == null ? _containerBuilder.RegisterType(concreteType) : _containerBuilder.RegisterType(concreteType).As(serviceType);

                if (string.Equals(component.InstanceScope, "single-instance",
                    StringComparison.InvariantCultureIgnoreCase)) // TODO: Maybe use enumeration
                {
                    _serviceCollection.AddSingleton(serviceType == null ? concreteType : serviceType, concreteType);
                    registrationBuilder.SingleInstance();
                }
                else
                {
                    _serviceCollection.AddTransient(serviceType == null ? concreteType : serviceType, concreteType);
                }

            }

            // Creating a new AutofacServiceProvider makes the container
            // available to your app using the Microsoft IServiceProvider
            // interface so you can use those abstractions rather than
            // binding directly to Autofac.
            var container = _containerBuilder.Build();

            _serviceProvider = new AutofacServiceProvider(container);

            return _serviceProvider;
        }

        /// <remarks>
        /// Configuration convention: `1[[]]
        /// "Microsoft.AspNetCore.Identity.IUserStore`1[[RyanPenfold.IdentityTutorial.UI.Web.Models.ApplicationUser, RyanPenfold.IdentityTutorial.UI.Web]], Microsoft.AspNet.Identity.Core"
        /// </remarks>>
        private static Type MakeGenericType(string typeName)
        {
            Type result = null;
            var regexMatches = Regex.Matches(typeName, @"\[\[(.*?)\]\]");
            if (regexMatches.Count > 0 && regexMatches[0].Groups.Count > 1)
            {
                var nestedmostTypeName = regexMatches[0].Groups[1].ToString();
                var ttype = Type.GetType(nestedmostTypeName);
                var substringIndex = typeName.IndexOf(regexMatches[0].Groups[0].ToString(), StringComparison.InvariantCulture);
                var outermostTypeName = typeName.Remove(substringIndex, regexMatches[0].Groups[0].ToString().Length);
                var primaryType = Type.GetType(outermostTypeName);
                result = primaryType?.MakeGenericType(ttype);
            }

            return result;
        }

        /// <summary>
        /// Attempts to resolve an object instance from an inversion of control container.
        /// </summary>
        /// <typeparam name="T">The type of instance to resolve.</typeparam>
        /// <returns>An instance of type <see cref="T"/>.</returns>
        public static T Resolve<T>()
        {
            return ServiceProvider.GetService<T>();
        }

        /// <summary>
        /// Attempts to resolve an object instance from an inversion of control container.
        /// </summary>
        /// <param name="constructorParameters">
        /// The parameters to pass to the constructor
        /// </param>
        /// <typeparam name="T">
        /// The type of instance to resolve.
        /// </typeparam>
        /// <returns>
        /// An instance of type <see cref="T"/>.
        /// </returns>
        public static T Resolve<T>(IEnumerable<Parameter> constructorParameters)
        {
            throw new NotImplementedException();
        }

        /// <remarks>
        /// Get instances var instance = serviceProvider.GetService{Interface1}();
        /// </remarks>
        public static IServiceProvider ServiceProvider => _serviceProvider ?? (_serviceProvider = BuildContainer(new ServiceCollection()));
    }
}
