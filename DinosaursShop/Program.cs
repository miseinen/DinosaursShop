namespace DinosaursShop
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Represents entrypoint methods.
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Entrypoint of application.
        /// </summary>
        /// <param name="args">Command line argument.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create a host builder.
        /// </summary>
        /// <param name="args">Command line argument.</param>
        /// <returns>Host builder.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
