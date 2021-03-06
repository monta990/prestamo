using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using System.IO;
using libperloan;

namespace Perloan_Desktop
{
    public partial class FrmMenuUsuario : Form
    {
        #region Singleton
        /// <summary>
        /// Uso de sigletion en formulario
        /// </summary>
        private static FrmMenuUsuario _instance;
        public FrmMenuUsuario instance
        {
            get
            {
                if (FrmMenuUsuario._instance == null)
                {
                    FrmMenuUsuario._instance = new FrmMenuUsuario(Usuarios.valor, Usuarios.nivel, Usuarios.nombre, Usuarios.ApellidoP, Usuarios.ApellidoM);
                }
                else
                {
                    MessageBox.Show("Ya esta abierto menu " + nivel + ", se volvera a mostrar");
                    lbbienvenido.Text = "Bienvenido " + nivel + ":";
                    lbbienvenido.Update();
                    lbnombre.Text = nombre + " " + apellidop + " " + apellidom; //leer el nombre del usuario actual
                    lbnombre.Update();
                }
                return FrmMenuUsuario._instance;
            }
        }
        #endregion
        private string nivel;
        private string nombre;
        private string apellidom;
        private string apellidop;
        private int valor;
        public FrmMenuUsuario(int valor, string nivel, string nombre, string apellidop, string apellidom)
        {
            InitializeComponent();
            lbEquipo.Text = "Nombre del equipo: " + Dns.GetHostName().ToString() + "       IP Local: " + GetComputer_LanIP().ToString(); //nombre del equipo e ip local
            lbFecha.Text = "Fecha: " + DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            Usuario();
            this.valor = valor;
            this.nivel = nivel;
            this.nombre = nombre;
            this.apellidom = apellidom;
            this.apellidop = apellidop;

        }
        /// <summary>
        /// Verifica tipo de usuario
        /// </summary>
        private void Usuario()
        {
            if (valor == 1) //verificar que es cobrador, para desactivar modulos
            {
                usuariosToolStripMenuItem.Visible = false; //desactivar acceso a usuario a cobrador
                reporteDeUsuariosToolStripMenuItem.Visible = false; //desactiva acceso a reporte usuarios a cobrador
                btn_Usuarios.Visible = false; //desactiva boton usuarios a cobrador
                abrirUsuariosToolStripMenuItem.Visible = false; //desactiva Abrir Usuarios en men˙ secundario si es cobrador
                configuraciˇnToolStripMenuItem.Visible = false;
            }
        }
        private void menu_Load(object sender, EventArgs e)
        {
            lbbienvenido.Text = "Bienvenido " + nivel + ":";
            lbnombre.Text = nombre + " " + apellidop + " " + apellidom; //leer el nombre del usuario actual
        }

        private string GetComputer_LanIP() //obtiene la ip local, para soporte remoto
        {
            string strHostName = Dns.GetHostName();

            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);

            foreach (IPAddress ipAddress in ipEntry.AddressList)
            {
                if (ipAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    return ipAddress.ToString();
                }
            }
            return "-";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = "Fecha: " + DateTime.Today.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void ayudaDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sontechs.com/perloan");
        }

        private void abrirAyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://sontechs.com/perloan");
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) //abre admin de usuarios
        {
            new FrmAdminUsuarios().ShowDialog();
        }

        private void deudoresToolStripMenuItem_Click(object sender, EventArgs e) //abre admin de deudores
        {
            new FrmAdminDeudores().ShowDialog();
        }

        private void acercaDelSisremaToolStripMenuItem_Click(object sender, EventArgs e) //acerca de
        {
            new FrmAboutBox().ShowDialog();
        }

        private void prendasToolStripMenuItem_Click(object sender, EventArgs e) //abre admin de prendas
        {
            new FrmAdminPrenda().ShowDialog();
        }

        private void prestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAdminPrestamo().ShowDialog();
        }

        private void bt_salir_Click(object sender, EventArgs e) //boton salir
        {
            this.Hide();
            FrmInicio inicio = new FrmInicio();
            inicio.instance.Show();
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            new FrmAdminUsuarios().ShowDialog();
        }

        private void btn_Deudores_Click(object sender, EventArgs e)
        {
            new FrmAdminDeudores().ShowDialog();
        }

        private void btn_Prestamos_Click(object sender, EventArgs e)
        {
            new FrmAdminPrestamo().ShowDialog();
        }

        private void btn_Prendas_Click(object sender, EventArgs e)
        {
            new FrmAdminPrenda().ShowDialog();
        }

        private void reporteDePrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReportePrestamos().ShowDialog();
        }

        private void reporteDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReporteUsuario().ShowDialog();
        }

        private void abrirDeudoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAdminDeudores().ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void abrirUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAdminUsuarios().ShowDialog();
        }

        private void abrirPrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            new FrmAdminPrestamo().ShowDialog();
        }

        private void abrirPrendaasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAdminPrenda().ShowDialog();
        }

        private void mySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConfigMySQL().ShowDialog();
        }

        private void mSServerSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConfigMSSQLServer().ShowDialog();
        }

        private void postgreSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConfigPostgreSQL().ShowDialog();
        }

        private void imagenABDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmImagen().ShowDialog();
        }
    }
}