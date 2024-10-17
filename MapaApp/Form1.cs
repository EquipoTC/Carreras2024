using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

// Dependencias
using DispositivoManager;
using API;
using System.IO;
using Mapa.Models;
using Mapa.Services;

namespace Mapa
{
    public partial class Form1 : Form
    {
		//API o Dependencia que se usa
		private readonly ILapService lapManager;
		private readonly IDeviceService deviceManager;
		private readonly IDeviceInfoService deviceInfoManager;
		GoogleMapControl map;

        Stopwatch stopwatch = new Stopwatch();

        public Form1(ILapService lapManager, IDeviceService deviceManager, IDeviceInfoService deviceInfoManager)
        {
			this.lapManager = lapManager;
			this.deviceManager = deviceManager;
			this.deviceInfoManager = deviceInfoManager;
			InitializeComponent();
            Start_Program();
        }

        private async void Start_Program()
        {
            map = new GoogleMapControl(gmapControl);
            map.Set_Map_Zoom(trackZoom.Value);
            Set_App_Config();
            await Task.Delay(500);
            btnActualizar_Click(this, EventArgs.Empty);
			MessageBox.Show("Cargado con exito.");
            await Task.Run(() => Cronometro_Tick());
        }

        private void Set_App_Config()
        {
            Create_Config_File();
            string[] lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "Config", "config.txt"));
            Action[] settings = new Action[]
            {
                () => API.APIRequests.apiUrl = lines[0].Remove(0, lines[0].IndexOf(':')+1),
				() => API.APIRequests.timeoutResponseSeconds = double.Parse(lines[1].Remove(0, lines[1].IndexOf(':')+1)),
			};
            foreach (Action setting in settings)
            {
                setting();
            }
            txtAPIUrl.Text = APIRequests.apiUrl;
        }

        private void Create_Config_File()
        {
            string configDirectory = Path.Combine(Application.StartupPath, "Config");
            if (Directory.Exists(configDirectory))
            {
                return;
            }
            Directory.CreateDirectory(configDirectory);
            using (StreamWriter sw = new StreamWriter(Path.Combine(configDirectory, "config.txt")))
            {
                sw.WriteLine("API:" + API.APIRequests.apiUrl);
				sw.WriteLine("Timeout response(seconds):" + 30);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Timer Tick");
            Task update_information = Task.Run(() => Update_Current_Information());
            Search_Selected_Dispositivo();
        }

        public async void Update_Current_Information()
        {
            Console.WriteLine("Actualizando Informacion Dispositivos...");
			try
			{
				await Dispositivos.current.Update_Information();
				Console.WriteLine("Informacion actualizada.");
			}
			catch
			{
				Console.WriteLine("La informacion fue nula.");
			}
        }

        public async Task Update_Dispositivos()
        {
           Console.WriteLine("Actualizando Dispositivos...");
           List<DispositivoModel> result = await Dispositivos.Create_List();
           await Task.Run(() =>
           {
               Parallel.ForEach(Dispositivos.list, async disp =>
               {
                   await disp.Update_Information();
               });
           });
           Fill_Dispositivo_Box();
           Console.WriteLine("Dispositivos Actualizados.");
        }

        public void Fill_Dispositivo_Box()
        {
			int beforeIndex = comboDisp.SelectedIndex;
            if(comboDisp.Items.Count > 0) // Por alguna razon hay que checkear si tiene items si no se rompe.
            {
                comboDisp.Items.Clear();
            }
            foreach (string dispositivo_desc in Dispositivos.Get_Descripciones())
            {
                comboDisp.Items.Add(dispositivo_desc);
            }
			Console.WriteLine("INDEX:" + comboDisp.SelectedIndex);
            if(Dispositivos.list.Count >= beforeIndex && beforeIndex != -1)
			{
				comboDisp.SelectedIndex = beforeIndex;
				return;
			}
			comboDisp.SelectedIndex = 0;
        }

        private void Search_Selected_Dispositivo()
        {
			map.Overlays_Tick();
			InformationModel info = Dispositivos.current.Get_Last_Information();
            if (info == null) {
				txtLatitud.Text = "";
				txtLongitud.Text = "";
				txtVelGPS.Text = "";
				txtVelGPSPromedio.Text = "";
				txtVelDisp.Text = "";
				txtCorriente.Text = "";
				txtTension.Text = "";
				txtPotencia.Text = "";
				return; 
			}
			// Texts
			txtLatitud.Text = info.Latitud.ToString();
            txtLongitud.Text = info.Longitud.ToString();
            txtVelGPS.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current) + " km/h";
            txtVelGPSPromedio.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current, 10) + " km/h";
            txtVelDisp.Text = info.Velocidad.ToString() + " km/h";
            txtCorriente.Text = info.Corriente.ToString() + " A";
            txtTension.Text = info.Tension.ToString() + " V";
            txtEnergia.Text = info.Energia.ToString() + " kWh";
            txtPotencia.Text = info.Potencia.ToString() + " W";
            // Pins
            if (!checkPinPos.Checked) { return; }
            map.Set_Map_Position(new LatLng(info.Latitud, info.Longitud));
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
            if (!stopwatch.IsRunning)
			{
				stopwatch.Start();
                playBtn.Text = "Stop";
                return;
            }
            playBtn.Text = "Play";
			stopwatch.Stop();
			cronometroText_Update(stopwatch.Elapsed.ToString(@"hh\:mm\:ss\:fff"));
		}

		private void lapBtn_Click(object sender, EventArgs e)
		{
			if (stopwatch.ElapsedMilliseconds == 0)
			{
				return;
			}
			LapModel newLap = new LapModel(lapListBox.Items.Count, Dispositivos.current.Id, stopwatch.Elapsed);
			if (lapManager.lapList.Count > 0)
			{
				newLap.TotalTime = stopwatch.Elapsed;
				lapManager.InsertLap(newLap);
				return;
			}
			if (stopwatch.Elapsed - lapManager.lapList[1].TotalTime == TimeSpan.Zero)
			{
				newLap.TotalTime = stopwatch.Elapsed;
				newLap.ElapsedTime = TimeSpan.Zero;
				lapListBox.Items.Insert(0, lapManager.GetLapMessage(newLap));
				lapManager.InsertLap(newLap);
				return;
			}
			newLap.TotalTime = stopwatch.Elapsed;
			newLap.ElapsedTime = stopwatch.Elapsed - lapManager.lapList[1].TotalTime;
			lapListBox.Items.Insert(0, lapManager.GetLapMessage(newLap));
			lapManager.InsertLap(newLap);
		}

        private async Task Cronometro_Tick()
        {
            while (true)
            {
                await Task.Delay(50);
                if (!stopwatch.IsRunning) { continue; }
				TimeSpan time = stopwatch.Elapsed;
                cronometroText_Update(time.ToString(@"hh\:mm\:ss\:fff"));
            }
        }
        
        private void cronometroText_Update(string time)
        {
            if (cronometroTextBox.InvokeRequired)
            {
                cronometroTextBox.Invoke(new Action<string>(cronometroText_Update), time);
            }
            else
            {
                cronometroTextBox.Text = time;
            }
        }

        private void config_Click(object sender, EventArgs e)
        {
            panelConfig.Visible = !panelConfig.Visible;
            panelConfig.Height = 0;
            configTransition.Start();
        }

        private void configTransition_Tick(object sender, EventArgs e)
        {
            panelConfig.Height += 8;
            if(panelConfig.Height > 45)
            {
                configTransition.Stop();
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            SwitchFreezeUI();
			MapTimer.Stop();
			int currentBefore = Dispositivos.current.Id;
			if (stopwatch.IsRunning)
			{
				playBtn_Click(this, EventArgs.Empty);
			}
            try
            {
                await Update_Dispositivos();
				MessageBox.Show("Se actualizo la lista de dispositivos.");
			}
            catch (Exception ex)
            {
                MessageBox.Show("No se encontraron dispositivos: " + ex.Message);
				comboDisp.Items.Clear();
            }
			if(Dispositivos.current.Id != currentBefore)
			{
				cronometroText_Update("00:00:00:000");
			}
			MapTimer.Start();
			SwitchFreezeUI();
        }

        private void SwitchFreezeUI()
        {
            this.UseWaitCursor = !this.UseWaitCursor;
            panelMain.Enabled = !panelMain.Enabled;
            panelConfig.Enabled = !panelConfig.Enabled;
        }

		private void resetBtn_Click(object sender, EventArgs e)
		{
			if (stopwatch.IsRunning)
			{
				stopwatch.Restart();
			}
			else
			{
				stopwatch.Reset();
			}
			lapManager.InsertLap(new LapModel(lapListBox.Items.Count, Dispositivos.current.Id, TimeSpan.Zero));
			cronometroText_Update(stopwatch.Elapsed.ToString(@"hh\:mm\:ss\:fff"));
		}
	}
}