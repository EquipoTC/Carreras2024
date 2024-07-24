using System;
using System.Windows.Forms;
using System.Collections.Generic;

//Dependencias
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DispositivoManager;

namespace Mapa
{
    internal class GoogleMapControl : MapControl
    {
        GMapControl control;
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        GMapOverlay rutaOverlay;

        public GoogleMapControl(GMapControl map_control)
        {
            control = map_control;
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
            Draw_Route_of_Dispositivo(Dispositivos.current, 5);
            Set_Marker_on_Current();
            
        }

        public void Setup_Map()
        {
            control.DragButton = MouseButtons.Left;
            control.CanDragMap = false;
            control.MapProvider = GMapProviders.GoogleMap;
            control.Position = PointConvert(Dispositivos.current.Get_Current_Position());
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
            marker.ToolTipText = Dispositivos.current.Get_Position_Message();
            marker.Position = PointConvert(Dispositivos.current.Get_Current_Position());
            Console.WriteLine("Posición:" + Dispositivos.current.Get_Current_Position());
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

        public double Calculate_Velocity_of_Dispositivo(DispositivoModel disp, int end = 1)
        {
            if (disp.Information.Count < 2)
            {
                return 0;
            }
            double totalDistance = 0;
            double totalTime = 0;
            for (int i = disp.Information.Count - 1; i > 0; i--)
            {
                PointLatLng point1 = PointConvert(disp.Get_Position_by_Id(i));
                PointLatLng point2 = PointConvert(disp.Get_Position_by_Id(i - 1));
                totalDistance += GMapProviders.EmptyProvider.Projection.GetDistance(point1, point2); // KM
                totalTime += (disp.Information[i].Fecha_Ingreso - disp.Information[i - 1].Fecha_Ingreso).TotalHours;
                if (i == (disp.Information.Count - end))
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
        public void Draw_Route_of_Dispositivo(DispositivoModel disp, int end = 1)
        {
            rutaOverlay.Routes.Clear();
            if (disp.Information.Count < 2)
            {
                return;
            }
            List<PointLatLng> puntos = new List<PointLatLng>();
            for (int i = disp.Information.Count - 1; i > 0; i--)
            {
                puntos.Add(PointConvert(disp.Get_Position_by_Id(i)));
                if (i == (disp.Information.Count - end))
                {
                    break;
                }
            }
            GMapRoute rutaPuntos = new GMapRoute(puntos, "Ruta");
            rutaOverlay.Routes.Add(rutaPuntos);
        }
    }
}
