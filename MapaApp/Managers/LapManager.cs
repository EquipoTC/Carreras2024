using Mapa.Handlers;
using Mapa.Models;
using Mapa.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mapa.Managers
{
	public class LapManager : ILapService
	{
		public List<LapModel> lapList { get; }
		private LapHandler lapHandler { get; }
		public LapManager(LapHandler handler) 
		{
			lapList = new List<LapModel>();
			this.lapHandler = handler;
		}
		public void InsertLap(LapModel model)
		{
			lapList.Insert(0, model);
			Task.Run(() => lapHandler.PostHandler(model));
		}
		public string GetLapMessage(LapModel lap)
		{
			return $"Vuelta {lap.Id + 1}: + {lap.ElapsedTime.ToString(@"hh\:mm\:ss\:fff")} / Cronometro: {lap.TotalTime.ToString(@"hh\:mm\:ss\:fff")}";
		}
	}
}
