using Mapa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Services
{
	public interface IDeviceInfoService
	{
		Task<List<DeviceInfoModel>> UpdateInfoByDeviceId(int deviceId);
		DeviceInfoModel GetDeviceLastInformation(DeviceModel device);
		LatLng GetCurrentDevicePosition(DeviceModel device);
		LatLng GetDevicePastPositionsbyId(DeviceModel device, int id);
	}
}
