using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{

    public partial class inicio : Form
    {
        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public inicio(Usuario objusuario = null, IconMenuItem menuusuarios = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;

            InitializeComponent();
            this.menuusuarios = menuusuarios;
        }

        private void inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);

                if (encontrado == false)
                {
                    iconmenu.Visible = false;

                }
            }
            lblusuario.Text = usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario){
                    if (MenuActivo != null)
                    {

                        MenuActivo.BackColor = Color.White;

                    }

                    menu.BackColor = Color.Silver;
                    MenuActivo = menu;

                         if (FormularioActivo != null)
                         {
                            FormularioActivo.Close();
                         }

                            FormularioActivo = formulario;
                            formulario.TopLevel = false;
                            formulario.FormBorderStyle = FormBorderStyle.None;
                            formulario.Dock = DockStyle.Fill;
                            formulario.BackColor = Color.SteelBlue;
                            contenedor.Controls.Add(formulario);
                            formulario.Show();
         }

                private void menuusuarios_Click_1(object sender, EventArgs e)
                {
                    AbrirFormulario((IconMenuItem)sender, new frmUsuarios());
                }
                private void submenucategoria_Click_1(object sender, EventArgs e)
                {
                    AbrirFormulario(menumantenedor, new frmCategoria());
                }
                private void submenuproducto_Click_1(object sender, EventArgs e)
                {
                    AbrirFormulario(menumantenedor, new frmProductos());
                }
                private void submenuregistrarventa_Click(object sender, EventArgs e)
                {
                     AbrirFormulario(menuventas, new frmVentas(usuarioActual));
                }
                private void submenuverdetalleventas_Click(object sender, EventArgs e)
                {
                     AbrirFormulario(menuventas, new frmDetalleVenta());
                }
                private void submenuregistrarcompra_Click(object sender, EventArgs e)
                {
                     AbrirFormulario(menucompras, new frmCompras(usuarioActual));
                }
                private void submenuverdetallecompra_Click(object sender, EventArgs e)
                {
                     AbrirFormulario(menucompras, new frmDetalleCompra());
                }
                private void menuclientes_Click(object sender, EventArgs e)
                {
                     AbrirFormulario(menuclientes, new frmClientes());
                }
                private void submenunegocio_Click(object sender, EventArgs e)
                {
                    AbrirFormulario(menumantenedor, new frmNegocio());
                }
                private void submenureportecompras_Click(object sender, EventArgs e)
                {
                    AbrirFormulario(menureportes, new frmReporteCompras());
                }
                private void submenureporteventas_Click(object sender, EventArgs e)
                {
                    AbrirFormulario(menureportes, new frmReporteVentas());
                }
                private void menuacercade_Click(object sender, EventArgs e)
                {
                    mdAcercade md = new mdAcercade();
                    md.ShowDialog();
                }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Desea salir","Mensaje",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
