using Mapa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Services
{
	public interface IDeviceService
	{
		List<DeviceModel> deviceList { get; }
		DeviceModel current { get; }
		Task<List<DeviceModel>> CreateDeviceList();
		List<string> GetDeviceDescriptions();
		LatLng GetCurrentDevicePosition();
		DeviceInfoModel GetCurrentDeviceInformation();
		string GetCurrentDevicePositionMessage();
	}
}
