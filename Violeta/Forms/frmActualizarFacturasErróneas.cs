using Proyecto.Forms;
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

namespace Proyecto
{
    public partial class frmActualizarEliminarFacturaErronea : Form
    {
     
        public frmActualizarEliminarFacturaErronea()
        {
            InitializeComponent();
        }
        
      
        private void ActualizarEliminarFacturaErronea_Load(object sender, EventArgs e)
        {
            dgvFacturas.ColumnCount = 4; 
            dgvFacturas.Columns[0].Name = "Numero";
            dgvFacturas.Columns[1].Name = "Cliente";
            dgvFacturas.Columns[2].Name = "Fecha";
            dgvFacturas.Columns[3].Name = "Total";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string criterioBusqueda = txtBuscar.Text.Trim();

            // Validar que el criterio no esté vacío
            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un número de factura o nombre de cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cargar las facturas desde el archivo JSON
            var facturas = FacturaStorage.CargarFacturas();

            // Depuración: verificar cuántas facturas se cargaron
            MessageBox.Show($"Número de Facturas Cargadas: {facturas.Count}", "Depuración");

            // Filtrar las facturas que coincidan con el criterio de búsqueda
            var facturasFiltradas = facturas.Where(f =>
                f.Numero.ToLower().Contains(criterioBusqueda.ToLower()) ||
                f.Cliente.ToLower().Contains(criterioBusqueda.ToLower())).ToList();

            // Depuración: verificar cuántas facturas se encontraron
            MessageBox.Show($"Número de Facturas Encontradas: {facturasFiltradas.Count}", "Depuración");

            // Mostrar los resultados en el DataGridView
            dgvFacturas.Rows.Clear();
            if (facturasFiltradas.Count > 0)
            {
                foreach (var factura in facturasFiltradas)
                {
                    dgvFacturas.Rows.Add(factura.Numero, factura.Cliente, factura.Fecha.ToShortDateString(), factura.Total.ToString("C"));
                }
            }
            else
            {
                MessageBox.Show("No se encontraron facturas con el criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            frmActualizaDatosFactura frmActualizar = new frmActualizaDatosFactura();
            frmActualizar.ShowDialog();
        }
    }
}
