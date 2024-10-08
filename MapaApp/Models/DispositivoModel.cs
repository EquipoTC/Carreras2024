using API;
using DispositivoManager;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Models
{
	internal class DispositivoModel
	{
		[JsonProperty("disp_id")]
		public int Id { get; set; }

		[JsonProperty("disp_descripcion")]
		public string Descripcion { get; set; }

		[JsonProperty("disp_latitud_actual")]
		public double Latitud_Actual { get; set; }

		[JsonProperty("disp_longitud_actual")]
		public double Longitud_Actual { get; set; }

		[JsonProperty("disp_fecha_ingreso")]
		public DateTime Fecha_Ingreso { get; set; }

		[JsonProperty("disp_fecha_modificacion")]
		public DateTime? Fecha_Modificacion { get; set; }

		[JsonProperty("disp_habilitado")]
		public bool Habilitado { get; set; }

		public List<InformationModel> Information = new List<InformationModel>();
	}
}
