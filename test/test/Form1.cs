using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {



        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void text_Click(object sender, EventArgs e)
        {
            //Pass the file path and file name to the StreamReader constructor
            string line;
            StreamReader sr = new StreamReader("C:\\Users\\onlyo\\Music\\Synesthesia\\rgb.txt");

            //Read the first line of text
            line = sr.Read();
            MessageBox.Show(line);
            line = sr.ReadLine();
            //Continue to read until you reach end of file
            //while (line != null)
            //{
            //    //write the lie to console window
            //    Console.WriteLine(line);
            //    //Read the next line
            //    line = sr.ReadLine();
            //}

            //close the file
            sr.Close();
            Console.ReadLine();

            MessageBox.Show(line);
        }
    }
}
