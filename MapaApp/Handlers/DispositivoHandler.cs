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
	internal class DispositivoHandler
	{
		public static List<DispositivoModel> list = new List<DispositivoModel>();

		public static async Task<List<DispositivoModel>> Create_List()
		{
			try
			{
				string respuesta = await APIRequests.GetHttp("disp", APIRequests.api_url);
				JObject json = JObject.Parse(respuesta);
				list = JsonConvert.DeserializeObject<List<DispositivoModel>>(json["data"].ToString());
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
		public static List<string> Get_Descriptions()
		{
			List<string> desc_list = new List<string>();
			if (list == null)
			{
				return desc_list;
			}
			foreach (var desc in list)
			{
				desc_list.Add(desc.Descripcion);
			}
			return desc_list;
		}
	}
}
