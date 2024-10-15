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
	internal class DeviceInfoHandler
	{
		public static async Task<List<DeviceInfoModel>> UpdateDeviceInfoByIdAsync(int deviceId)
		{
			try
			{
				string response = await APIRequests.GetHttp("info/" + deviceId, APIRequests.api_url);
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

		public static DeviceInfoModel GetDeviceLastInformation(DeviceModel device)
		{
			return device.Information[device.Information.Count - 1];
		}

		public static LatLng GetDevicePastPositionsbyId(DeviceModel device, int id)
		{
			return new LatLng(device.Information[id].Latitude, device.Information[id].Longitude);
		}
	}
}
