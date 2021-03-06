using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace appListaSimple2021
{
    public partial class Form1 : Form
    {
        Lista miLista;
        public Form1()
        {
            InitializeComponent();
            miLista = new Lista();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                Nodo n = new Nodo(d, nombre, telefono);
                miLista.Agregar(n);
                miLista.Guardar("testListaCircular");
               
                txtNumero.Clear();
                txtNumero.Focus();
                txtNombre.Clear();
                txtTelefono.Clear();
                miLista.Mostrar(lsdLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            //MessageBox.Show(miLista + "");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                miLista.Eliminar(d);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lsdLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                Nodo b = new Nodo();
                if (miLista.Buscar(d, ref b))
                {
                    txtNombre.Text = b.Nombre;
                    txtTelefono.Text = b.Telefono;
                    //MessageBox.Show("Existe ");
                }
                else
                {
                    txtNombre.Clear();
                    txtTelefono.Clear();
                    MessageBox.Show("NO Existe ");
                }
                txtNumero.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                int d = int.Parse(txtNumero.Text);
                miLista.Modificar(d, txtNombre.Text, txtTelefono.Text);
                txtNumero.Clear();
                txtNombre.Clear();
                txtTelefono.Clear();
                txtNumero.Focus();
                miLista.Mostrar(lsdLista);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            Lista lc = new Lista();
            lc.Cargar("testListaCircular");
            lsdLista.Items.Add(lc.ToString());

        }
    }
}
