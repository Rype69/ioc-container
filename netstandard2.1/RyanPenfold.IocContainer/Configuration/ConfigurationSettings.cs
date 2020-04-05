using System.Collections.Generic;

namespace RyanPenfold.IocContainer.Configuration
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        public List<Component> Components { get; set; }
    }
}
