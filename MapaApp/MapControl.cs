using DispositivoManager;

namespace Mapa
{
    internal class LatLng
    {
        public double lat = 0.0;

        public double lng = 0.0;
        public LatLng(double a_lat, double a_lng)
        {
            lat = a_lat;
            lng = a_lng;
        }
        public override string ToString()
        {
            return "(Lat:" + lat + ", Lng:" + lng + ")";
        }
    }
    interface MapControl
    {
        void Setup_Map();
        void Setup_Marker();
        void Set_Marker_on_Current();
        void Set_Map_Position(LatLng point);
        void Set_Map_Zoom(double zoom);
        void Toggle_Movement();
        double Calculate_Distance(LatLng point1, LatLng point2);
        void Draw_Route_of_Dispositivo(DispositivoModel disp, int end = 1);
        double Calculate_Velocity_of_Dispositivo(DispositivoModel disp, int end = 1);
    }
}
