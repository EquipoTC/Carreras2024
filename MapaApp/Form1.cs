using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

// Dependencias
using DispositivoManager;

namespace Mapa
{
    public partial class Form1 : Form
    {
        //API o Dependencia que se usa
        GoogleMapControl map;

        Stopwatch cronometro = new Stopwatch();
        List<LapInfo> lapList = new List<LapInfo>();
        public Form1()
        {
            InitializeComponent();
            map = new GoogleMapControl(gmapControl);
            map.Set_Map_Zoom(trackZoom.Value);
            Dispositivos.Create_List();
            Fill_Dispositivo_Box();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            await Dispositivos.current.Update_Information();
            if(Dispositivos.current.Information == null)
            {
                Console.WriteLine("La información del dispositivo " + Dispositivos.current.Descripcion + " es nula!");
                return;
            }
            Search_Selected_Dispositivo();
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
            LatLng dispositivo_position = Dispositivos.current.Get_Current_Position();
            map.Set_Marker_on_Current();
            // Texts
            txtLatitud.Text = dispositivo_position.lat.ToString();
            txtLongitud.Text = dispositivo_position.lng.ToString();
            txtVelGPS.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current) + " km/h.";
            txtVelGPSPromedio.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current, 5) + " km/h";
            // Pins
            if (!checkPinPos.Checked) { return; }
            map.Set_Map_Position(dispositivo_position);
        }

        private void Combo_Dispositivo_Changed(object sender, EventArgs e)
        {
            Dispositivos.current = Dispositivos.list[comboDisp.SelectedIndex];
            Search_Selected_Dispositivo();
        }

        private void checkPinPosition_Changed(object sender, EventArgs e)
        {
            map.Toggle_Movement();
            if (checkPinPos.Checked)
            {
                map.Set_Map_Position(Dispositivos.current.Get_Current_Position());
                map.Set_Map_Zoom(trackZoom.Value);
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
