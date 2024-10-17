using Mapa.Handlers;
using Mapa.Models;
using Mapa.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Managers
{
	public class DeviceInfoManager : IDeviceInfoService
	{
		private readonly DeviceInfoHandler deviceInfoHandler;
		public DeviceInfoManager(DeviceInfoHandler deviceInfoHandler)
		{
			this.deviceInfoHandler = deviceInfoHandler;
		}

		public async Task<List<DeviceInfoModel>> UpdateInfoByDeviceId(int deviceId)
		{
			return await deviceInfoHandler.GetByIdHandler(deviceId);
		}
		public DeviceInfoModel GetDeviceLastInformation(DeviceModel device)
		{
			return device.Information == null || device.Information.Count == 0 ? null : device.Information[device.Information.Count - 1];
		}

		public LatLng GetDevicePastPositionsbyId(DeviceModel device, int id)
		{
			return new LatLng(device.Information[id].Latitude, device.Information[id].Longitude);
		}
	}
}
