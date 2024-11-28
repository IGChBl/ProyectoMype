using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class frmActualizarEliminarFacturaErronea : Form
    {
        public frmActualizarEliminarFacturaErronea()
        {
            InitializeComponent();
        }

        private void Actualizar_o_Eliminar_Facturas_Erróneas_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string criterioBusqueda = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingresa un criterio de búsqueda.");
                return;
            }

            // Simulación de búsqueda en un DataTable vinculado a DataGridView
            DataView vista = ((DataTable)dgvFacturas.DataSource).DefaultView;
            vista.RowFilter = $"NumeroFactura LIKE '%{criterioBusqueda}%' OR Cliente LIKE '%{criterioBusqueda}%'";

            if (vista.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados.");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
        }
    }
}
