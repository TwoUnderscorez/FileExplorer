using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FileExplorer
{
    public partial class NewFileDialog : Form
    {
        string ext;
        string dir;
        public NewFileDialog(string ext, string dir)
        {
            InitializeComponent();
            this.ext = ext;
            this.dir = dir;
            if (!string.IsNullOrEmpty(ext))
            {
                ext_txt.TextChanged += ext_txt_TextChanged;
            }
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ext_txt_TextChanged(object sender, EventArgs e)
        {
            ext_txt.Text = $".{ext}";
        }

        private void NewFileDialog_Load(object sender, EventArgs e)
        {
            ext_txt.Text = $".{ext}";
            if (ext == "\\")
            {
                Text = "New Folder";
                label1.Text = "Folder name:";
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = $"{dir}{filname_txt.Text}{ext_txt.Text}";
            try
            {
                if (ext == "\\")
                {
                    Directory.CreateDirectory(dir + filname_txt.Text);
                    Close();
                    return;
                }
                if (!File.Exists(path))
                    using (FileStream fs = File.Create(path)) { }
                Process.Start(path);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not complete the operation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }
    }
}
