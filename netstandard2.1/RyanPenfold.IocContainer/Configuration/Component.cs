namespace RyanPenfold.IocContainer.Configuration
{
    public class Component : IComponent
    {
        public string InstanceScope { get; set; }
        public string Service { get; set; }
        public string Type { get; set; }
    }
}
