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
    public partial class Form3 : Form
    {
        int? id;
        MySqlConnection conexion = new MySqlConnection("server=bc0hlp84kblyxgwgnbv1-mysql.services.clever-cloud.com; Database = bc0hlp84kblyxgwgnbv1; Uid= utxfu6lpnbtjlwq7; Pwd= RZUdlvbtrHTCvKP1q1PO;");
        public Form3(int? id)
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

            MySqlCommand sqlCMD = new MySqlCommand("select * from turnos where id=@id", conexion);
            sqlCMD.Parameters.AddWithValue("@id", this.id);
            MySqlDataReader sqlDT = sqlCMD.ExecuteReader();

            while (sqlDT.Read())
            {
                iduser.Text = Convert.ToString(sqlDT["id_usuario"]);
                prestacion.Text = Convert.ToString(sqlDT["prestacion"]);
                hora.Text = Convert.ToString(sqlDT["hora"]);
                calendario.Text = Convert.ToString(sqlDT["fecha_turno"]);


            }

            conexion.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexion.Open();

            if (id != null)
            {

                String id_usuario = iduser.Text;
                String presta = prestacion.Text;
                String horario = hora.Text;
                String fecha = calendario.Value.Date.ToString("yyyy-MM-dd");





                string dato = "UPDATE turnos SET id_usuario='"+id_usuario +"'prestacion='" + presta + "',hora= '" + horario + "',fecha_turno= '" + fecha + "' WHERE id=" + id;

                MySqlCommand comando = new MySqlCommand(dato, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");
                conexion.Close();

            }
            else
            {


                String id_usuario = iduser.Text;
                String presta = prestacion.Text;
                String horario = hora.Text;
                String fecha = calendario.Value.Date.ToString("yyyy-MM-dd");


                string dato = "INSERT INTO turnos(id_usuario,prestacion,hora,fecha_turno) VALUES ('"+id_usuario + presta + "','" + horario + "','" + fecha + "')";
                MySqlCommand comando = new MySqlCommand(dato, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro Guardado");

                conexion.Close();
            }
        }

        private void hora_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prestacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fechapick_ValueChanged(object sender, EventArgs e)
        {

        }

        private void calendario_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
