using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Models
{
	public class DeviceInfoModel
	{
		[JsonProperty("info_id")]
		public int Id { get; set; }

		[JsonProperty("info_disp_id")]
		public string DeviceId { get; set; }

		[JsonProperty("info_latitud")]
		public double Latitude { get; set; }

		[JsonProperty("info_longitud")]
		public double Longitude { get; set; }

		[JsonProperty("info_fecha_ingreso")]
		public DateTime EntryDate { get; set; }

		[JsonProperty("info_corriente")]
		public double Current { get; set; }

		[JsonProperty("info_tension")]
		public double Voltage { get; set; }

		[JsonProperty("info_energia")]
		public double Energy { get; set; }

		[JsonProperty("info_potencia")]
		public double Power { get; set; }

		[JsonProperty("info_velocidad")]
		public double Speed { get; set; }
	}
}
