using System;
using System.Windows.Forms;
using System.Timers;

// Dependencias
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DispositivoManager;
using System.Threading;

namespace Mapa
{
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        public Form1()
        {
            InitializeComponent();
            Dispositivos.Create_List();
            Setup_Map();
            Setup_Marker();
            Fill_Dispositivo_Box();
            // Creación Timer
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 2000; //1000 miliseconds = 1 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Dispositivos.current.Update_Information();
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Search_Selected_Dispositivo()));
            }
        }

        private void Setup_Map()
        {
            gmapControl.DragButton = MouseButtons.Left;
            gmapControl.CanDragMap = false;
            gmapControl.MapProvider = GMapProviders.GoogleMap;
            gmapControl.Position = Dispositivos.current.Get_Current_Position();
            gmapControl.MinZoom = 1;
            gmapControl.MaxZoom = 18;
            gmapControl.Zoom = 16;
            trackZoom.Value = (int)gmapControl.Zoom;
            gmapControl.MouseWheelZoomEnabled = false;
            gmapControl.AutoScroll = true;
        }

        private void Setup_Marker()
        {
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(0, 0), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker);
        }

        private void Set_Marker_Position_on_Current()
        {
            marker.ToolTipMode = MarkerTooltipMode.Always;
            marker.ToolTipText = Dispositivos.current.Get_Position_Message();
            marker.Position = Dispositivos.current.Get_Current_Position();
            Console.WriteLine("Posicion:" + Dispositivos.current.Get_Current_Position());
        }

        public void Fill_Dispositivo_Box()
        {
            foreach (string dispositivo_desc in Dispositivos.Get_Descripciones())
            {
                comboDisp.Items.Add(dispositivo_desc);
            }
            comboDisp.SelectedIndex = 0;
        }

        private void Search_Selected_Dispositivo()
        {
            PointLatLng dispositivo_position = Dispositivos.current.Get_Current_Position();
            Set_Marker_Position_on_Current();
            gmapControl.Overlays.Add(markerOverlay);
            // Texts
            txtLatitud.Text = dispositivo_position.Lat.ToString();
            txtLongitud.Text = dispositivo_position.Lng.ToString();
            labelVelGPS.Text = "Velocidad GPS: " + Dispositivos.current.Calculate_Velocity() + " km/h.\n" +
                "Velocidad GPS Promedio: " + Dispositivos.current.Calculate_Velocity(5) + " km/h";
            // Pins
            gmapControl.Position = checkPinPos.Checked ? dispositivo_position : gmapControl.Position;
        }

        private void Combo_Dispositivo_Changed(object sender, EventArgs e)
        {
            Dispositivos.current = Dispositivos.list[comboDisp.SelectedIndex];
            Search_Selected_Dispositivo();
        }

        private void checkPinPosition_Changed(object sender, EventArgs e)
        {
            if (checkPinPos.Checked)
            {
                gmapControl.Position = Dispositivos.current.Get_Current_Position();
                gmapControl.CanDragMap = false;
                gmapControl.MouseWheelZoomEnabled = false;
                gmapControl.Zoom = trackZoom.Value;
            }
            else
            {
                gmapControl.CanDragMap = true;
                gmapControl.MouseWheelZoomEnabled = true;
            }
        }

        private void zoomTrack_Changed(object sender, EventArgs e)
        {
            gmapControl.Zoom = trackZoom.Value;
        }
    }
}
