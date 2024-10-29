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
		private LapHandler lapHandler { get; }
		public LapManager(LapHandler handler) 
		{
			this.lapHandler = handler;
		}
		public void InsertLap(LapModel lap)
		{
			Task.Run(() => lapHandler.PostHandler(lap));
		}
		public async Task<List<LapModel>> GetLapsByDeviceId(int deviceId)
		{
			return await lapHandler.GetByIdHandler(deviceId);
		} 
		public string GetLapMessage(LapModel lap)
		{
			return $"Vuelta {lap.Id + 1}: + {lap.ElapsedTime.ToString(@"hh\:mm\:ss\:fff")} / Cronometro: {lap.TotalTime.ToString(@"hh\:mm\:ss\:fff")}";
		}
	}
}
