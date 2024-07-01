using System;
using System.Windows.Forms;
using System.Diagnostics;

// Dependencias
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using DispositivoManager;
using System.Threading;
using System.Collections.Generic;

namespace Mapa
{
    public partial class Form1 : Form
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        Stopwatch cronometro = new Stopwatch();
        List<LapInfo> lapList = new List<LapInfo>();
        public Form1()
        {
            Console.WriteLine("Funciona");
            InitializeComponent();
            Dispositivos.Create_List();
            Setup_Map();
            Setup_Marker();
            Fill_Dispositivo_Box();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Dispositivos.current.Update_Information();
            if (InvokeRequired && Dispositivos.current.Information != null)
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
            txtVelGPS.Text = Dispositivos.current.Calculate_Velocity() + " km/h.";
            txtVelGPSPromedio.Text = Dispositivos.current.Calculate_Velocity(5) + " km/h";
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

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (!cronometro.IsRunning)
            {
                cronometro.Start();
                CronometroTimer.Enabled = true;
                
                return;
            }
            cronometro.Stop();
        }

        private void lapBtn_Click(object sender, EventArgs e)
        {
            if (cronometro.ElapsedMilliseconds == 0)
            {
                return;
            }
            lapList.Insert(0, (new LapInfo(lapListBox.Items.Count, TimeSpan.Zero)));
            lapList[0].Total_Time = new TimeSpan(0, 0, 0, 0, (int)cronometro.ElapsedMilliseconds);
            lapList[0].Elapsed_Time = lapList[0].Total_Time;
            lapList[0].Elapsed_Time = lapList.Count == 1 ? lapList[0].Elapsed_Time : lapList[0].Elapsed_Time - lapList[1].Elapsed_Time;
            lapListBox.Items.Insert(0, lapList[0].ToString());
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, 0, (int)cronometro.ElapsedMilliseconds);
            cronometroTextBox.Text = time.ToString(@"hh\:mm\:ss\:fff");
        }
    }
}

internal class LapInfo
{
    public int Id { get; set; }
    public TimeSpan Elapsed_Time { get; set; }
    public TimeSpan Total_Time = TimeSpan.Zero;
    public LapInfo(int a_Id, TimeSpan a_Elapsed_Time)
    {
        Id = a_Id;
        Elapsed_Time = a_Elapsed_Time;
    }
    public override string ToString()
    {
        return $"Lap {Id+1}: + {Elapsed_Time.ToString(@"hh\:mm\:ss\:fff")} / {Total_Time.ToString(@"hh\:mm\:ss\:fff")}";
    }
}
