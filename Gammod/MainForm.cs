using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using Gammod.Properties;
using MetroFramework.Forms;
using System.Data;
using MetroFramework;
using MetroFramework.Drawing;
using MetroFramework.Controls;
using Microsoft.Win32;

namespace Gammod
{
    public partial class MainForm : MetroForm
    {

        public MainForm()
        {
            InitializeComponent();

            try
            {
                Settings.Default.Upgrade();
                //Settings.Default.Reload();
                DataTable _table = new DataTable();
                metroGrid1.DataSourceChanged += DataLoad;
                _table.ReadXml(Application.StartupPath + @dataFile);
                metroGrid1.DataSource = _table;
                _table.RowDeleting += TableRowDeleting;
            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            metroGrid1.Font = new Font("Segoe UI", 11f, FontStyle.Regular, GraphicsUnit.Pixel);
            metroGrid1.AllowUserToAddRows = false;

            // to prevent flickering
            typeof(MetroPanel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(metroPanel2, true, null);
        }

        private String dataFile = @"\Data\Files.xml";
        private MetroTileCustom currentTileCustom = null;
        private DebugForm debugForm;
        private Debugger dbg = new Debugger();
        private XmlDocument _currentGame = new XmlDocument();
        private XmlNode _currentProfile = new XmlDocument();
        private int _xmlValidationErrors = 0;
        private int _verticalPos = 0;

        private enum OriginInstValType
        {
            uninstallPath = 0,
            langList = 1,
            registryPath = 2
        };

        private void metroTileSwitch_Click(object sender, EventArgs e)
        {
            var m = new Random();
            int next = m.Next(0, 13);
            metroStyleManager.Style = (MetroColorStyle)next;
            Settings.Default["MetroColor"] = metroStyleManager.Style;
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            metroStyleManager.Theme = metroStyleManager.Theme == MetroThemeStyle.Light ? MetroThemeStyle.Dark : MetroThemeStyle.Light;
            Settings.Default["MetroStyle"] = metroStyleManager.Theme;
        }

        #region Data Loading

        private void TableRowDeleting(object sender, EventArgs e)
        {
            Control c = metroPanel2.Controls[(sender as DataRow).Table.Rows.IndexOf(sender as DataRow) + 1];
            metroPanel2.Controls.Remove(c);
            c.Dispose();
        }

        private void ClearControls(Control parent, Type controlType = null)
        {
            Control.ControlCollection controls = parent.Controls;
            parent.AutoScrollOffset = new Point(0, 0);
            for (int i = controls.Count - 1; i >= 0; i--)
            {
                Control c = controls[i];
                if (controlType != null)
                {
                    if (c.GetType() == controlType)
                    {
                        controls.Remove(c);
                        c.Dispose();
                    }
                }
                else
                {
                    controls.Remove(c);
                    c.Dispose();
                }
            }
        }

        private void DataLoad(object sender, EventArgs e)
        {
            metroPanel2.AutoScroll = false;
            ClearControls(metroPanel2, typeof(MetroTileCustom));

            DataTable table = (DataTable)metroGrid1.DataSource;
            MetroTileCustom prevM = null;
            if (table == null)
                return;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                MetroTileCustom m = new MetroTileCustom();
                m.TileCount = i + 1;
                m.Left = 0;
                if (prevM == null)
                    m.Top = 0;
                else
                    m.Top = prevM.Bottom + 5;
                m.Height = 70;
                m.Parent = metroPanel2;
                m.Width = m.Parent.Width - (m.Parent as MetroPanel).VerticalScrollbarSize - 2;
                m.Text = table.Rows[i][0].ToString();
                m.CustomObject = table.Rows[i][2].ToString();
                m.CustomPaint += metroTileCustom_CustomPaint;
                m.CustomPaintBackground += metroTileCustom_CustomPaintBackground;
                m.Enter += metroTileCustom_Enter;
                m.Leave += metroTileCustom_Leave;
                prevM = m;
            }
            metroStyleManager.Style = MetroColorStyle.Orange;
            metroLabel_ItemsCount.Text = table.Rows.Count.ToString();
            metroPanel2.AutoScroll = true;
        }

        private void ValidationHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    dbg.WriteText("Error: " + e.Message + "; Lin: " + e.Exception.LineNumber + " Col: " + e.Exception.LinePosition);
                    _xmlValidationErrors++;
                    break;
                case XmlSeverityType.Warning:
                    dbg.WriteText("Warning: " + e.Message + "; Lin: " + e.Exception.LineNumber + " Col: " + e.Exception.LinePosition);
                    break;
            }

        }

        public void ValidateXmlSchema(String fileName)
        {
            _xmlValidationErrors = 0;
            // Set the validation settings.
            var settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add("gammodprofile", @"Data\Gammod.profile.xsd");
            //settings.ValidationFlags |= XmlSchemaValidationFlags.ProcessInlineSchema;
            settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
            settings.ValidationEventHandler += ValidationHandler;
            // Create the XmlReader object.
            XmlReader reader = XmlReader.Create(fileName, settings);
            // Parse the file. 
            try
            {
                while (reader.Read()) ;
            }
            catch (Exception ex)
            {
                reader.Close();
                throw ex;
            }
            reader.Close();
        }

        #endregion

        #region MetroCustomTile Paint Events
        private void metroTileCustom_CustomPaint(object sender, MetroPaintEventArgs e)
        {
            var m = (MetroTileCustom)sender;
            var table = (DataTable)metroGrid1.DataSource;
            if (table.Rows[m.TileCount - 1] == null)
            {
                return;
            }

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            TextFormatFlags flags = /*MetroPaint.GetTextFormatFlags(base.TextAlign) |*/ TextFormatFlags.LeftAndRightPadding | TextFormatFlags.EndEllipsis;
            Rectangle textRectangle = ClientRectangle;
            if (m.IsPressed)
            {
                textRectangle.Inflate(-2, -2);
            }

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // draw tile count
            TextRenderer.DrawText(e.Graphics, m.TileCount.ToString(), MetroFonts.TileCount, new Point(m.Width - TextRenderer.MeasureText(m.TileCount.ToString(), MetroFonts.TileCount).Width, 0), MetroPaint.ForeColor.Tile.Normal(Theme));
            // draw the main title
            var f = new Font(m.Font.FontFamily, 20);
            TextRenderer.DrawText(e.Graphics, m.Text, f, textRectangle, MetroPaint.ForeColor.Tile.Normal(Theme), flags);
            // draw the description
            Size s = TextRenderer.MeasureText(m.Text, f);
            textRectangle.Y = s.Height + ((m.IsPressed) ? 4 : 2);
            textRectangle.X = ((m.IsPressed) ? 8 : 6);

            TextRenderer.DrawText(e.Graphics, table.Rows[m.TileCount - 1][2].ToString(), m.Font, textRectangle, MetroPaint.ForeColor.Tile.Normal(Theme), flags);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        }

        private void metroTileCustom_CustomPaintBackground(object sender, MetroPaintEventArgs e)
        {
            var m = (MetroTileCustom)sender;
            e.Graphics.Clear(e.BackColor);
            if (m.IsHovered)
            {
                var hslColor = new HSLColor(e.BackColor);
                hslColor.Luminosity *= 0.8; // 0 to 1
                e.Graphics.Clear(hslColor);
            }
            if (m.IsFocused)
            {
                var hslColor = new HSLColor(e.BackColor);
                hslColor.Luminosity *= 0.4; // 0 to 1
                e.Graphics.Clear(hslColor);
            }
        }

        private void metroTileCustom_Enter(object sender, EventArgs e)
        {
            currentTileCustom = (MetroTileCustom)sender;
            var table = (DataTable)metroGrid1.DataSource;
            if (table.Rows.Count <= 0)
                return;
            metroTextBox5.Text = currentTileCustom.Text;
            metroTextBox6.Text = table.Rows[currentTileCustom.TileCount - 1][1].ToString();
            metroTextBox7.Text = table.Rows[currentTileCustom.TileCount - 1][2].ToString();
        }

        private void metroTileCustom_Leave(object sender, EventArgs e)
        {
            currentTileCustom = null;
            metroTextBox5.Text = "";
            metroTextBox6.Text = "";
            metroTextBox7.Text = "";
        }

        #endregion

        private void DirSearch(String dir, String pattern, DataTable table)
        {
            dbg.Enter();
            try
            {
                foreach (String f in Directory.GetFiles(dir, pattern))
                {
                    DataRow r = table.NewRow();
                    FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(f);
                    r[0] = Path.GetFileNameWithoutExtension(f) + ((versionInfo.FileVersion == string.Empty) ? "" : " v" + versionInfo.FileVersion);
                    r[1] = f;
                    r[2] = (versionInfo.FileDescription == string.Empty) ? "This program is called " + Path.GetFileNameWithoutExtension(f) : versionInfo.FileDescription;
                    //r[2] = Path.GetFileNameWithoutExtension(f);
                    table.Rows.Add(r);
                    dbg.WriteText(MethodBase.GetCurrentMethod().Name, 1, f);
                }
                foreach (String d in Directory.GetDirectories(dir))
                    DirSearch(d, pattern, table);

            }
            catch (Exception e)
            {
                MetroMessageBox.Show(this, e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dbg.Exit();
        }

        // SelectFolder button Click event
        private void metroButton_SelectFolder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = System.Environment.CurrentDirectory;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                metroTextBox9.Text = folderBrowserDialog1.SelectedPath;
                var table = (DataTable)metroGrid1.DataSource;

                metroGrid1.DataSource = null;
                table.Clear();
                DirSearch(folderBrowserDialog1.SelectedPath, "*.exe", table);
                metroGrid1.DataSource = table;

                table.WriteXml(Application.StartupPath + @dataFile, XmlWriteMode.WriteSchema, true);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            metroToggleDebug.Checked = (bool)Settings.Default["Debug"];
            metroToggleDebug_CheckedChanged(metroToggleDebug, null);

            // force the current style so all Metro controls get updated
            metroStyleManager.Style = (MetroColorStyle)Settings.Default["MetroColor"];
            metroStyleManager.Theme = (MetroThemeStyle)Settings.Default["MetroStyle"];
        }

        #region MetroPanel Scrolling - Not used

        /**
         * How to ask control to scroll using C#
         * http://weblogs.asp.net/israelio/188664
         */

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        private const int WM_SCROLL = 276; // Horizontal scroll
        private const int WM_VSCROLL = 277; // Vertical scroll
        private const int SB_LINEUP = 0; // Scrolls one line up
        private const int SB_LINELEFT = 0;// Scrolls one cell left
        private const int SB_LINEDOWN = 1; // Scrolls one line down
        private const int SB_LINERIGHT = 1;// Scrolls one cell right
        private const int SB_PAGEUP = 2; // Scrolls one page up
        private const int SB_PAGELEFT = 2;// Scrolls one page left
        private const int SB_PAGEDOWN = 3; // Scrolls one page down
        private const int SB_PAGERIGTH = 3; // Scrolls one page right
        private const int SB_PAGETOP = 6; // Scrolls to the upper left
        private const int SB_LEFT = 6; // Scrolls to the left
        private const int SB_PAGEBOTTOM = 7; // Scrolls to the upper right
        private const int SB_RIGHT = 7; // Scrolls to the right
        private const int SB_ENDSCROLL = 8; // Ends scroll

        private void metroScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            debugForm.RichTextBox1.AppendText("new: " + e.NewValue + ", old: " + e.OldValue + "type: " + e.Type + Environment.NewLine);
            debugForm.RichTextBox1.ScrollToCaret();

            /*Control c;
            c.Location = new Point(c.Left,
                    (metroPanel2.Height - c.Height)*metroScrollBar2.Value/
                    (metroScrollBar2.Maximum - metroScrollBar2.LargeChange + 1)));*/

            //metroPanel2.ScrollControlIntoView(metroPanel2.GetChildAtPoint());

            /*if (e.NewValue < e.OldValue)
                SendMessage(metroPanel2.Handle, WM_VSCROLL, (IntPtr)SB_LINEUP, metroScrollBar2.Handle);
            else
                SendMessage(metroPanel2.Handle, WM_VSCROLL, (IntPtr)SB_LINEDOWN, metroScrollBar2.Handle);
            SendMessage(metroPanel2.Handle, WM_VSCROLL, (IntPtr)SB_ENDSCROLL, metroScrollBar2.Handle);*/
        }

        #endregion

        private void MainForm_Move(object sender, EventArgs e)
        {
            if (debugForm != null)
            {
                debugForm.Left = Left;
                debugForm.Top = Bottom;
            }
        }

        private void metroGrid1_CustomPaint(object sender, MetroPaintEventArgs e)
        {

            dbg.WriteText(MethodBase.GetCurrentMethod().Name, sender.GetType().ToString());
            //dbg.DebugEnabled = false;
            //TextRenderer.DrawText(e.Graphics, m.TileCount.ToString(), MetroFonts.TileCount, new Point(m.Width - TextRenderer.MeasureText(m.TileCount.ToString(), MetroFonts.TileCount).Width, 0), MetroPaint.ForeColor.Tile.Normal(Theme));
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null)
                return;
            dbg.WriteText("Index: " + (sender as MetroTabControl).SelectedIndex.ToString());
            if ((sender as MetroTabControl).SelectedTab == metroTabPage5)
            {
                int i = 0;
                metroComboBoxOriginGames.Items.Clear();
                try
                {
                    List<string> dirs = new List<string>(Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\Origin\\LocalContent"));
                    foreach (var dir in dirs)
                        metroComboBoxOriginGames.Items.Add(dir.Substring(dir.LastIndexOf(@"\") + 1));
                    i = dirs.Count;
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                metroComboBoxOriginGames.Items.Insert(0, " **** " + i + " game(s) **** ");
                metroComboBoxOriginGames.SelectedIndex = 0;
            }

        }

        private void metroComboBoxOriginGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbg.Enter();
            _currentGame.RemoveAll();
            metroComboBoxOriginProfile.Items.Clear();
            int i = 0;
            if (metroComboBoxOriginGames.SelectedIndex < 1)
                goto theend;
            String profileXmlFile = @"data\" + metroComboBoxOriginGames.Items[metroComboBoxOriginGames.SelectedIndex] + ".profiles.xml";
            if (!System.IO.File.Exists(profileXmlFile))
                goto theend;
            try
            {
                ValidateXmlSchema(profileXmlFile);
                dbg.WriteText("_xmlValidationErrors=" + _xmlValidationErrors);
                if (_xmlValidationErrors > 0)
                    throw new Exception("failed.");
                _currentGame.Load(profileXmlFile);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Validation for " + profileXmlFile + "\n" + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                goto theend;
            }
            foreach (XmlNode profile in _currentGame.LastChild.ChildNodes)
            {
                if (profile.Name.Equals("profile"))
                {
                    i++;
                    if (profile.Attributes["profileName"] != null)
                        metroComboBoxOriginProfile.Items.Add(profile.Attributes["profileName"].Value);
                }
            }
        theend:
            metroComboBoxOriginProfile.Items.Insert(0, " **** " + i + " profile(s) **** ");
            metroComboBoxOriginProfile.SelectedIndex = 0;
            dbg.Exit();
        }

        #region Macros

        /**
         * Macro to get the list of languages available for the selected game
         **/
        private void OriginGameLanguages(String gameName, XmlDocument gameData)
        {
            var list = (List<KeyValuePair<String, String>>)ExtractOriginInstallerValue(gameData, OriginInstValType.langList);
            if (list == null)
                return;
            var metroLabel = new MetroLabel();
            metroPanel4.Controls.Add(metroLabel);
            metroLabel.Left = metroPanel4.Left + 1;
            metroLabel.Top = _verticalPos + 10;
            metroLabel.Text = @"Languages";
            var metroComboBox = new MetroComboBox();
            metroPanel4.Controls.Add(metroComboBox);
            metroComboBox.Left = metroLabel.Left + metroLabel.Width + 1;
            metroComboBox.Top = metroLabel.Top - 1;
            metroComboBox.Name = "macro.originGameLanguages.OriginGameLanguagesList";
            _verticalPos = metroComboBox.Top + metroComboBox.Height;
            metroPanel4.AutoScroll = true;
            foreach (KeyValuePair<String, String> kv in list)
            {
                dbg.WriteText(kv.Key + "=" + kv.Value);
                metroComboBox.Items.Add(kv.Key);
                if (kv.Key.ToLower().Equals("en_us"))
                    metroComboBox.SelectedIndex = metroComboBox.Items.Count - 1;
            }
        }

        #endregion

        /**
         * Gimmick function for .NET 2.0 to assert wether the current Windows is 64 bit
         * */
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process([In] IntPtr hProcess, [Out] out bool lpSystemInfo);
        private bool Is32BitProcessOn64BitProcessor()
        {
            bool retVal;
            IsWow64Process(Process.GetCurrentProcess().Handle, out retVal);
            return retVal;
        }
        private bool Is64Bit()
        {
            return (IntPtr.Size == 8 || (IntPtr.Size == 4 && Is32BitProcessOn64BitProcessor()));
        }

        /**
         * Extract various values from the Origin installer xml
         * */
        private Object ExtractOriginInstallerValue(XmlDocument gameData, OriginInstValType valueType)
        {
            foreach (XmlNode settings in gameData.LastChild.ChildNodes)
            {
                switch (valueType)
                {
                    case OriginInstValType.uninstallPath:
                        if (settings.Name.Equals("uninstall"))
                            foreach (XmlNode element in settings.ChildNodes)
                                if (element.Name.Equals("path"))
                                    return element.InnerText;
                        break;
                    case OriginInstValType.registryPath:
                    case OriginInstValType.langList:
                        if (settings.Name.Equals("runtime"))
                            foreach (XmlNode element1 in settings.ChildNodes)
                                if (element1.Name.Equals("launcher"))
                                {
                                    var list = new List<KeyValuePair<String, String>>();
                                    bool correctList = false;
                                    foreach (XmlNode element2 in element1.ChildNodes)
                                        if (element2.Name.Equals("filePath") && valueType == OriginInstValType.registryPath)
                                        {
                                            dbg.WriteText(element2.InnerText);
                                            return element2.InnerText;
                                        }
                                        else if (element2.Name.Equals("name"))
                                        {
                                            var langPair = new KeyValuePair<string, string>(element2.Attributes["locale"].Value, element2.InnerText);
                                            list.Add(langPair);
                                        }
                                        else if ((element2.Name.Equals("requires64BitOS")) && (element2.InnerText.Equals("1")) && (Is64Bit()))
                                        {
                                            correctList = true;
                                        }
                                    if (correctList)
                                    {
                                        dbg.WriteText("Found " + list.Count + " languages");
                                        return list;
                                    }
                                }
                        break;
                }
            }
            return null;
        }

        /**
         * Load the __Installer\\installerdata.xml file present in all Origin game folders
         * */
        private XmlDocument GetOriginGameInstallInfo(String gameName)
        {
            String originGamesDir = null;
            XmlDocument installerData = null;
            var originXml = new XmlDocument();
            try
            {
                String originXmlFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                             @"\Origin\local.xml";
                originXml.Load(originXmlFile);
                dbg.WriteText("originXmlFile=" + originXmlFile);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            foreach (XmlNode settings in originXml.LastChild.ChildNodes)
            {
                String key = ((settings.Attributes["key"] == null) ? "" : settings.Attributes["key"].Value);
                if (key.Equals("DownloadInPlaceDir"))
                {
                    originGamesDir = settings.Attributes["value"].Value;
                    dbg.WriteText("Got originGamesDir=" + originGamesDir);
                    break;
                }
            }
            if (originGamesDir != null)
                if (System.IO.Directory.Exists(originGamesDir + gameName))
                {
                    installerData = new XmlDocument();
                    try
                    {
                        String file = originGamesDir + gameName + @"\__Installer\installerdata.xml";
                        installerData.Load(@file);
                        dbg.WriteText("Origin Installer Data File=" + @file);
                    }
                    catch (Exception ex)
                    {
                        MetroMessageBox.Show(this, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            return installerData;
        }

        private String ReplaceSpecialVariable(Control parent, String varName)
        {
            // Cycle through all controls to match the varName
            foreach (Control control in parent.Controls)
                if (control.Name.Equals(varName))
                    return control.Text;
            return "";
        }

        #region actions

        /**
        * Execute action Registry
        * */
        private void ExecuteActionRegistry(String regHive, String regKey, String regEntryName, String regEntryType, bool regDelete, XmlNodeList values)
        {
            dbg.Enter();
            if (regHive.Equals("") || regKey.Equals(""))
                goto theend;
            // open the registry hive
            RegistryKey hive = null;
            switch (regHive)
            {
                case "HKEY_LOCAL_MACHINE":
                    hive = Registry.LocalMachine;
                    break;
                case "HKEY_CURRENT_USER":
                    hive = Registry.CurrentUser;
                    break;
                case "HKEY_USERS":
                    hive = Registry.Users;
                    break;
            }
            if (hive == null)
                throw new Exception("Invalid registry hive: " + regHive);
            // processing deletion
            if (regDelete)
            {
                try
                {
                    String msg = "Are you sure you want to delete ";
                    if (!regEntryName.Equals(""))
                        msg += "entry [" + regEntryName + "] from";
                    else
                        msg += "key";
                    if (MetroMessageBox.Show(this, msg + " \n" + regHive + @"\" + regKey + " ?", "Warning",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        dbg.WriteText("Deleting " + (!regEntryName.Equals("") ? "entry [" + regEntryName + "] from " : "key ") + regHive + @"\" + regKey);
                        if (!regEntryName.Equals(""))
                            hive.OpenSubKey(regKey, true).DeleteValue(regEntryName);
                        else
                            hive.DeleteSubKeyTree(regKey);
                    }
                }
                catch (Exception ex)
                {
                    dbg.WriteText("Exception", " deleting " + (!regEntryName.Equals("") ? "\"" + regEntryName + "\" from " : "") + regHive + @"\" + regKey + ", " + ex.Message + ": " + new Win32Exception(Marshal.GetLastWin32Error()).Message, 1);
                }
            }
            else //if (regDelete)
            {
                try
                {
                    // create the key
                    hive.CreateSubKey(regKey);
                }
                catch (Exception ex)
                {
                    // if already exists, can be safely ignored
                    dbg.WriteText("Exception creating " + regHive + @"\" + regKey + ": " + ex.Message, 1);
                }

                // set the value type
                var valueKind = RegistryValueKind.String;
                switch (regEntryType)
                {
                    case "REG_BINARY":
                        valueKind = RegistryValueKind.Binary;
                        break;
                    case "REG_DWORD":
                        valueKind = RegistryValueKind.DWord;
                        break;
                    case "REG_EXPAND_SZ":
                        valueKind = RegistryValueKind.ExpandString;
                        break;
                    case "REG_MULTI_SZ":
                        valueKind = RegistryValueKind.MultiString;
                        break;
                    default:
                        valueKind = RegistryValueKind.String;
                        break;
                }

                // open the registry key
                RegistryKey reg = null;
                try
                {
                    reg = hive.OpenSubKey(regKey, true);
                }
                catch (Exception ex)
                {
                    dbg.WriteText("Exception opening " + regHive + @"\" + regKey + ", " + ex.Message + ": " + new Win32Exception(Marshal.GetLastWin32Error()).Message, 1);
                    return; // silently exit or throw exception and stop the whole thing?
                }
                // get the values from the profile and concatenate them
                String regValue = "";
                foreach (XmlNode value in values)
                {
                    // first, replace special variables enclosed in ${...}
                    MatchCollection matchList = Regex.Matches(value.InnerText, @"\$\{(.*?)\}");
                    foreach (Match match in matchList)
                    {
                        dbg.WriteText(match.Groups[1].Value, 2);
                        value.InnerText = value.InnerText.Replace("${" + match.Groups[1].Value + "}",
                            ReplaceSpecialVariable(metroPanel4, match.Groups[1].Value));
                    }
                    // second, apply regex on the value read from the registry key if "pattern" attribute is not empty
                    String patt = (value.Attributes["pattern"] != null) ? value.Attributes["pattern"].Value : "";
                    String regexOpts = (value.Attributes["regexOptions"] != null) ? value.Attributes["regexOptions"].Value : "";
                    if (!patt.Equals(""))
                    {
                        Regex r = new Regex(patt);
                        // get the current value from registry to be replaced
                        bool valueObtained = false;
                        switch (reg.GetValueKind(regEntryName))
                        {
                            case RegistryValueKind.String:
                            case RegistryValueKind.ExpandString:
                            case RegistryValueKind.MultiString:
                                try
                                {
                                    value.InnerText = r.Replace(reg.GetValue(regEntryName).ToString(),
                                        value.InnerText ?? "");
                                }
                                catch (Exception ex)
                                {
                                    dbg.WriteText("Exception reading " + regEntryName + ", " + ex.Message + ": " + new Win32Exception(Marshal.GetLastWin32Error()).Message, 1);
                                }
                                break;
                        }
                        if (!valueObtained)
                            value.InnerText = value.InnerText ?? "";
                    }
                    else
                        regValue += value.InnerText;
                }
                // write the new value to the registry entry
                if (!regValue.Equals(""))
                {
                    try
                    {
                        dbg.WriteText("Writing " + regEntryName + "=" + regValue);
                        reg.SetValue(regEntryName, regValue, valueKind);
                    }
                    catch (Exception ex)
                    {
                        dbg.WriteText("Exception: " + ex.Message + ": " + new Win32Exception(Marshal.GetLastWin32Error()).Message, 1);
                    }
                }
                reg.Close();
            }
        theend:
            dbg.Exit();
        }

        /**
        * Execute action File
        * */
        private void ExecuteActionFile()
        {
            dbg.Enter();

        }

        /**
        * Execute action Copy
        * */
        private void ExecuteActionCopy()
        {
            dbg.Enter();

        }

        /**
        * Execute action Delete
        * */
        private void ExecuteActionDelete()
        {
            dbg.Enter();

        }

        /**
        * Execute action Command
        * */
        private void ExecuteActionCommand()
        {
            dbg.Enter();

        }

        /**
         * Execute all the macros and special functions
         * */
        private void ExecuteActionMacro(String macroName, String gameName, XmlDocument gameData, XmlNodeList parameterList)
        {
            dbg.Enter();
            switch (macroName)
            {
                case "originGameLanguages":
                    OriginGameLanguages(@gameName, @gameData);
                    break;
            }
        }

        /**
         * Execute all the action from the XML Profile
         * */
        private void ExecuteActions(XmlNode profileActions, String gameName, bool initial)
        {
            dbg.Enter();
            if (profileActions == null)
                return;
            // Get Origin Game Data
            XmlDocument gameData = GetOriginGameInstallInfo(@gameName);
            if (gameData == null)
                return;
            foreach (XmlNode action in profileActions.ChildNodes)
            {
                if (!action.Name.Equals("action"))
                    continue;

                dbg.WriteText("actionId: " + ((action.Attributes["actionId"] == null) ? "" : action.Attributes["actionId"].Value));
                dbg.WriteText("createUserField: " + ((action.Attributes["createUserField"] == null) ? "" : action.Attributes["createUserField"].Value));
                dbg.WriteText("description: " + ((action.Attributes["description"] == null) ? "" : action.Attributes["description"].Value));
                dbg.WriteText("dependsOn: " + ((action.Attributes["dependsOn"] == null) ? "" : action.Attributes["dependsOn"].Value));

                bool autorun = (action.Attributes["autorun"] == null) ? false : Boolean.Parse(action.Attributes["autorun"].Value);
                dbg.WriteText("Autorun: " + autorun);

                if ((autorun && initial) || (!autorun && !initial))
                    foreach (XmlNode actionType in action)
                    {
                        dbg.WriteText("Executing actionType: " + actionType.Name, 1);
                        switch (actionType.Name)
                        {
                            case "registry":
                                String regHive = (actionType.Attributes["hive"] == null)
                                    ? ""
                                    : actionType.Attributes["hive"].Value;
                                String regKey = (actionType.Attributes["key"] == null)
                                    ? ""
                                    : actionType.Attributes["key"].Value;
                                String regEntryName = (actionType.Attributes["entryName"] == null)
                                    ? ""
                                    : actionType.Attributes["entryName"].Value;
                                String regEntryType = (actionType.Attributes["entryType"] == null)
                                    ? ""
                                    : actionType.Attributes["entryType"].Value;
                                bool regDelete = (actionType.Attributes["delete"] != null) && Boolean.Parse(actionType.Attributes["delete"].Value);
                                ExecuteActionRegistry(regHive, regKey, regEntryName, regEntryType, regDelete, actionType.ChildNodes);
                                break;
                            case "file":
                                ExecuteActionFile();
                                break;
                            case "macro":
                                String macroName = (actionType.Attributes["macroName"] == null)
                                    ? ""
                                    : actionType.Attributes["macroName"].Value;
                                dbg.WriteText("Macro: " + macroName, 1);
                                ExecuteActionMacro(macroName, gameName, gameData, actionType.ChildNodes);
                                break;
                            case "copy":
                                ExecuteActionCopy();
                                break;
                            case "delete":
                                ExecuteActionDelete();
                                break;
                            case "command":
                                ExecuteActionCommand();
                                break;
                        }
                    }
            }
        }

        #endregion

        private void metroComboBoxOriginProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            dbg.Enter();
            metroButtonOriginApply.Enabled = false;
            var combo = (sender as MetroComboBox);
            if (combo == null)
                return;
            metroButtonOriginApply.Enabled = combo.SelectedIndex > 0;
            metroLabelProfileDetails.Text = "";
            //destroy all controls in the child panel
            ClearControls(metroPanel4);
            _verticalPos = 0;
            if ((combo.SelectedIndex < 1) || (_currentGame.LastChild == null))
                return;
            foreach (XmlNode profile in _currentGame.LastChild.ChildNodes)
                if (profile.Name.Equals("profile"))
                {
                    XmlAttribute profileNameAttribute = profile.Attributes["profileName"];
                    if (profileNameAttribute == null)
                        return;
                    if (profileNameAttribute.Value.Equals(combo.SelectedItem))
                    {
                        dbg.WriteText(profile.Name + "=" + profileNameAttribute.Value);
                        _currentProfile = profile;
                        foreach (XmlNode profileDetails in profile.ChildNodes)
                        {
                            switch (profileDetails.Name)
                            {
                                case "description":
                                    metroLabelProfileDetails.Text = profileDetails.InnerText;
                                    break;
                                case "actions":
                                    ExecuteActions(profileDetails, metroComboBoxOriginGames.SelectedItem.ToString(), true);
                                    break;
                            }
                        }
                    }
                }
            // set the vertical scrollbar
            var vScrollBar1 = new MetroScrollBar {Orientation = MetroScrollOrientation.Vertical, Dock = DockStyle.Right};
            vScrollBar1.Scroll += (a, b) => { metroPanel4.VerticalScroll.Value = vScrollBar1.Value; };
            metroPanel4.Controls.Add(vScrollBar1);
            //metroPanel4.VerticalScroll.Enabled = true;
            //metroPanel4.AutoScroll = true;
        }


        private void metroComboBox4_ValueMemberChanged(object sender, EventArgs e)
        {
            dbg.WriteText(sender.GetType().FullName + e.ToString());
        }


        /**
         * Toggling the Debug functionality
         * */
        private void metroToggleDebug_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as MetroToggle).Checked)
            {
                if (debugForm == null)
                    debugForm = new DebugForm(this);
                if (dbg == null)
                    dbg = new Debugger(debugForm.RichTextBox1);
                debugForm.Top = Bottom;
                debugForm.Left = Left;
                debugForm.Width = Width;
                debugForm.Show();
                dbg.AssignControl(debugForm.RichTextBox1);
                dbg.DebugEnabled = true;
            }
            else
            {
                if (debugForm != null)
                    debugForm.Hide();
                dbg.DebugEnabled = false;
            }
            Settings.Default["Debug"] = (sender as MetroToggle).Checked;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        /**
         * Apply the selected profile
         * */
        private void metroButtonOriginApply_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (XmlNode profileDetails in _currentProfile.ChildNodes)
                    if (profileDetails.Name.Equals("actions"))
                    {
                        // execute only the actions NOT marked as "autorun"
                        ExecuteActions(profileDetails, metroComboBoxOriginGames.SelectedItem.ToString(), false);
                    }
                MetroMessageBox.Show(this, "Profile [" + metroComboBoxOriginProfile.Text + "] has been applied!", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Profile [" + metroComboBoxOriginProfile.Text + "] failed to be applied!\n" + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroLink3_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.google.com");
        }






    }
}
