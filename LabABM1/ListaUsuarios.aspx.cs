using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ListaUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (PaginaEnEstadoEdicion())
        {
            CargarDatosUsuario(int.Parse(Request.QueryString["id"]));
            lblAccion.Text = ("Editar Usuario");
        }
        else
        {
            lblAccion.Text = ("Agregar Nuevo Usuario");
        }
    }
    private void cargarDiasCalendario()
    {
        //Cargar en el combo los items correspondientes a los días
        //(del 1 al 31)
    }
    private bool PaginaEnEstadoEdicion()
    {
        if (Request.QueryString["id"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void CargarDatosUsuario(int idUsuario)
    {
        // 1 - Obtener los datos del usuario en cuestión
        Negocio.Usuario usuario = new Negocio.Usuario();
        Negocio.ManagerUsuarios managerUsuarios = new Negocio.ManagerUsuarios();
        usuario = managerUsuarios.GetUsuario(idUsuario);
        // 2 - Cargar en los controles de la tabla los datos del usuario obtenido
        txtApellido.Text = usuario.Apellido;
        txtNombre.Text = usuario.Nombre;
        txtNroDoc.Text = usuario.NroDoc.ToString();
        txtAñoFechaNac.Text = usuario.FechaNac;
        txtDireccion.Text = usuario.Direccion;
        txtEmail.Text = usuario.Email;
        txtTelefono.Text = usuario.Telefono;
        txtCelular.Text = usuario.Celular;
        txtNombreUsu.Text = usuario.NombreUsuario;
        txtClave.Text = usuario.Clave;
        txtConfirmarClave.Text = usuario.Clave;
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Usuario usuario = new Usuario();
        usuario.Apellido = txtApellido.Text;
        usuario.Nombre=txtNombre.Text;
        usuario.NroDoc = int.Parse(txtNroDoc.Text);
        usuario.FechaNac = ddlDiaFechaNac.SelectedValue + ddlMesFechaNac.SelectedValue + txtAñoFechaNac.Text;
        usuario.Direccion = txtDireccion.Text;
        usuario.Email = txtEmail.Text;
        usuario.Telefono = txtTelefono.Text;
        usuario.Celular = txtCelular.Text;
        usuario.NombreUsuario = txtNombreUsu.Text;
        usuario.Clave = txtClave.Text;
        ManagerUsuarios managerUsuarios = new ManagerUsuarios();
        if (PaginaEnEstadoEdicion())
        {
            managerUsuarios.ActualizarUsuario(usuario);
        }
        else
        {
            managerUsuarios.AgregarUsuario(usuario);
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Page_Load(sender, e);
    }
}