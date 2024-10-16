using API;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapa.Models;

namespace Mapa.Handlers
{
	public class DeviceInfoHandler
	{
		public async Task<List<DeviceInfoModel>> GetByIdHandler(int deviceId)
		{
			try
			{
				string response = await APIRequests.GetHttp("info/" + deviceId, APIRequests.apiUrl);
				JObject json = JObject.Parse(response);
				List<DeviceInfoModel> infoDevice = JsonConvert.DeserializeObject<List<DeviceInfoModel>>(json["data"].ToString());
				if (infoDevice == null)
				{
					throw new Exception("La informacion es nula");
				}
				return infoDevice;
			}
			catch
			{
				throw;
			}
		}
	}
}
