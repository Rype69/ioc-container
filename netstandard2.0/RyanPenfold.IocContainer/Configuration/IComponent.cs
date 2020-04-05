namespace RyanPenfold.IocContainer.Configuration
{
    public interface IComponent
    {
        string InstanceScope { get; set; }
        string Service { get; set; }
        string Type { get; set; }
    }
}