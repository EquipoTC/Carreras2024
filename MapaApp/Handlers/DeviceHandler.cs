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
	public class DeviceHandler
	{
		public async Task<List<DeviceModel>> GetHandler()
		{
			try
			{
				string response = await APIRequests.GetHttp("disp", APIRequests.apiUrl);
				JObject json = JObject.Parse(response);
				List<DeviceModel> list = JsonConvert.DeserializeObject<List<DeviceModel>>(json["data"].ToString());
				if (list == null)
				{
					throw new Exception("La lista es nula");
				}
				return list;
			}
			catch
			{
				throw;
			}
		}
	}
}
