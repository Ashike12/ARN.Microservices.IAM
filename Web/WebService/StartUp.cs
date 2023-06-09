using ARN.Microservices.Infrastructure;

namespace ARN.Microservices.IAM
{
    public class StartUp
    {
        public StartUp(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private string _serviceName;

        public void ConfigureServices(IServiceCollection services)
        {
            _serviceName = Configuration.GetValue<string>("ServiceName");
            services.AddControllers();
            services.AddARNInfrastructureDependencies();
            //services.AddRabbitMQDependencies("Test");
            services.AddApiDocument(new ARNSwaggerOptions()
            {

            }, _serviceName);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{_serviceName} V1");
            });
        }
    }
}
