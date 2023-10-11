using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gaoyaxin
{
    public partial class Form2 : Form
    {
        string fullname;
        public Form2(string fullname1)
        {
            fullname = fullname1;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(fullname);
            label2.Text=fi.Name;
            label4.Text=fi.Extension;
            label6.Text=fi.FullName;

            long size= fi.Length;
            string sizestring;
            if (size < 1024) sizestring = size.ToString() + "Byte";
            else sizestring = (size / 1024).ToString() + "KB";

            label8.Text = sizestring;
            label10.Text=fi.CreationTime.ToString();
            label12.Text=fi.LastWriteTime.ToString();
        }
    }
}
