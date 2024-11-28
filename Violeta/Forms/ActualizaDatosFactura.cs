using Proyecto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.Forms
{
    public partial class frmActualizaDatosFactura : Form
    {
        public frmActualizaDatosFactura()
        {
            InitializeComponent();
           

        }
        // Agregar una propiedad pública para recibir el nombre del cliente
        public string NombreCliente
        {
            set
            {
                txtCliente.Text = value; // txtCliente debe ser el TextBox donde se muestra el nombre del cliente
            }
        }
        public List<string[]> DatosFactura { get; set; } // Listado de datos de la factura
        private void frmActualizaDatosFactura_Load(object sender, EventArgs e)
        {
            if (DatosFactura != null && DatosFactura.Count > 0)
            {
                // Configurar columnas del DataGridView
                dgvFecha.ColumnCount = 4;
                dgvFecha.Columns[0].Name = "Numero";
                dgvFecha.Columns[1].Name = "Cliente";
                dgvFecha.Columns[2].Name = "Fecha";
                dgvFecha.Columns[3].Name = "Total";
                dgvFecha.Rows.Clear(); // Limpia cualquier fila existente
                foreach (var fila in DatosFactura)
                {
                    dgvFecha.Rows.Add(fila); // Agrega cada fila recibida
                }
            }
        }
    }
}
