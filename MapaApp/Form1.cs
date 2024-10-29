using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

// Dependencias
using API;
using System.IO;
using Mapa.Models;
using Mapa.Services;
using System.Linq;

namespace Mapa
{
    public partial class Form1 : Form
    {
		//API o Dependencia que se usa
		private readonly ILapService lapManager;
		private readonly IDeviceService deviceManager;
		private readonly IDeviceInfoService deviceInfoManager;
		private readonly GoogleMapManager mapManager;

        Stopwatch stopwatch = new Stopwatch();
		TimeSpan timeBegin = TimeSpan.Zero;

        public Form1(GoogleMapManager mapManager, ILapService lapManager, IDeviceService deviceManager, IDeviceInfoService deviceInfoManager)
        {
			InitializeComponent();
			mapManager.control = gmapControl;
			this.mapManager = mapManager;
			this.lapManager = lapManager;
			this.deviceManager = deviceManager;
			this.deviceInfoManager = deviceInfoManager;
			mapManager.SetupMap();
			mapManager.SetupMarker();
            Start_Program();
        }

        private async void Start_Program()
        {
            mapManager.SetMapZoom(trackZoom.Value);
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
            Task update_information = Task.Run(() => Update_Current_Information());
            Search_Selected_Dispositivo();
        }

        public async void Update_Current_Information()
        {
			try
			{
				await deviceInfoManager.UpdateInfoByDeviceId(deviceManager.current.Id);
			}
			catch
			{
				Console.WriteLine("La informacion fue nula.");
			}
        }

        public async Task Update_Dispositivos()
        {
			List<DeviceModel> result = await deviceManager.UpdateDeviceList();
			await Task.WhenAll(deviceManager.deviceList.Select(async device =>
			{
				device.Information = await deviceInfoManager.UpdateInfoByDeviceId(device.Id);
				device.Laps = await lapManager.GetLapsByDeviceId(device.Id);
			}));
			Fill_Dispositivo_Box();
        }

        public void Fill_Dispositivo_Box()
        {
			int beforeIndex = comboDisp.SelectedIndex;
            if(comboDisp.Items.Count > 0) // Por alguna razon hay que checkear si tiene items si no se rompe.
            {
                comboDisp.Items.Clear();
            }
            foreach (string device_desc in deviceManager.GetDeviceDescriptions())
            {
                comboDisp.Items.Add(device_desc);
            }
            if(deviceManager.deviceList.Count >= beforeIndex && beforeIndex != -1)
			{
				comboDisp.SelectedIndex = beforeIndex;
				return;
			}
			comboDisp.SelectedIndex = 0;
        }

		public void Fill_Lap_Box()
		{
			lapListBox.Items.Clear();
			foreach (LapModel lap in deviceManager.current.Laps)
			{
				lapListBox.Items.Insert(0, lapManager.GetLapMessage(lap));
			}
			if(lapListBox.Items.Count > 0)
			{
				timeBegin = deviceManager.current.Laps[deviceManager.current.Laps.Count - 1].TotalTime;
			}
		}

		private void Search_Selected_Dispositivo()
        {
			mapManager.OverlaysTick();
			DeviceInfoModel info = deviceInfoManager.GetDeviceLastInformation(deviceManager.current);
			if (info == null) {
				txtLatitud.Text = "";
				txtLongitud.Text = "";
				txtVelGPS.Text = "";
				txtVelGPSPromedio.Text = "";
				return; 
			}
			// Texts
			txtLatitud.Text = info.Latitude.ToString();
            txtLongitud.Text = info.Longitude.ToString();
            txtVelGPS.Text = mapManager.CalculateVelocityofDevice(deviceManager.current) + " km/h";
            txtVelGPSPromedio.Text = mapManager.CalculateVelocityofDevice(deviceManager.current, 10) + " km/h";
            // Pins
            if (!checkPinPos.Checked) { return; }
            mapManager.SetMapPosition(new LatLng(info.Latitude, info.Longitude));
        }

        private void Combo_Dispositivo_Changed(object sender, EventArgs e)
        {
			deviceManager.ChangeCurrentDevice(comboDisp.SelectedIndex);
			Fill_Lap_Box();
			Search_Selected_Dispositivo();
        }

        private void checkPinPosition_Changed(object sender, EventArgs e)
        {
            mapManager.ToggleMovement();
            if (checkPinPos.Checked)
            {
                mapManager.SetMapPosition(deviceManager.GetCurrentDevicePosition());
                mapManager.SetMapZoom(trackZoom.Value);
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
			cronometroText_Update(stopwatch.Elapsed);
		}

		private void lapBtn_Click(object sender, EventArgs e)
		{
			if(deviceManager.deviceList.Count == 0)
			{
				return;
			}
			if (stopwatch.ElapsedMilliseconds == 0)
			{
				return;
			}
			LapModel newLap = new LapModel(lapListBox.Items.Count, deviceManager.current.Id, stopwatch.Elapsed);
			if (deviceManager.current.Laps.Count == 0)
			{
				newLap.TotalTime = stopwatch.Elapsed;
				deviceManager.current.Laps.Add(newLap);
				lapManager.InsertLap(newLap);
				lapListBox.Items.Insert(0, lapManager.GetLapMessage(newLap));
				return;
			}
			if (stopwatch.Elapsed - deviceManager.current.Laps[deviceManager.current.Laps.Count-1].TotalTime == TimeSpan.Zero)
			{
				if(deviceManager.current.Laps[deviceManager.current.Laps.Count - 1].ElapsedTime == TimeSpan.Zero)
				{
					return;
				}
				newLap.TotalTime = stopwatch.Elapsed;
				newLap.ElapsedTime = TimeSpan.Zero;
				deviceManager.current.Laps.Add(newLap);
				lapListBox.Items.Insert(0, lapManager.GetLapMessage(newLap));
				lapManager.InsertLap(newLap);
				return;
			}
			newLap.TotalTime = stopwatch.Elapsed;
			newLap.ElapsedTime = stopwatch.Elapsed - deviceManager.current.Laps[deviceManager.current.Laps.Count - 1].TotalTime;
			deviceManager.current.Laps.Add(newLap);
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
                cronometroText_Update(time);
            }
        }
        
        private void cronometroText_Update(TimeSpan time)
        {
            if (cronometroTextBox.InvokeRequired)
            {
                cronometroTextBox.Invoke(new Action<TimeSpan>(cronometroText_Update), time);
            }
            else
            {
                cronometroTextBox.Text = (time + timeBegin).ToString(@"hh\:mm\:ss\:fff");
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
			int currentBefore = deviceManager.current.Id;
			if (stopwatch.IsRunning)
			{
				playBtn_Click(this, EventArgs.Empty);
			}
            try
            {
                await Update_Dispositivos();
				MessageBox.Show("Se actualizo la lista de dispositivos.");
				Search_Selected_Dispositivo();
			}
            catch (Exception ex)
            {
                MessageBox.Show("No se encontraron dispositivos: " + ex.Message);
				comboDisp.Items.Clear();
            }
			if(deviceManager.current.Id != currentBefore)
			{
				cronometroText_Update(TimeSpan.Zero);
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
				timeBegin = TimeSpan.Zero;
				stopwatch.Restart();
			}
			else
			{
				timeBegin = TimeSpan.Zero;
				stopwatch.Reset();
			}
			cronometroText_Update(stopwatch.Elapsed);
			if(lapListBox.Items.Count == 0 || deviceManager.current.Laps.Count == 0)
			{
				return;
			}
			if(deviceManager.current.Laps[deviceManager.current.Laps.Count-1].TotalTime == TimeSpan.Zero)
			{
				return;
			}
			LapModel lap = new LapModel(lapListBox.Items.Count, deviceManager.current.Id, TimeSpan.Zero);
			lapManager.InsertLap(lap);
			deviceManager.current.Laps.Add(lap);
			lapListBox.Items.Insert(0, lapManager.GetLapMessage(lap));
		}
	}
}