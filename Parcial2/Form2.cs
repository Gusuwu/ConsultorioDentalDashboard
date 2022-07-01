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

namespace Parcial2
{
    public partial class Form2 : Form
    {
        int? id;
        MySqlConnection conexion = new MySqlConnection("server=bc0hlp84kblyxgwgnbv1-mysql.services.clever-cloud.com; Database = bc0hlp84kblyxgwgnbv1; Uid= utxfu6lpnbtjlwq7; Pwd= RZUdlvbtrHTCvKP1q1PO;");
        public Form2(int? id)
        {
            InitializeComponent();
            if (id != null)
            {
                    this.id = id;
                    cargarDatos();
            }
            try
            {
                conexion.Open();
                conexion.Close();

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void cargarDatos()
        {

            conexion.Open();
 
            MySqlCommand sqlCMD = new MySqlCommand("select * from usuario where id=@id", conexion);
            sqlCMD.Parameters.AddWithValue("@id", this.id);
            MySqlDataReader sqlDT = sqlCMD.ExecuteReader();

            while (sqlDT.Read())
            {

                email.Text = Convert.ToString(sqlDT["email"]);
                password.Text = Convert.ToString(sqlDT["contraseña"]);
                usuario.Text = Convert.ToString(sqlDT["usuario"]);
                nombre.Text = Convert.ToString(sqlDT["nombre"]);
                apellido.Text = Convert.ToString(sqlDT["apellido"]);
                DNI.Text = Convert.ToString(sqlDT["dni"]);
                telefono.Text = Convert.ToString(sqlDT["telefono"]);
                obra.Text = Convert.ToString(sqlDT["obra_social"]);
                fecha.Text = Convert.ToString(sqlDT["fecha"]);
                
            }

            conexion.Close();
           
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();

             if (id != null)
            {
               

                
                String emai = email.Text;
                String contr = password.Text;
                String usuar = usuario.Text;
                String nombr = nombre.Text;
                String apellid = apellido.Text;
                String dni = DNI.Text;
                String telefon = telefono.Text;
                String obras = obra.Text;
                String fech = fecha.Value.Date.ToString("yyyy-MM-dd");



                string dato = "UPDATE usuario SET email='" + emai + "', contraseña = '" + contr + "', usuario = '" + usuar + "', nombre =  '" + nombr + "', apellido= '" + apellid + "',dni='" + dni + "',telefono='" + telefon + "',obra_social= '" + obras + "',fecha= '" + fech + "' WHERE id="+id;

                MySqlCommand comando = new MySqlCommand(dato, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");
                conexion.Close();
                
             }
             else
             {
           

            
                String emai = email.Text;
                String contr = password.Text;
                String usuar = usuario.Text;
                String nombr = nombre.Text; 
                String apellid = apellido.Text;
                String dni = DNI.Text;
                String telefon = telefono.Text;
                String obras = obra.Text;
                String fech = fecha.Value.Date.ToString("yyyy-MM-dd");



                string dato = "INSERT INTO usuario(email, contraseña, usuario, nombre, apellido,dni,telefono,obra_social,fecha) VALUES ('"+emai + "','" + contr + "','" + usuar + "','" + nombr + "','" + apellid+ "','" + dni + "','" + telefon + "','" + obras + "','" + fech +"')";
            MySqlCommand comando = new MySqlCommand(dato,conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Registro Guardado");
     
            conexion.Close();
        }
        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void DNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
