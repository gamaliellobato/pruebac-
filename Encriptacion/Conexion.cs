using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encriptacion
{
    public class Conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=jsdes;Integrated Security=True");
                cn.Open();
                MessageBox.Show("Conectado");
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se concto con la BD: " + ex.ToString());
            }
        }

        public int usuarioEncontrado(string nombre, string pwd)
        {
            int resultado = 0;

            try
            {
                cmd = new SqlCommand("select count(1) from ACCECUSUARIO where NOMBRE ='" +nombre+"' AND PASSW = '" + pwd +"'" , cn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    resultado = 1;
                    Console.WriteLine("Si");
                }
                else
                {
                    resultado = 0;
                    Console.WriteLine("No");
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontro usuario: " + ex);
            }

            return resultado;

        }
    }
}
