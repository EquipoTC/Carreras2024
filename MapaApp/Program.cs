using Mapa.Managers;
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
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
			ServiceCollection services = new ServiceCollection();
			services.AddSingleton<ILapService, LapManager>();
			ServiceProvider = services.BuildServiceProvider();

		}
    }
}
