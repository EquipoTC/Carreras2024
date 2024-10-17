using System;
using System.Windows.Forms;
using System.Collections.Generic;

//Dependencias
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DispositivoManager;
using Mapa.Models;
using Mapa.Services;
using Mapa.Managers;

namespace Mapa
{
    internal class GoogleMapControl : MapControl
    {
        GMapControl control;
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        GMapOverlay rutaOverlay;

		IDeviceService deviceManager;
		IDeviceInfoService deviceInfoManager;

		public GoogleMapControl(GMapControl map_control, IDeviceService deviceManager, IDeviceInfoService deviceInfoManager)
        {
            control = map_control;
			this.deviceManager = deviceManager;
			this.deviceInfoManager = deviceInfoManager;
            rutaOverlay = new GMapOverlay("Ruta");
            Setup_Map();
            Setup_Marker();
        }


        public PointLatLng PointConvert(LatLng point) 
        {
            return new PointLatLng(point.lat, point.lng);
        }

        public void Overlays_Tick()
        {
            control.Overlays.Clear();
            control.Overlays.Add(markerOverlay);
            control.Overlays.Add(rutaOverlay);
            Draw_Route_of_Dispositivo(deviceManager.current, 5);
            Set_Marker_on_Current();
            
        }

        public void Setup_Map()
        {
            control.DragButton = MouseButtons.Left;
            control.CanDragMap = false;
            control.MapProvider = GMapProviders.GoogleMap;
            control.Position = PointConvert(deviceManager.GetCurrentDevicePosition());
            control.MinZoom = 1;
            control.MaxZoom = 18;
            control.Zoom = 16;
            control.MouseWheelZoomEnabled = false;
            control.AutoScroll = true;
        }

        public void Setup_Marker()
        {
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker);
        }

        public void Set_Marker_on_Current()
        {
            marker.ToolTipMode = MarkerTooltipMode.Always;
			marker.ToolTipText = deviceManager.GetCurrentDevicePositionMessage();
            marker.Position = PointConvert(deviceManager.GetCurrentDevicePosition());
            Console.WriteLine("Posición:" + deviceManager.GetCurrentDevicePosition());
        }

        public void Set_Map_Position(LatLng point)
        {
            control.Position = PointConvert(point);
        }

        public void Set_Map_Zoom(double zoom)
        {
            control.Zoom = zoom;
        }

        public void Toggle_Movement()
        {
            control.MouseWheelZoomEnabled = !control.MouseWheelZoomEnabled;
            control.CanDragMap = !control.CanDragMap;
        }

        public double Calculate_Distance(LatLng point1, LatLng point2)
        {
            return 0;
        }

        public double Calculate_Velocity_of_Dispositivo(DeviceModel device, int end = 1)
        {
            if (device.Information.Count < 2)
            {
                return 0;
            }
            double totalDistance = 0;
            double totalTime = 0;
            for (int i = device.Information.Count - 1; i > 0; i--)
            {
                PointLatLng point1 = PointConvert(deviceInfoManager.GetDevicePastPositionsbyId(deviceManager.current, i));
                PointLatLng point2 = PointConvert(deviceInfoManager.GetDevicePastPositionsbyId(deviceManager.current, i - 1));
                totalDistance += GMapProviders.EmptyProvider.Projection.GetDistance(point1, point2); // KM
                totalTime += (device.Information[i].EntryDate - device.Information[i - 1].EntryDate).TotalHours;
                if (i == (device.Information.Count - end))
                {
                    break;
                }
            }
            if (totalTime == 0)
            {
                return 0;
            }
            return totalDistance / totalTime;
        }
        public void Draw_Route_of_Dispositivo(DeviceModel device, int end = 1)
        {
            rutaOverlay.Routes.Clear();
            if (device.Information.Count < 2)
            {
                return;
            }
            List<PointLatLng> points = new List<PointLatLng>();
            for (int i = device.Information.Count - 1; i > 0; i--)
            {
				points.Add(PointConvert(deviceInfoManager.GetDevicePastPositionsbyId(deviceManager.current, i)));
                if (i == (device.Information.Count - end))
                {
                    break;
                }
            }
            GMapRoute routePoints = new GMapRoute(points, "Ruta");
            rutaOverlay.Routes.Add(routePoints);
        }
    }
}
