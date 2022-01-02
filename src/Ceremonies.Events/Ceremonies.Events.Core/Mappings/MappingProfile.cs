namespace Ceremonies.Events.Core.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var methodInfo = type.GetMethod("Mapping")
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                    ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                methodInfo?.Invoke(instance, new object[] { this });

            }
        }
    }
}
