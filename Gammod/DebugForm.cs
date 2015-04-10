using System;
using System.IO;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Gammod
{
    public partial class DebugForm : Form
    {
        private MainForm _parent;
        public RichTextBox RichTextBox1
        {
            get { return richTextBox1; }
            set { richTextBox1 = value; }
        }

        public DebugForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "DebugOutput_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
            if (!saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
                return;
            try
            {
                Stream s = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                var w = new StreamWriter(s);
                w.Write(DateTime.Now + " " + Application.ProductName + " " + Application.ProductVersion);
                w.Flush();
                richTextBox1.SaveFile(s, RichTextBoxStreamType.PlainText);
                s.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void DebugForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Control c in _parent.Controls.Find("metroToggleDebug", true))
                ((MetroToggle)c).Checked = false;
            Hide();
            e.Cancel = true;
        }
    }
}
