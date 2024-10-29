using API;
using Mapa.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Handlers
{
	public class LapHandler
	{
		public async Task PostHandler(LapModel lap)
		{
			try
			{
				JObject jsonObject = new JObject
				{
					{ "numero", lap.Number},
					{ "tiempo", lap.ElapsedTime.ToString(@"hh\:mm\:ss\.fff") },
					{ "tiempoCronometro", lap.TotalTime.ToString(@"hh\:mm\:ss\.fff") }
				};
				await APIRequests.PostHttp("vuelta/ingresar", APIRequests.apiUrl, jsonObject.ToString());
			}
			catch
			{
				throw;
			}
		}
		public async Task<List<LapModel>> GetByIdHandler(int deviceId)
		{
			try
			{
				string response = await APIRequests.GetHttp("vuelta/" + deviceId, APIRequests.apiUrl);
				JObject json = JObject.Parse(response);
				List<LapModel> lapList = JsonConvert.DeserializeObject<List<LapModel>>(json["data"].ToString());
				if (lapList == null)
				{
					throw new Exception();
				}
				return lapList;
			}
			catch
			{
				return new List<LapModel>();
			}
		}
	}
}
