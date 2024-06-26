using System;
using System.Windows.Forms;
using System.Timers;

// Dependencias
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DispositivoManager;

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
            Setup_TrackZoom();
            Fill_Dispositivo_Box();
            // Creación Timer
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000; //1000 miliseconds = 1 seconds
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Dispositivos.current.Update_Information();
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Search_Selected_Dispositivo()));
            }
        }

        private void Setup_Map()
        {
            gmapControl.DragButton = MouseButtons.Left;
            gmapControl.CanDragMap = true;
            gmapControl.MapProvider = GMapProviders.GoogleMap;
            gmapControl.Position = Dispositivos.current.Get_Current_Position();
            gmapControl.MinZoom = 1;
            gmapControl.MaxZoom = 18;
            gmapControl.Zoom = 9;
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
            Console.WriteLine(Dispositivos.current.Get_Current_Position());
        }

        private void Setup_TrackZoom()
        {
            trackZoom.Minimum = gmapControl.MinZoom;
            trackZoom.Maximum = gmapControl.MaxZoom;
            TrackZoom_Value_Changed(this, EventArgs.Empty);
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
                "Velocidad GPS Promedio:" + Dispositivos.current.Calculate_Velocity(5) + " km/h";
            // Pins
            gmapControl.Position = checkPinPos.Checked ? dispositivo_position : gmapControl.Position;
            gmapControl.Zoom = checkPinZoom.Checked ? trackZoom.Value : gmapControl.Zoom;
        }

        private void Combo_Dispositivo_Changed(object sender, EventArgs e)
        {
            Dispositivos.current = Dispositivos.list[comboDisp.SelectedIndex];
            Search_Selected_Dispositivo();
        }

        private void TrackZoom_Value_Changed(object sender, EventArgs e)
        {
            if (!checkPinZoom.Checked)
            {
                gmapControl.MouseWheelZoomEnabled = true;
                return;
            }
            gmapControl.MouseWheelZoomEnabled = false;
            gmapControl.Zoom = trackZoom.Value;
        }

        private void checkPinPosition_Changed(object sender, EventArgs e)
        {
            if (checkPinPos.Checked)
            {
                gmapControl.Position = Dispositivos.current.Get_Current_Position();
                gmapControl.CanDragMap = false;
            }
            else
            {
                gmapControl.CanDragMap = true;
            }
        }
    }
}
