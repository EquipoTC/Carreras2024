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
	internal class DeviceHandler
	{
		public static List<DeviceModel> list = new List<DeviceModel>();
		public static DeviceModel current = new DeviceModel();

		public static async Task<List<DeviceModel>> CreateDeviceListAsync()
		{
			try
			{
				string response = await APIRequests.GetHttp("disp", APIRequests.apiUrl);
				JObject json = JObject.Parse(response);
				list = JsonConvert.DeserializeObject<List<DeviceModel>>(json["data"].ToString());
				if (list == null)
				{
					throw new Exception("La lista es nula");
				}
				return list;
			}
			catch
			{
				list = null;
				throw;
			}
		}
		public static List<string> GetDeviceDescriptions()
		{
			List<string> descList = new List<string>();
			if (list == null)
			{
				return descList;
			}
			foreach (var desc in list)
			{
				descList.Add(desc.Description);
			}
			return descList;
		}
		public static LatLng GetCurrentDevicePosition()
		{
			return new LatLng(current.Current_Latitude, current.Current_Longitude);
		}
		public static DeviceInfoModel GetCurrentDeviceInformation()
		{
			return current.Information[current.Information.Count - 1];
		}

		public static string GetCurrentDevicePositionMessage()
		{
			return current.Description + "\n Latitud:" + current.Current_Latitude + "\n Longitud:" + current.Current_Longitude;
		}
	}
}
