namespace BlazorserverApp.Data.Mapping
{
    public static class MappingExtension
    {
        public  static IServiceCollection AddDtoToModelMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClientModelProfile));
            services.AddAutoMapper(typeof(SlotModelProfile));
            return services;
        }
    }
}
