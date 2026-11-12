using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace FrmAlquilerVehiculos
{
    public partial class FrmAlquiler : Form
    {

        Dictionary<string, string> fotosVehiculos;

        VehiculoBLL vehiculoBLL = new VehiculoBLL();

        public FrmAlquiler()
        {
            InitializeComponent();
            InicializarDiccionario();
            ConfigurarGrid();
        }

        private void InicializarDiccionario()
        {
            fotosVehiculos = new Dictionary<string, string>()
            {
                { "Corolla",   "foto_corolla.jpg" },
                { "Civic",     "foto_civic.jpg" },
                { "Elantra",   "foto_elantra.jpg" },
                { "3",         "foto_mazda3.jpg" },
                { "Sentra",    "foto_sentra.jpg" },
                { "Onix",      "foto_onix.jpg" },
                { "Focus",     "foto_focus.jpg" },
                { "Jetta",     "foto_jetta.jpg" },
                { "Rio",       "foto_rio.jpg" },
                { "Swift",     "foto_swift.jpg" },
                { "Logan",     "foto_logan.jpg" },
                { "Ibiza",     "foto_ibiza.jpg" },
                { "Fit",       "foto_fit.jpg" },
                { "Yaris",     "foto_yaris.jpg" },
                { "Accent",    "foto_accent.jpg" },
                { "2",         "foto_mazda2.jpg" },
                { "Versa",     "foto_versa.jpg" },
                { "Aveo",      "foto_aveo.jpg" },
                { "Fiesta",    "foto_fiesta.jpg" },
                { "Polo",      "foto_polo.jpg" }
            };
        }

        private void ConfigurarGrid()
        {
            if (dgvVehiculos == null) return;

            dgvVehiculos.AutoGenerateColumns = false;
            dgvVehiculos.Columns.Clear();

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Placa",
                DataPropertyName = "Placa",
                Width = 80
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Marca",
                DataPropertyName = "Marca",
                Width = 100
            });

            dgvVehiculos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                HeaderText = "Modelo",
                DataPropertyName = "Modelo",
                Width = 100
            });

            dgvVehiculos.Columns.Add(new DataGridViewImageColumn()
            {
                HeaderText = "Foto",
                Name = "Foto",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 120
            });
        }

        private void CargarVehiculosEnGrid()
        {
            var lista = vehiculoBLL.ObtenerVehiculos();
            dgvVehiculos.Rows.Clear();

            foreach (var veh in lista)
            {
                string rutaFoto = Path.Combine(Application.StartupPath, "FotosVehiculos", veh.Fotografia);
                Image img = null;

                if (File.Exists(rutaFoto))
                    img = Image.FromFile(rutaFoto);

                dgvVehiculos.Rows.Add(
                    veh.Placa,
                    veh.Marca,
                    veh.Modelo,
                    img
                );
            }
        }

        private void FrmAlquiler_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
            CargarVehiculosEnGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is Vehiculo veh)
            {
                string modelo = veh.Modelo;

                if (fotosVehiculos.ContainsKey(modelo))
                {
                    string foto = fotosVehiculos[modelo];
                    string ruta = Path.Combine(Application.StartupPath, "FotosVehiculos", foto);

                    if (File.Exists(ruta))
                        pictureBox1.Image = Image.FromFile(ruta);
                    else
                        pictureBox1.Image = null;
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
        }
    }
}