using GMap.NET.WindowsForms;
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
			RegisterHandlers(services);
			RegisterManagers(services);
		}
		public static void RegisterHandlers(IServiceCollection services)
		{
			services.AddSingleton<LapHandler>();
			services.AddSingleton<DeviceHandler>();
			services.AddSingleton<GMapControl>();
		}
		public static void RegisterManagers(IServiceCollection services)
		{
			services.AddSingleton<ILapService, LapManager>();
			services.AddSingleton<IDeviceService, DeviceManager>();
			services.AddSingleton<IMapService, GoogleMapManager>();
		}
	}
}
