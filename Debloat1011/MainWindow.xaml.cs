using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace Debloat_1011
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ProgValue(int count, IProgress<double> progress)
        {
            for(int x= 1; x < count; x++)
            {
                var percent = (x * 3.4);
                progress.Report(percent);
            }
        }

        public void ProgValue2(int count, IProgress<double> progress)
        {
            for (int x = 1; x < count; x++)
            {
                var percent = (x * 2.95);
                progress.Report(percent);
            }
        }

        private async void btn_MSapps_click(object sender, RoutedEventArgs e )
        {

            try
            {
                if (MessageBox.Show("Run The Script?", "RUN?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    Process Tprocess = new Process();
                    Tprocess.StartInfo.FileName = "cmd.exe";
                    Tprocess.StartInfo.RedirectStandardInput = true;
                    Tprocess.StartInfo.RedirectStandardOutput = true;
                    Tprocess.StartInfo.CreateNoWindow = true;
                    Tprocess.StartInfo.UseShellExecute = false;
                    Tprocess.Start();

                    Tprocess.StandardInput.WriteLine("winget list");
                    System.Threading.Thread.Sleep(1500);
                    Tprocess.StandardInput.WriteLine("y");
                    Tprocess.StandardInput.Flush();
                    Tprocess.StandardInput.Close();

                    var progress = new Progress<double>(value =>
                    {
                        Progbar.Value = value;
                    });

                    await Task.Run(() =>
                    {
                        string[] commands = { "winget uninstall Microsoft.BingWeather_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.GetHelp_8wekyb3d8bbwe", "winget uninstall Microsoft.Getstarted_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.YourPhone_8wekyb3d8bbwe", "winget uninstall Microsoft.WindowsFeedbackHub_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.SkypeApp_kzf8qxf38zg5c", "winget uninstall Microsoft.Office.OneNote_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.ZuneVideo_8wekyb3d8bbwe", "winget uninstall Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe",
                        "winget uninstall 9WZDNCRFJ3PT", "winget uninstall Microsoft.XboxGamingOverlay_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.People_8wekyb3d8bbwe", "winget uninstall Microsoft.WindowsMaps_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WindowsAlarms_8wekyb3d8bbwe", "winget uninstall Microsoft.MixedReality.Portal_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe", "winget uninstall Microsoft.Microsoft3DViewer_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.MicrosoftOfficeHub_8wekyb3d8bbwe", "winget uninstall Microsoft.MSPaint_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.XboxGameOverlay_8wekyb3d8bbwe", "winget uninstall Microsoft.XboxSpeechToTextOverlay_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.Xbox.TCUI_8wekyb3d8bbwe", "winget uninstall Microsoft.XboxIdentityProvider_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.XboxApp_8wekyb3d8bbwe", "winget uninstall Microsoft.WebMediaExtensions_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.Wallet_8wekyb3d8bbwe", "winget uninstall Microsoft.549981C3F5F10_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.HEIFImageExtension_8wekyb3d8bbwe", "winget uninstall Microsoft.VP9VideoExtensions_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WebpImageExtension_8wekyb3d8bbwe", "winget uninstall Microsoft.MicrosoftSolitaireCollection_8wekyb3d8bbwe"};

                        for (int i = 0; i < commands.Length; i++)
                        {
                            ProgValue(i, progress);
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.RedirectStandardInput = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.UseShellExecute = false;
                            process.Start();

                            process.StandardInput.WriteLine(commands[i]);
                            process.StandardInput.Flush();
                            process.StandardInput.Close();
                            string output = process.StandardOutput.ReadToEnd();

                        }
                    });
                    Progbar.Value = 0;
                    MessageBox.Show("Done!");
                }
            }

            catch { }

        }

        private async void btn_installed_click(object sender, RoutedEventArgs e)
        {
            try
            {

                await Task.Run(() =>
                {
                    Process process = new Process();
                    process.StartInfo.FileName = "cmd.exe";
                    process.StartInfo.RedirectStandardInput = true;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.Start();

                    process.StandardInput.WriteLine("winget list");
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    string output = process.StandardOutput.ReadToEnd();

                    TextWriter tw = new StreamWriter("C:\\Program Files (x86)\\KyzoWare\\Debloat1011\\applist.txt");
                    tw.WriteLine(output);
                    tw.Close();

                    Environment.CurrentDirectory = "C:\\Program Files (x86)\\KyzoWare\\Debloat1011";
                    Process.Start("applist.txt");
                });
            }
            catch { }
        }

        private async void btn_AllBloat_click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Run The Script?", "RUN?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
                else
                {
                    Process Tprocess = new Process();
                    Tprocess.StartInfo.FileName = "cmd.exe";
                    Tprocess.StartInfo.RedirectStandardInput = true;
                    Tprocess.StartInfo.RedirectStandardOutput = true;
                    Tprocess.StartInfo.CreateNoWindow = true;
                    Tprocess.StartInfo.UseShellExecute = false;
                    Tprocess.Start();

                    Tprocess.StandardInput.WriteLine("winget list");
                    System.Threading.Thread.Sleep(1500);
                    Tprocess.StandardInput.WriteLine("y");
                    Tprocess.StandardInput.Flush();
                    Tprocess.StandardInput.Close();

                    var progress = new Progress<double>(value =>
                    {
                        Progbar.Value = value;
                    });

                    Process.Start("C:\\Program Files (x86)\\KyzoWare\\Debloat1011\\Edge_Removal.bat");

                    await Task.Run(() =>
                    {
                        string[] commands = { "winget uninstall Microsoft.BingWeather_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.GetHelp_8wekyb3d8bbwe", "winget uninstall Microsoft.Getstarted_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.YourPhone_8wekyb3d8bbwe", "winget uninstall Microsoft.WindowsFeedbackHub_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.SkypeApp_kzf8qxf38zg5c", "winget uninstall Microsoft.Office.OneNote_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.ZuneVideo_8wekyb3d8bbwe", "winget uninstall Microsoft.MicrosoftStickyNotes_8wekyb3d8bbwe",
                        "winget uninstall 9WZDNCRFJ3PT", "winget uninstall Microsoft.XboxGamingOverlay_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.People_8wekyb3d8bbwe", "winget uninstall Microsoft.WindowsMaps_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WindowsAlarms_8wekyb3d8bbwe", "winget uninstall Microsoft.MixedReality.Portal_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe", "winget uninstall Microsoft.Microsoft3DViewer_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.MicrosoftOfficeHub_8wekyb3d8bbwe", "winget uninstall Microsoft.MSPaint_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.XboxGameOverlay_8wekyb3d8bbwe", "winget uninstall Microsoft.XboxSpeechToTextOverlay_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.Xbox.TCUI_8wekyb3d8bbwe", "winget uninstall Microsoft.XboxIdentityProvider_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.XboxApp_8wekyb3d8bbwe", "winget uninstall Microsoft.WebMediaExtensions_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.Wallet_8wekyb3d8bbwe", "winget uninstall Microsoft.549981C3F5F10_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.HEIFImageExtension_8wekyb3d8bbwe", "winget uninstall Microsoft.VP9VideoExtensions_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.WebpImageExtension_8wekyb3d8bbwe", "winget uninstall Microsoft.MicrosoftSolitaireCollection_8wekyb3d8bbwe",
                        "winget uninstall microsoft.windowscommunicationsapps_8wekyb3d8bbwe", "winget uninstall Microsoft.MicrosoftEdge.Stable_8wekyb3d8bbwe",
                        "winget uninstall Microsoft.OneDrive", "winget uninstall Microsoft.EdgeWebView2Runtime",
                        "winget uninstall Microsoft.StorePurchaseApp_8wekyb3d8bbwe", "winget uninstall {BB052C53-34CB-42DE-AF41-66FDFCEEC868}"};

                        for (int i = 0; i < commands.Length; i++)
                        {
                            ProgValue2(i, progress);
                            Process process = new Process();
                            process.StartInfo.FileName = "cmd.exe";
                            process.StartInfo.RedirectStandardInput = true;
                            process.StartInfo.RedirectStandardOutput = true;
                            process.StartInfo.CreateNoWindow = true;
                            process.StartInfo.UseShellExecute = false;
                            process.Start();

                            process.StandardInput.WriteLine(commands[i]);
                            process.StandardInput.Flush();
                            process.StandardInput.Close();
                            string output = process.StandardOutput.ReadToEnd();

                        }
                    });

                    Progbar.Value = 0;
                    MessageBox.Show("Done!", "Done!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

            catch { MessageBox.Show("Can't Find Required Files Try Reinstalling", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void btn_brave_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install Brave?", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Brave.Brave");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        private void btn_firefox_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install Firefox?", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Mozilla.Firefox");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        private void btn_waterfox_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install Waterfox?", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Waterfox.Waterfox");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        private void btn_opera_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install Opera?", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Opera.Opera");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        private void btn_operaGX_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install OperaGX?", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Opera.OperaGX");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }

        private void btn_chrome_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Install Chrome?\n(Not recommended for privacy!!!)", "Install?", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.UseShellExecute = false;
                process.Start();

                process.StandardInput.WriteLine("winget install Google.Chrome");
                process.StandardInput.Flush();
                process.StandardInput.Close();
            }
        }
    }
}
