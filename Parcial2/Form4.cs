using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;

namespace Parcial2
{
    public partial class Form4 : Form
    {
      
        public Form4()
        {
            InitializeComponent();
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            axAcroPDF1.src = "C:/Users/PC/Desktop/Programacion/CONSULTORIO/Parcial2/Parcial2/bin/Debug/HistoriaClinica.pdf";
        }

       
       
        
    }
}
