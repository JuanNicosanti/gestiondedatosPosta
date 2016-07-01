using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Facturas
{
    public partial class ConsultaFacturas : Form
    {
        SqlCommand cmd;
        SqlDataAdapter adapter;
        private DataBase db;
        public static ConsultaFacturas cf;

        private Boolean hayDatos=false;
        private Boolean seRealizoBusqueda=false;
        private int contadorDeFilas;
        private int cantidadMaximaDeFilas;
        public bool esAdmin = false;
        public string user;

        int filasPagina = 10; // Definimos el numero de filas que deseamos ver por pagina
        int nroPagina = 1;//Esto define el numero de pagina actual en al que nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        int numeroRegistro;

        DataTable dtFacturas = new DataTable();
        DataRow fila;


        public ConsultaFacturas()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
            ConsultaFacturas.cf = this;
        }

        private void panelResultados_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            dtpFechaInicial.Value = DateTime.Now;
            dtpFechaFinal.Value = DateTime.Now;
            tbImporteMinimo.Text = "";
            tbImporteMaximo.Text = "";
            tbContenido.Text = "";
            tbVendedor.Text = "";
            hayDatos = false;
            seRealizoBusqueda = false;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            
           
            string importeMinimo;
            string importeMaximo;
            if (dtpFechaFinal.Value < dtpFechaInicial.Value)
            {
                MessageBox.Show("La fecha final debe ser menor o igual a la fecha inicial", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            if (!string.IsNullOrEmpty(tbImporteMinimo.Text))
            {
                if (double.Parse(tbImporteMinimo.Text) < 0)
                {
                    MessageBox.Show("No estan permitidos importes negativos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            if(!string.IsNullOrEmpty(tbImporteMaximo.Text))
            {
                if (double.Parse(tbImporteMaximo.Text) < 0)
                {
                    MessageBox.Show("No estan permitidos importes negativos", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            if (string.IsNullOrEmpty(tbImporteMinimo.Text))
            {
                importeMinimo = int.MinValue.ToString();
            }
            else
            {
                importeMinimo = tbImporteMinimo.Text;
            }
            if (string.IsNullOrEmpty(tbImporteMaximo.Text))
            {
                importeMaximo = int.MaxValue.ToString();
            }
            else
            {
                importeMaximo = tbImporteMaximo.Text;
            }
            if (!string.IsNullOrEmpty(tbImporteMinimo.Text) && !string.IsNullOrEmpty(tbImporteMaximo.Text))
            {
                if ((double.Parse(importeMaximo)) < (double.Parse(importeMinimo)))
                {
                    MessageBox.Show("El importe mínimo debe ser menor o igual al importe máximo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Consulta_Facturas_Vendedor", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicioIntervalo", SqlDbType.DateTime).Value = dtpFechaInicial.Value;
            cmd.Parameters.AddWithValue("@FechaFinIntervalo", SqlDbType.DateTime).Value = dtpFechaFinal.Value;
            cmd.Parameters.AddWithValue("@MontoInicioIntervaloString", SqlDbType.NVarChar).Value = importeMinimo;
            cmd.Parameters.AddWithValue("@MontoFinIntervaloString", SqlDbType.NVarChar).Value = importeMaximo;
            cmd.Parameters.AddWithValue("@Detalle", SqlDbType.NVarChar).Value = tbContenido.Text;
            if (user != "admin" && !esAdmin)
            {
                cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = user;
            }
            else
            {
                cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = tbVendedor.Text;
            }

            adapter = new SqlDataAdapter(cmd);
            dtFacturas = new DataTable("ROAD_TO_PROYECTO.Facturas");
            adapter.Fill(dtFacturas);
            seRealizoBusqueda = true;
           

            if (dtFacturas.Rows.Count > 0)
            {
               
                this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                cantidadMaximaDeFilas = dtFacturas.Rows.Count;
                this.paginar();//empezamos con la paginacion             
                lblCantidadTotal.Text = "Facturas Encontradas: " + dtFacturas.Rows.Count.ToString();//Cantidad totoal de registros encontrados
               
                dataGridView1.Select();
                hayDatos = true;

            }
            else
            {
                dataGridView1.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview

                lblCantidadTotal.Text = "Facturas Encontradas: 0";
                cantidadMaximaDeFilas = 0;
                hayDatos = false;
            }

            panelResultados.Visible = true;
            labelMIL.Visible = true;
            cmdAnterior.Visible = true;
            cmdPrimera.Visible = true;
            cmdProxima.Visible = true;
            cmdUltima.Visible = true;
            label9.Visible = true;
            lblCantidadTotal.Visible = true;
            lblPaginaActual.Visible = true;
            lblTotalPagina.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                cmdVerFactura.Visible = true;
            }
        }

        private void cmdVerFactura_Click(object sender, EventArgs e)
        {
            int fila = dataGridView1.CurrentRow.Index;
            WindowsFormsApplication1.ComprarOfertar.Facturar factura = new WindowsFormsApplication1.ComprarOfertar.Facturar();
            factura.factId = int.Parse(dataGridView1[0, fila].Value.ToString());
            factura.publId = int.Parse(dataGridView1[1, fila].Value.ToString());
            factura.esPorConsulta = 1;
            factura.Show();
            this.Hide();
        }

        private void ConsultaFacturas_Load(object sender, EventArgs e)
        {
            if (user != "admin" && !esAdmin) 
            {
                tbVendedor.Visible = false;
                label6.Visible = false;
            }
            dtpFechaFinal.Value = Fecha.getFechaActual();
            dtpFechaInicial.Value = Fecha.getFechaActual();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

        private void cmdPrimera_Click(object sender, EventArgs e)
        {
            if (seRealizoBusqueda && hayDatos)
            {
                if (Convert.ToInt32(lblTotalPagina.Text) > 1)
                {
                    this.nroPagina = 1;

                    lblPaginaActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
           
        }

        private void cmdProxima_Click(object sender, EventArgs e)
        {
            if (seRealizoBusqueda && hayDatos)
            {
                if (Convert.ToInt32(lblPaginaActual.Text) < Convert.ToInt32(lblTotalPagina.Text))
                {
                    this.nroPagina += 1;


                    lblPaginaActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }

           
        }

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            if (hayDatos && seRealizoBusqueda)
            {
                if (Convert.ToInt32(lblPaginaActual.Text) > 1)
                {
                    this.nroPagina -= 1;


                    lblPaginaActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
            
        }

        private void cmdUltima_Click(object sender, EventArgs e)
        {
            if (hayDatos && seRealizoBusqueda)
            {
                if (Convert.ToInt32(lblTotalPagina.Text) > 1)
                {
                    this.nroPagina = Convert.ToInt32(lblTotalPagina.Text);

                    lblPaginaActual.Text = this.nroPagina.ToString();
                    this.paginar();
                }
            }
            
        }

        private void numPaginas()
        {
           
            if (dtFacturas.Rows.Count % filasPagina == 0)
                lblTotalPagina.Text = (dtFacturas.Rows.Count / filasPagina).ToString();
            else
            {
                double valor = dtFacturas.Rows.Count / filasPagina;
                lblTotalPagina.Text = (Convert.ToInt32(valor) + 1).ToString();

            }

            lblPaginaActual.Text = "1";
        }

        private void paginar()
        {
            
            nroPagina = Convert.ToInt32(lblPaginaActual.Text);//Obtenemos el numero de paginaactual 
            if (dataGridView1.Rows.Count > 0)
            {
                this.ini = nroPagina * filasPagina - filasPagina;
                this.fin = nroPagina * filasPagina;
                if (fin > dataGridView1.Rows.Count)
                    fin = dataGridView1.Rows.Count;
            }
            else
            {
                this.ini = 0;
                this.fin = dataGridView1.Rows.Count;
            }

            dataGridView1.Rows.Clear();
            int filasPaginaBis=filasPagina;
            if (filasPagina > dtFacturas.Rows.Count)
            {
                filasPaginaBis = dtFacturas.Rows.Count;
            }
           
            int indiceInsertar;
            numeroRegistro = this.ini;
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "FactNro";
            dataGridView1.Columns[1].Name = "PubliId";
            dataGridView1.Columns[2].Name = "Descripcion";
            dataGridView1.Columns[3].Name = "Fecha";
            dataGridView1.Columns[4].Name = "Total";                        

            contadorDeFilas = 0;
            //cantidadMaximaDeFilas=
            for(int i = ini; i < filasPaginaBis * nroPagina; i++)
            {

                fila = dtFacturas.Rows[i];

                numeroRegistro = numeroRegistro + 1;
                dataGridView1.Rows.Add();

                indiceInsertar = i;
                dataGridView1.Rows[contadorDeFilas].Cells[0].Value = fila[0].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[1].Value = fila[1].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[2].Value = fila[2].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[3].Value = fila[3].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[4].Value = fila[4].ToString();                         

                contadorDeFilas++;

                if (numeroRegistro == cantidadMaximaDeFilas && nroPagina == int.Parse(lblTotalPagina.Text))
                {
                    i = filasPagina * nroPagina;

                }
            }
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }
       



    }
}
