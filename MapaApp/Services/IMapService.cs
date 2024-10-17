using Mapa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa.Services
{
	public interface IMapService
	{
		void OverlaysTick();
		void SetupMap();
		void SetupMarker();
		void SetMarkeronCurrentDevice();
		void SetMapPosition(LatLng point);
		void SetMapZoom(double zoom);
		void ToggleMovement();
		double CalculateDistance(LatLng point1, LatLng point2);
		void DrawRouteofDevice(DeviceModel disp, int end = 1);
		double CalculateVelocityofDevice(DeviceModel disp, int end = 1);
	}
}
