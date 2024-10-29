using Mapa.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mapa.Services
{
	public interface ILapService
	{
		void InsertLap(LapModel lap);
		string GetLapMessage(LapModel lap);
		Task<List<LapModel>> GetLapsByDeviceId(int deviceId);
	}
}
