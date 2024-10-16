using Mapa.Handlers;
using Mapa.Managers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Services
{
	public class ServicesRegistry
	{
		public static void RegisterServices(IServiceCollection services)
		{
			services.AddSingleton<LapHandler>();
			services.AddSingleton<ILapService, LapManager>();
		}
	}
}
