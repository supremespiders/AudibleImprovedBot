using System.Diagnostics;
using System.Globalization;
using System.Net;
using airbnb.comLister.Models;
using AudibleImprovedBot.Models;
using AudibleImprovedBot.Services;
using Newtonsoft.Json;

namespace AudibleImprovedBot
{
    public partial class Form1 : Form
    {
        private readonly string _path = Application.StartupPath;
        private Dictionary<string, string> _config;
        private const string SimpleDateFormat = "dd/MM/yyyy HH:mm:ss";
        private Scraper _scraper = new();

        public Form1()
        {
            InitializeComponent();
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            SaveConfig();
            var c = new Config()
            {
                InputFolder = inputI.Text,
                DoRunAt = runAtI.Checked,
                RunAt = dateTimeI.Value,
                Stars = starsCountI.SelectedIndex,
                TwoCaptchaKey = twoCaptchaKeyI.Text,
                DoLimitRedeem = isRedeemLimitedI.Checked,
                TargetSuccessPerFile = (int)redeemNumberI.Value,
                DoLoop = LoopI.Checked,
                DoLoopFiles = loopFilesI.Checked,
                HoursBetweenFiles = (int)delayBetweenFilesI.Value,
                SkipFailedEntries = SkipTheFailedI.Checked,
                MaxThreads = (int)threadsI.Value
            };
            try
            {
                await _scraper.MainWork(c);
            }
            catch (KnownException ex)
            {
                ErrorLog(ex.Message);
                Display(ex.Message);
            }
            catch (Exception ex)
            {
                ErrorLog(ex.ToString());
                Display(ex.Message);
            }
        }

        private async void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
            await _scraper.Dispose();
        }

        void InitControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    try
                    {
                        if (x.Name.EndsWith("I"))
                        {
                            switch (x)
                            {
                                case CheckBox _:
                                    ((CheckBox)x).Checked = bool.Parse(_config[((CheckBox)x).Name]);
                                    break;
                                case ComboBox _:
                                    ((ComboBox)x).SelectedIndex = int.Parse(_config[x.Name]);
                                    break;
                                case DateTimePicker _:
                                    ((DateTimePicker)x).Value = DateTime.Parse(_config[((DateTimePicker)x).Name]);
                                    break;
                                case RadioButton radioButton:
                                    radioButton.Checked = bool.Parse(_config[radioButton.Name]);
                                    break;
                                case TextBox _:
                                case RichTextBox _:
                                    x.Text = _config[x.Name];
                                    break;
                                case NumericUpDown numericUpDown:
                                    numericUpDown.Value = int.Parse(_config[numericUpDown.Name]);
                                    break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    InitControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveControls(Control parent)
        {
            try
            {
                foreach (Control x in parent.Controls)
                {
                    #region Add key value to disctionarry

                    if (x.Name.EndsWith("I"))
                    {
                        switch (x)
                        {
                            case RadioButton _:
                            case CheckBox _:
                                _config.Add(x.Name, ((CheckBox)x).Checked + "");
                                break;
                            case ComboBox box:
                                _config.Add(box.Name, box.SelectedIndex.ToString());
                                break;
                            case DateTimePicker picker:
                                _config.Add(picker.Name, picker.Value.ToString(CultureInfo.InvariantCulture));
                                break;
                            case TextBox _:
                            case RichTextBox _:
                                _config.Add(x.Name, x.Text);
                                break;
                            case NumericUpDown down:
                                _config.Add(down.Name, down.Value + "");
                                break;
                            default:
                                Console.WriteLine(@"could not find a type for " + x.Name);
                                break;
                        }
                    }

                    #endregion

                    SaveControls(x);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void SaveConfig()
        {
            _config = new Dictionary<string, string>();
            SaveControls(this);
            try
            {
                File.WriteAllText("config.txt", JsonConvert.SerializeObject(_config, Formatting.Indented));
            }
            catch (Exception e)
            {
                ErrorLog(e.ToString());
            }
        }

        private void LoadConfig()
        {
            try
            {
                _config = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("config.txt"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }

            InitControls(this);
        }

        private delegate void WriteToLogD(string s, Color c);

        private void WriteToLog(string s, Color c)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new WriteToLogD(WriteToLog), s, c);
                    return;
                }

                if (logT.Lines.Length > 5000)
                {
                    logT.Text = "";
                }

                logT.SelectionStart = logT.Text.Length;
                logT.SelectionColor = c;
                logT.AppendText(DateTime.Now.ToString(SimpleDateFormat) + " : " + s + Environment.NewLine);

                Console.WriteLine(DateTime.Now.ToString(SimpleDateFormat) + @" : " + s);
                File.AppendAllText(_path + "/data/log.txt", DateTime.Now.ToString(SimpleDateFormat) + @" : " + s + Environment.NewLine);
            }
            catch (Exception ex)
            {
             MessageBox.Show(ex.ToString());
            }
        }

        public void NormalLog(string s)
        {
            WriteToLog(s, Color.Black);
        }

        public void ErrorLog(string s)
        {
            WriteToLog(s, Color.Red);
        }

        public void SuccessLog(string s)
        {
            WriteToLog(s, Color.Green);
        }

        public void CommandLog(string s)
        {
            WriteToLog(s, Color.Blue);
        }

        private delegate void DisplayD(string s);

        public void Display(string s)
        {
            if (InvokeRequired)
            {
                Invoke(new DisplayD(Display), s);
                return;
            }

            displayT.Text = s;
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.ToString(), @"Unhandled Thread Exception");
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show((e.ExceptionObject as Exception)?.ToString(), @"Unhandled UI Exception");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServicePointManager.DefaultConnectionLimit = 65000;
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Directory.CreateDirectory($"{_path}/data");
            Directory.CreateDirectory($"{_path}/Screenshots");
            inputI.Text = _path;
            delayI.SelectedIndex = 0;
            Notifier.OnDisplay += OnDisplay;
            Notifier.OnLog += OnLog;
            Notifier.OnError += OnError;
            LoadConfig();
        }
        
        private void OnError(object sender, string e)
        {
            ErrorLog(e);
        }

        private void OnLog(object sender, string e)
        {
            NormalLog(e);
        }

        private void OnDisplay(object sender, string e)
        {
            Display(e);
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            using var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                inputI.Text = fbd.SelectedPath;
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                var psi = new ProcessStartInfo
                {
                    FileName = inputI.Text,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception exception)
            {
               ErrorLog(exception.ToString());
            }
        }
    }
}