using API;
using Mapa.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Handlers
{
	internal class LapHandler
	{
		public async Task PostLap(LapModel lap)
		{
			try
			{
				JObject jsonObject = new JObject
			{
				{ "dispID", lap.DeviceId },
				{ "tiempo", lap.ElapsedTime.ToString(@"hh\:mm\:ss\.fff") },
				{ "tiempoCronometro", lap.TotalTime.ToString(@"hh\:mm\:ss\.fff") }
			};
				Console.WriteLine("Vuelta:" + jsonObject.ToString());
				await APIRequests.PostHttp("vuelta/ingresar", APIRequests.apiUrl, jsonObject.ToString());
			}
			catch (TimeoutException ex)
			{
				Console.WriteLine("La solicitud HTTP ha excedido el tiempo límite:" + ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error en la solicitud HTTP:" + ex.Message);
			}
		}
		public string GetLapMessage(LapModel lap)
		{
			return $"Vuelta {lap.Id + 1}: + {lap.ElapsedTime.ToString(@"hh\:mm\:ss\:fff")} / Cronometro: {lap.TotalTime.ToString(@"hh\:mm\:ss\:fff")}";
		}
	}
}
