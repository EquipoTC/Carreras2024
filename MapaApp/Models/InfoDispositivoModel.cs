using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Models
{
	internal class InfoDispositivoModel
	{
		[JsonProperty("info_id")]
		public int Id { get; set; }

		[JsonProperty("info_disp_id")]
		public string Disp_Id { get; set; }

		[JsonProperty("info_latitud")]
		public double Latitud { get; set; }

		[JsonProperty("info_longitud")]
		public double Longitud { get; set; }

		[JsonProperty("info_fecha_ingreso")]
		public DateTime Fecha_Ingreso { get; set; }

		[JsonProperty("info_corriente")]
		public double Corriente { get; set; }

		[JsonProperty("info_tension")]
		public double Tension { get; set; }

		[JsonProperty("info_energia")]
		public double Energia { get; set; }

		[JsonProperty("info_potencia")]
		public double Potencia { get; set; }

		[JsonProperty("info_velocidad")]
		public double Velocidad { get; set; }
	}
}
