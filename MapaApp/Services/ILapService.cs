using Mapa.Models;
using System.Collections.Generic;

namespace Mapa.Services
{
	public interface ILapService
	{
		List<LapModel> lapList { get; }
		void InsertLap(LapModel lap);
		string GetLapMessage(LapModel lap);
	}
}
