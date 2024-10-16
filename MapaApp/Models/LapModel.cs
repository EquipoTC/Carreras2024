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
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("dispID")]
		public int DeviceId { get; set; }

		[JsonProperty("tiempo")]
		public TimeSpan ElapsedTime { get; set; }

		[JsonProperty("tiempoCronometro")]
		public TimeSpan TotalTime = TimeSpan.Zero;

		public LapModel(int aId, int aDeviceId, TimeSpan aElapsedTime)
		{
			Id = aId;
			DeviceId = aDeviceId;
			ElapsedTime = aElapsedTime;
		}
	}
}
