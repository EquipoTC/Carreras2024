using Mapa.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace Mapa
{
    internal static class Program
    {
		public static IServiceProvider ServiceProvider { get; private set; }
		[STAThread]
		static void Main()
		{
			ServiceCollection services = new ServiceCollection();
			ServicesRegistry.RegisterServices(services);
			services.AddTransient<Form1>();
			ServiceProvider = services.BuildServiceProvider();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(ServiceProvider.GetRequiredService<Form1>());

		}
    }
}
