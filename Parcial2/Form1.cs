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
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Layout.Properties;
using iText.IO.Image;

namespace Parcial2
{

       
    public partial class Planilla : Form
    {
        MySqlConnection conexion = new MySqlConnection("server=server; Database = db; Uid= id; Pwd= pwd;");

        public Planilla()
        {
            InitializeComponent();
            actualizar();
            actualiza();
            refreh(); 
            //this.reportViewer1.RefreshReport();
        }

        private void contactsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
         

        }

        private void Form1_Load(object sender, EventArgs e)
        {






           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ConectarBD_Click(object sender, EventArgs e)
        {
           

            
           try{
                conexion.Open();
                MessageBox.Show("Conectados");
                conexion.Close();
          
           }
            catch (Exception)
           {
               throw;
           }
        }
        public void refreh()
        {
            mostrar_turno();
        }
       
        public void actualizar()
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("Select * from usuario", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Turnos.DataSource = tabla;
            conexion.Close();
        }

        public void actualiza()
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("Select * from turnos", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Turno.DataSource = tabla;
            conexion.Close();
        }

        //Refrescar Usuario
        private void RefrescarT_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("Select * from usuario", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Turnos.DataSource = tabla;
            conexion.Close();
        }

        //Baja Usuario
        private void BajaT_Click(object sender, EventArgs e)
        {

            conexion.Open();

            int di = int.Parse(Turnos.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand sqlCMD = new MySqlCommand("delete from usuario where id=" + di, conexion);
            sqlCMD.Parameters.AddWithValue("@id", di);
            sqlCMD.ExecuteNonQuery();
            conexion.Close();
            actualizar();
        }

        //Alta Usuario
        private void button6_Click(object sender, EventArgs e)
        {
            Form2 alt = new Form2(null);
            alt.ShowDialog();
            actualizar();
        }

        //Modificar Usuario
        private void button5_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Turnos.CurrentRow.Cells[0].Value.ToString());
            Form2 alt = new Form2(id);
            alt.ShowDialog();
            actualizar();
        }

        private void Turno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            actualiza();
        }


        //Refrescar Turnos
        private void refresh_Click(object sender, EventArgs e)
        {
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("Select * from turnos", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);
            Turno.DataSource = tabla;
            conexion.Close();

        }

        //DataGridView Usuario
        private void Turnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = Turnos.Rows[0];
            row.Height = 15;
        }

        private void HistoriaClinica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = HistoriaClinica.Rows[0];
           // row.Height = 15;

        }
        
      
        public void mostrar_turno()
        {
            conexion.Open();
            /*
            MySqlCommand comand = new MySqlCommand("Select id, nombre, apellido, dni, obra_social, telefono from usuario", conexion);
            MySqlDataAdapter adapt = new MySqlDataAdapter();*/
            //adapt.SelectCommand = comand;
            DataTable table = new DataTable();
            //adapt.Fill(table);
            

            MySqlCommand coman = new MySqlCommand("Select * from turnos", conexion);
            MySqlDataAdapter adapta = new MySqlDataAdapter();
            adapta.SelectCommand = coman;
           
            adapta.Fill(table);
            Turno.DataSource = table;
            conexion.Close();
        }

        private void refresco_Click(object sender, EventArgs e)
        {
            mostrar_turno();
            
        }

        //Alta Turno
        private void button8_Click(object sender, EventArgs e)
        {
            Form3 alt = new Form3(null);
            alt.ShowDialog();
            actualiza();
        }

        //Modificar Turno
        private void button7_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Turno.CurrentRow.Cells[0].Value.ToString());
            Form3 alt = new Form3(id);
            alt.ShowDialog();
            actualiza();
        }

        //Baja Turno
        private void button4_Click(object sender, EventArgs e)
        {
            conexion.Open();

            int iden = int.Parse(Turno.CurrentRow.Cells[0].Value.ToString());
            MySqlCommand sqlCMD = new MySqlCommand("delete from turnos where id=" + iden, conexion);
            sqlCMD.Parameters.AddWithValue("@id", iden);
            sqlCMD.ExecuteNonQuery();
            conexion.Close();
            actualiza();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();
            int idaceptar = int.Parse(Turno.CurrentRow.Cells[0].Value.ToString());
            String presta = "Aceptado";
            string dato = "UPDATE turnos SET estado=' " + presta + "'";
            MySqlCommand sqlCMD = new MySqlCommand(dato, conexion);
            //alt.ShowDialog();
            sqlCMD.ExecuteNonQuery();
            MessageBox.Show("Turno Guardado");
            conexion.Close();
            actualiza();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int idc = int.Parse(Turnos.CurrentRow.Cells[0].Value.ToString()); ;
            
            crearPDF(idc);
            //actualiza();
            Form4 alt = new Form4();
            alt.ShowDialog();
        }

        private void crearPDF(int idc)
        {


            PdfWriter pdfWriter = new PdfWriter("Clinica.pdf");
            PdfDocument pdf = new PdfDocument(pdfWriter);
            Document documento = new Document(pdf, PageSize.LETTER);

            documento.SetMargins(60, 20, 55, 20);

            PdfFont fontColumnas = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont fontContenido = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            conexion.Open();

            var espacio = new Paragraph(" ");
            espacio.SetFontSize(12);
            documento.Add(espacio);

            string consulta = "SELECT nombre, apellido, dni, fecha, email, telefono, obra_social FROM usuario WHERE id=" + idc;
            MySqlCommand consultaCMD = new MySqlCommand(consulta, conexion);
            MySqlDataReader leer = consultaCMD.ExecuteReader();

            while (leer.Read()) { 
                var dni = new Paragraph("DNI: " + leer["dni"].ToString());
                dni.SetFontSize(12);
                documento.Add(dni);
            
                var nombre = new Paragraph("Nombre: " + leer["nombre"].ToString());
                nombre.SetFontSize(12);
                documento.Add(nombre);
            
                var apellido = new Paragraph("Apellido: " + leer["apellido"].ToString());
                apellido.SetFontSize(12);
                documento.Add(apellido);

                var fechausuario = new Paragraph("Fecha de Nacimiento: " + leer["fecha"].ToString());
                fechausuario.SetFontSize(12);
                documento.Add(fechausuario);

                var email = new Paragraph("Email: " + leer["email"].ToString());
                email.SetFontSize(12);
                documento.Add(email);

                var telefono = new Paragraph("Telefono: " + leer["Telefono"].ToString());
                telefono.SetFontSize(12);
                documento.Add(telefono);

                var obra = new Paragraph("Obra Social: " + leer["obra_social"].ToString());
                obra.SetFontSize(12);
                documento.Add(obra);

            }
            conexion.Close();

            string[] columnas = { "PRESTACION", "FECHA", "HORA"};

            float[] tamanos = { 4, 4, 2 };
            Table tabla = new Table(UnitValue.CreatePercentArray(tamanos));

            tabla.SetWidth(UnitValue.CreatePercentValue(100));

            foreach (string columna in columnas) {

                tabla.AddHeaderCell(new Cell().Add(new Paragraph(columna).SetFont(fontColumnas)));

            }

            
            conexion.Open();
            string dato = "SELECT prestacion, fecha_turno, hora FROM turnos WHERE id_usuario=" + idc;
            MySqlCommand sqlCMD = new MySqlCommand(dato, conexion);
            MySqlDataReader reader = sqlCMD.ExecuteReader();

            while (reader.Read()) {

                tabla.AddCell(new Cell().Add(new Paragraph(reader["prestacion"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["fecha_turno"].ToString()).SetFont(fontContenido)));
                tabla.AddCell(new Cell().Add(new Paragraph(reader["hora"].ToString()).SetFont(fontContenido)));

            }

            documento.Add(tabla);
            documento.Close();
            
            var logo = new iText.Layout.Element.Image(ImageDataFactory.Create("C:/xampp/htdocs/sonrisa/img/logosonrisa.png")).SetWidth(50);
            var plogo = new Paragraph("").Add(logo);
            var titulo = new Paragraph("Historia Clinica");
            titulo.SetTextAlignment(TextAlignment.CENTER);
            titulo.SetFontSize(12);

            var dfecha = DateTime.Now.ToString("dd-MM-yyyy");
            var dhora = DateTime.Now.ToString("hh:mm:ss");
            var fecha = new Paragraph("Fecha: " + dfecha + "\nHora: " + dhora);
            fecha.SetFontSize(12);

            PdfDocument pdfDoc = new PdfDocument(new PdfReader("Clinica.pdf"),new PdfWriter("HistoriaClinica.pdf"));
            Document doc = new Document(pdfDoc);

            int numero = pdfDoc.GetNumberOfPages();
            for (int i=1;i <= numero; i++) { 
                PdfPage pagina = pdfDoc.GetPage(i);

                float y = (pdfDoc.GetPage(i).GetPageSize().GetTop() - 15);
                doc.ShowTextAligned(plogo, 40, y,i, TextAlignment.CENTER,VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(titulo, 150, y-15,i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);
                doc.ShowTextAligned(fecha, 520, y-15,i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

                doc.ShowTextAligned(new Paragraph(String.Format("Pagina {0} de {1}", i, numero)), pdfDoc.GetPage(i).GetPageSize().GetWidth() / 2, pdfDoc.GetPage(i).GetPageSize().GetBottom() + 30, i, TextAlignment.CENTER, VerticalAlignment.TOP, 0);

            }
            doc.Close();
        }

        public DataTable dtTurno() {

           
            DataTable tabla = new DataTable();
            
            conexion.Open();
            MySqlCommand comando = new MySqlCommand("Select * from turnos", conexion);
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            adaptador.SelectCommand = comando;
            
            adaptador.Fill(tabla);
            adaptador.Dispose();

            conexion.Close();

            return tabla;
        }
    }

      
        
}
