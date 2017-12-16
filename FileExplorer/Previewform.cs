using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileExplorer
{
    public partial class Previewform : Form
    {
        Form1 parent;
        public Previewform(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
            parent.Resize += ParentUpdate;
            parent.Move += ParentUpdate;
        }
        private void ParentUpdate(object sender, EventArgs e)
        {
            Height = parent.Height;
            Top = parent.Top;
            Left = parent.Left + parent.Width - 10;
            MaximumSize = new Size(1000, parent.Height);
            MinimumSize = new Size(0, parent.Height);
        }

        private void Previewform_Load(object sender, EventArgs e)
        {
            ParentUpdate(null, null);
        }

        public void PrintHexDump(byte[] buff)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"0x{"0",-6}: ");
            for (int i = 1; i < buff.Length + 1; i++)
            {
                sb.Append( $"{buff[i - 1].ToString("X2") } ");
                if (i % 16 == 0)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append($"0x{i.ToString("X2"),-6}: ");
                }
            }
            hex_prev_txt.Text = sb.ToString();
        }
    }
}
