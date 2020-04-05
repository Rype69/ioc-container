using System.Collections.Generic;

namespace RyanPenfold.IocContainer.Configuration
{
    public interface IConfigurationSettings
    {
        List<Component> Components { get; set; }
    }
}