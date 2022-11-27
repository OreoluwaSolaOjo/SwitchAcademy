namespace SwitchAcademy
{
    public static class SetUpMiddlewarePipeline
    {
        public static WebApplication SetUpMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwitchAcademyAPI v1"));
            app.UseCors(
                options => options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
            );
            app.UseHttpsRedirection();

            app.UseRouting();
            //dbInit.Initialize();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /* endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
                 {
                     Predicate = (check) => check.Tags.Contains("ready"),
                     ResponseWriter = async (context, report) =>
                     {
                         var result = JsonSerializer.Serialize(
                             new
                             {
                                 status = report.Status.ToString(),
                                 checks = report.Entries.Select(entry => new
                                 {
                                     name = entry.Key,
                                     status = entry.Value.Status.ToString(),
                                     exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                                     duration = entry.Value.Duration.ToString()
                                 })
                             }
                         );

                         context.Response.ContentType = MediaTypeNames.Application.Json;
                         await context.Response.WriteAsync(result);
                     }
                 });

                 endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
                 {
                     Predicate = (_) => false
                 });*/
            });

            return app;
        }
    }
}
