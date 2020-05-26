using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Tommy;
//https://github.com/dezhidki/Tommy

namespace FlexASIO_GUI
{
    public partial class Form1 : Form
    {
        private readonly string _confPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "FlexASIO.toml");
        private static readonly string _devicesPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "FlexASIO_Config_GUI");
        private static string[] _deviceList = new string[1000];
        private static int _deviceId = 0;
    #if WIN64
        private static readonly string _arch = "x64";
    #else
        private static readonly string _arch = "x86";
    #endif

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string path = Path.Combine(_devicesPath, _arch);
                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);
                
                if (!File.Exists(Path.Combine(path, "PortAudioDevices.exe")))
                {
                    Thread thread1 = new Thread(() => CreateEmbeddedFiles("PortAudioDevices.exe"));
                    Thread thread2 = new Thread(() => CreateEmbeddedFiles("portaudio_" + _arch + ".dll"));
                    thread1.Start();
                    thread2.Start();
                }
                DeviceList();
                LoadConf();
                LoadTtp();
            }
            catch(Exception x)
             {
                alert(x.Message);
                Application.Exit();
            }
        }
        private void LoadConf()
        {
            if (File.Exists(_confPath))
            {
                using (StreamReader reader = new StreamReader(File.OpenRead(_confPath)))
                {
                    
                    TomlTable table = TOML.Parse(reader);
                    TomlString backend=null; //i need the backend var later.
                    if (table["backend"] is TomlString)
                    {
                        backend = table["backend"].AsString;
                        comboBoxBackend.SelectedIndex = comboBoxBackend.FindStringExact(backend.ToString().Trim('"'));
                    }
                    else
                    {
                        comboBoxBackend.SelectedIndex = comboBoxBackend.FindStringExact("-");
                    }
                    if (table["bufferSizeSamples"] is TomlInteger buffer) { textBoxBuff.Text = buffer; } else { textBoxBuff.Text = ""; }

                    if (table["input"]["device"] is TomlString idev) { comboBoxIDev.SelectedIndex = MatchItem(comboBoxIDev, idev.ToString().Substring(1, idev.ToString().Length-2), backend.ToString().Trim('"')); } else { comboBoxIDev.SelectedIndex = 0; }
                    if (table["input"]["channels"] is TomlInteger ichan) { numericUpDownIChan.Value = ichan; } else { numericUpDownIChan.Value = -1; }
                    if (table["input"]["suggestedLatencySeconds"] is TomlFloat ilat) { textBoxILat.Text = ilat; } else { textBoxILat.Text = ""; }   //0.0
                    if (table["input"]["sampleType"] is TomlString ityp) { comboBoxISamT.SelectedIndex = comboBoxISamT.FindStringExact(ityp.ToString().Trim('"')); } else { comboBoxISamT.SelectedIndex = comboBoxISamT.FindStringExact("-"); }
                    if (table["input"]["wasapiExclusiveMode"] is TomlBoolean iex) { checkBoxIEx.Checked = iex; } else { checkBoxIEx.Checked = false; }
                    if (table["input"]["wasapiAutoConvert"] is TomlBoolean iconv) { checkBoxIConv.Checked = iconv; } else { checkBoxIConv.Checked = true; }

                    if (table["output"]["device"] is TomlString odev) { comboBoxODev.SelectedIndex = MatchItem(comboBoxODev, odev.ToString().Substring(1, odev.ToString().Length - 2), backend.ToString().Trim('"')); } else { comboBoxODev.SelectedIndex = 0; }
                    if (table["output"]["channels"] is TomlInteger ochan) { numericUpDownOChan.Value = ochan; } else { numericUpDownOChan.Value = -1; }
                    if (table["output"]["suggestedLatencySeconds"] is TomlFloat olat) { textBoxOLat.Text = olat; } else { textBoxOLat.Text = ""; }  //0.0
                    if (table["output"]["sampleType"] is TomlString otyp) { comboBoxOSamT.SelectedIndex = comboBoxOSamT.FindStringExact(otyp.ToString().Trim('"')); } else { comboBoxOSamT.SelectedIndex = comboBoxOSamT.FindStringExact("-"); }
                    if (table["output"]["wasapiExclusiveMode"] is TomlBoolean oex) { checkBoxOEx.Checked = oex; } else { checkBoxOEx.Checked = false; }
                    if (table["output"]["wasapiAutoConvert"] is TomlBoolean oconv) { checkBoxOConv.Checked = oconv; } else { checkBoxOConv.Checked = true; }

                    alert("Your `FlexASIO.toml` configuration file was found."+Environment.NewLine+"All the recognized parameters has been loaded into this GUI.");
                }
            }            
            else
            {
                comboBoxBackend.SelectedIndex = 0;
                textBoxBuff.Text = "512";

                comboBoxIDev.SelectedIndex = 0;
                numericUpDownIChan.Value = 2;
                textBoxILat.Text = "0.0";
                comboBoxISamT.SelectedIndex = comboBoxISamT.FindStringExact("Float32");
                checkBoxIEx.Checked = false; 
                checkBoxIConv.Checked = true;

                comboBoxODev.SelectedIndex = 0; 
                numericUpDownOChan.Value = 2; 
                textBoxOLat.Text = "0.0";
                comboBoxOSamT.SelectedIndex = comboBoxOSamT.FindStringExact("Float32");
                checkBoxOEx.Checked = false; 
                checkBoxOConv.Checked = true; 

                alert("No config file found at `"+_confPath+"`."+Environment.NewLine+"Starting from scratch with a random config.");        
            }
        }

        private void DeviceList()
        {
            _deviceList[0] = "-";
            using (Process p = new Process())
            {
                p.StartInfo.FileName = Path.Combine(_devicesPath, _arch, "PortAudioDevices.exe");
                p.StartInfo.Arguments = "";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.StandardOutputEncoding = Encoding.UTF8;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.OutputDataReceived += new DataReceivedEventHandler(CbDevices);
                p.ErrorDataReceived += (s, e) => Console.WriteLine(e.Data);
                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.WaitForExit();

                var lastbackend = "";
                comboBoxIDev.BeginUpdate();
                comboBoxODev.BeginUpdate();
                foreach(string str in _deviceList)
                {
                    if (String.IsNullOrEmpty(str))
                        break;
                    if (str != "-")
                    {
                        var r = new Regex(@"^Device name:\s+""(.+)""\s+(?:\r|\n|\r\n)+(?:.|\r|\n|\r\n)+Host API name:\s+(.+)\s+(?:\r|\n|\r\n)+",RegexOptions.Multiline);
                        var res = r.Match(str);
                        if (lastbackend != res.Groups[2].Value)
                        {
                            lastbackend = res.Groups[2].Value;
                            comboBoxIDev.Items.Add(" ");
                            comboBoxIDev.Items.Add(" = = = =  "+ lastbackend + "  = = = = ");
                            comboBoxODev.Items.Add(" ");
                            comboBoxODev.Items.Add(" = = = =  " + lastbackend+"  = = = = ");
                        }
                        var tmp = str;
                        if (tmp.Length > 100)
                        {
                            for (var i=1; i<=(tmp.Length/100); i++) {
                                tmp = tmp.Insert(i*100,""+Environment.NewLine);
                            }
                        }
                        comboBoxIDev.Items.Add(res.Groups[1].Value + "==:PopFullInformationsDatas:==" + tmp);
                        comboBoxODev.Items.Add(res.Groups[1].Value + "==:PopFullInformationsDatas:==" + tmp);
                    }
                }
                comboBoxIDev.EndUpdate();
                comboBoxODev.EndUpdate();
            }
        }
        static void CbDevices(object senderProc, DataReceivedEventArgs devicesLine)
        {
            if (!String.IsNullOrEmpty(devicesLine.Data))
            {
                if (Regex.IsMatch(devicesLine.Data, @"Device index: [0-9]+"))
                {
                    _deviceId++;
                }
                _deviceList[_deviceId] += devicesLine.Data + Environment.NewLine;
            }
        }



        // ToolTips for devices adapted for my needs  //From Michael Sorens @ https://stackoverflow.com/a/5053730
        private void LoadTtp()
        {
            comboBoxIDev.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxIDev.DrawItem += comboBoxIDev_DrawItem;
            comboBoxIDev.DropDownClosed += comboBoxIDev_DropDownClosed;
        }
        private void comboBoxIDev_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; } // added this line thanks to Andrew's comment
            string[] altText = { "==:PopFullInformationsDatas:==" };

            string text = comboBoxIDev.GetItemText(comboBoxIDev.Items[e.Index]);
            string[] tips = text.Split(altText, StringSplitOptions.RemoveEmptyEntries);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(tips[0], e.Font, br, e.Bounds); }
            if ((tips.Length>1) && ((e.State & DrawItemState.Selected) == DrawItemState.Selected))
            { toolTip1.Show(tips[1], comboBoxIDev, e.Bounds.Right, e.Bounds.Bottom); }
            e.DrawFocusRectangle();
        }
        private void comboBoxIDev_DropDownClosed(object sender, EventArgs e)
        {
            toolTip1.Hide(comboBoxIDev);
        }
        // END ToolTips for devices


        private static void alert(string str)
        {
            MessageBox.Show(str);
        }
        private static void CreateEmbeddedFiles(string res)
        {
            using (System.IO.Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("FlexASIO_GUI.thirdp."+_arch +"."+ res))
            {
                using (System.IO.FileStream fileStream = new System.IO.FileStream(System.IO.Path.Combine(_devicesPath, _arch, res), System.IO.FileMode.Create))
                {
                    for (int i=0; i<stream.Length; i++)
                    {
                        fileStream.WriteByte((byte)stream.ReadByte());
                    }
                    fileStream.Close();
                }
            }
        }
        private int MatchItem(ComboBox obj, string str, string bckend)
        {
            List<int> allIndex = new List<int>();
            for (var i=0; ((i>=0) && (i<obj.Items.Count)); i++)
            {
               if(i > (i = obj.FindString(str, i))) { break; }                
               allIndex.Add(i);
            }
            if (allIndex.Count > 1)
            {
                var r = new Regex(@"^Device name:\s+""(.+)""\s+(?:\r|\n|\r\n)+(?:.|\r|\n|\r\n)+Host API name:\s+(.+)\s+(?:\r|\n|\r\n)+", RegexOptions.Multiline);
                for (var j=0; ((allIndex[j]>=0) && (j<allIndex.Count)); j++)
                {
                    var res = r.Match(obj.GetItemText(obj.Items[allIndex[j]]));
                    if ((res.Groups[2].Value == bckend) && (res.Groups[1].Value == str))
                    {
                        return allIndex[j];
                    }
                }
            }
            return -1;
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string[] altText = { "==:PopFullInformationsDatas:==" };
            bool gotError = false;
            DialogResult confirm = MessageBox.Show("This will OVERWRITE the existing `FlexASIO.toml` with your fresh-cooked configuration." + Environment.NewLine+"Do you still want to apply the changes now?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirm == DialogResult.Yes)
            {
                TomlTable toml = new TomlTable { };
                var regdev = new Regex(@"^(?:\s| = = = =  .+  = = = = ){1}$");
                var regat = new Regex(@"^[0-9]*(?:,|\.)?[0-9]+$");
                //ROOT
                if ((comboBoxBackend.SelectedItem != null) && (comboBoxBackend.GetItemText(comboBoxBackend.SelectedItem) != "-"))
                {
                    toml["backend"] = comboBoxBackend.GetItemText(comboBoxBackend.SelectedItem);
                }
                else
                {
                    gotError = true;
                    alert("Error : No backend selected.");
                }
                if (textBoxBuff.Text.Length > 0) {
                    if (int.TryParse(textBoxBuff.Text, out int result))
                    {
                        toml["bufferSizeSamples"] = result;
                    }
                    else
                    {
                        gotError = true;
                        alert("Error : Wrong value used for bufferSizeSamples.");
                    }
                }

                //INPUT
                if ((comboBoxIDev.SelectedItem != null) && (!string.IsNullOrEmpty(comboBoxIDev.GetItemText(comboBoxIDev.SelectedItem))))
                {
                    if (regdev.IsMatch(comboBoxIDev.GetItemText(comboBoxIDev.SelectedItem)))
                    {
                        toml["input"]["device"] = "";
                    }
                    else
                    {
                        toml["input"]["device"] = comboBoxIDev.GetItemText(comboBoxIDev.SelectedItem).Split(altText, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                }
                if (numericUpDownIChan.Value > 0)
                {
                    toml["input"]["channels"] = int.Parse(numericUpDownIChan.Value.ToString());
                }
                if (textBoxILat.Text.Length > 0)
                {
                    if (regat.IsMatch(textBoxILat.Text) && (float.TryParse(textBoxILat.Text, out float result)))
                    {
                       // can't find a way to use 0.0
                       //also strange mystery happens when you use comas xD example 0,1 
                        toml["input"]["suggestedLatencySeconds"] = result;
                    }
                    else
                    {
                        gotError = true;
                        alert("Error : Wrong value used for input:suggestedLatencySeconds.");
                    }
                }
                if (comboBoxISamT.GetItemText(comboBoxISamT.SelectedItem) != "-")
                {
                    toml["input"]["sampleType"] = comboBoxISamT.GetItemText(comboBoxISamT.SelectedItem);
                }
                toml["input"]["wasapiExclusiveMode"] = checkBoxIEx.Checked;
                toml["input"]["wasapiAutoConvert"] = checkBoxIConv.Checked;

                //OUTPUT 
                if ((comboBoxODev.SelectedItem != null) && (!string.IsNullOrEmpty(comboBoxODev.GetItemText(comboBoxODev.SelectedItem))))
                {
                    if (regdev.IsMatch(comboBoxODev.GetItemText(comboBoxODev.SelectedItem)))
                    {
                        toml["output"]["device"] = "";
                    }
                    else
                    {
                        toml["output"]["device"] = comboBoxODev.GetItemText(comboBoxODev.SelectedItem).Split(altText, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                }
                if (numericUpDownOChan.Value > 0)
                {
                    toml["output"]["channels"] = int.Parse(numericUpDownOChan.Value.ToString());
                }
                if (textBoxOLat.Text.Length > 0)
                {
                    if (regat.IsMatch(textBoxOLat.Text) && (float.TryParse(textBoxOLat.Text, out float result)))
                    {
                        // can't find a way to use 0.0
                        //also strange mystery happens when you use comas xD example 0,1 
                        toml["output"]["suggestedLatencySeconds"] = result;
                    }                    
                    else
                    {
                        gotError = true;
                        alert("Error : Wrong value used for output:suggestedLatencySeconds.");
                    }
                }
                if (comboBoxOSamT.GetItemText(comboBoxOSamT.SelectedItem) != "-")
                {
                    toml["output"]["sampleType"] = comboBoxOSamT.GetItemText(comboBoxOSamT.SelectedItem);
                }               
                toml["output"]["wasapiExclusiveMode"] = checkBoxOEx.Checked;
                toml["output"]["wasapiAutoConvert"] = checkBoxOConv.Checked;
                if (gotError)
                {
                    alert("Some parameters you entered can't be validated." + Environment.NewLine + "SAVING ABORTED.");
                }
                else
                {
                    FileInfo fi = new FileInfo(_confPath);
                    using (StreamWriter writer = new StreamWriter(fi.Open(FileMode.Truncate)))
                    {
                        toml.ToTomlString(writer);
                        alert("Your configuration is now applied." + Environment.NewLine + "Restart your FlexASIO driver if its already running.");
                    }
                }
            }
            else
            {
                alert("Nothing done.");
            }
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (File.Exists(_confPath))
                Process.Start("explorer.exe","/select, "+_confPath);
            else
                Process.Start("explorer.exe", Path.GetDirectoryName(_confPath));

        }
    }
}
