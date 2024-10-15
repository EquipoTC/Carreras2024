using API;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Models
{
	internal class DeviceModel
	{
		[JsonProperty("disp_id")]
		public int Id { get; set; }

		[JsonProperty("disp_descripcion")]
		public string Description { get; set; }

		[JsonProperty("disp_latitud_actual")]
		public double Current_Latitude { get; set; }

		[JsonProperty("disp_longitud_actual")]
		public double Current_Longitude { get; set; }

		[JsonProperty("disp_fecha_ingreso")]
		public DateTime Entry_Date { get; set; }

		[JsonProperty("disp_fecha_modificacion")]
		public DateTime? Modification_Date { get; set; }

		[JsonProperty("disp_habilitado")]
		public bool Enabled { get; set; }

		public List<DeviceInfoModel> Information = new List<DeviceInfoModel>();
	}
}
