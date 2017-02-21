using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encriptacion
{
    public partial class Form1 : Form
    {
        Conexion c = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = md5.ComputeHash(inputBytes);
            password = BitConverter.ToString(hash).Replace("-", "");
            txtPassEncriptado.Text = password.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < 100; i+=10)
            {
                //int j=20;
                Button boton = new Button();
                boton.Text = "HOLA";
                boton.Location = new Point(i, 100);
                boton.BackColor = Color.Aqua;
                this.Controls.Add(boton);
            }
             
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (c.usuarioEncontrado(txtUsuario.Text, txtPassword.Text) == 1)
            {
                MessageBox.Show("Se encontro el usuario");
            }
            else
            {
                MessageBox.Show("No se encontro");
            }
        }
    }
}
