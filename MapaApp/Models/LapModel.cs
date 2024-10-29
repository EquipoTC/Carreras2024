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
	public class LapModel
	{
		[JsonProperty("vuelta_id")]
		public int Id { get; set; }

		[JsonProperty("vuelta_numero")]
		public int Number { get; set; }

		[JsonProperty("vuelta_dispId")]
		public int DeviceId { get; set; }

		[JsonProperty("vuelta_tiempo")]
		public TimeSpan ElapsedTime { get; set; }

		[JsonProperty("vuelta_tiempoCronometro")]
		public TimeSpan TotalTime = TimeSpan.Zero;

		public LapModel(int aNumber, int aDeviceId, TimeSpan aElapsedTime)
		{
			Number = aNumber;
			DeviceId = aDeviceId;
			ElapsedTime = aElapsedTime;
		}
	}
}
