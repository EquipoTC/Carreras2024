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
	public class DeviceManager : IDeviceService
	{
		public List<DeviceModel> deviceList { get; private set; }
		public DeviceModel current { get; private set; }
		private readonly DeviceHandler deviceHandler;
		public DeviceManager(DeviceHandler deviceHandler)
		{
			this.deviceList = new List<DeviceModel>();
			this.current = new DeviceModel();
			this.deviceHandler = deviceHandler;
		}

		public async Task<List<DeviceModel>> UpdateDeviceList()
		{
			deviceList = await deviceHandler.GetHandler();
			return deviceList;
		}

		public void ChangeCurrentDevice(int toDeviceId)
		{
			current = deviceList[toDeviceId];
		}

		public List<string> GetDeviceDescriptions()
		{
			List<string> descList = new List<string>();
			if (deviceList == null)
			{
				return descList;
			}
			foreach (var desc in deviceList)
			{
				descList.Add(desc.Description);
			}
			return descList;
		}

		public LatLng GetCurrentDevicePosition()
		{
			return new LatLng(current.CurrentLatitude, current.CurrentLongitude);
		}

		public DeviceInfoModel GetCurrentDeviceInformation()
		{
			return current.Information[current.Information.Count - 1];
		}

		public string GetCurrentDevicePositionMessage()
		{
			return current.Description + "\n Latitud:" + current.CurrentLatitude + "\n Longitud:" + current.CurrentLongitude;
		}
	}
}
