using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.Historial_Cliente
{
    public partial class Historial_Cliente : Form
    {
        SqlCommand cmd;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        private int contadorDeFilas;
        private int cantidadMaximaDeFilas;
        private DataBase db;

        public String username;

        int filasPagina = 10; // Definimos el numero de filas que deseamos ver por pagina
        int nroPagina = 1;//Esto define el numero de pagina actual en al que nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        int numeroRegistro;

        DataTable dtComprasYSubastas = new DataTable();
        DataRow fila;

        public static Historial_Cliente hc;

        public Historial_Cliente()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
            Historial_Cliente.hc = this;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close(); 
        }

        private void cmdPrimera_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblActual.Text) > 1)
            {
                this.nroPagina = 1;

                lblActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdAnterior_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblActual.Text) > 1)
            {
                this.nroPagina -= 1;


                lblActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdSiguiente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblActual.Text) < Convert.ToInt32(lblTotalPagina.Text))
            {
                this.nroPagina += 1;


                lblActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdUltima_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblTotalPagina.Text) > 1)
            {
                this.nroPagina = Convert.ToInt32(lblTotalPagina.Text);

                lblActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void paginar()
        {
            nroPagina = Convert.ToInt32(lblActual.Text);//Obtenemos el numero de paginaactual 
            if (dataGridView2.Rows.Count > 0)
            {
                this.ini = nroPagina * filasPagina - filasPagina;
                this.fin = nroPagina * filasPagina;
                if (fin > dataGridView2.Rows.Count)
                    fin = dataGridView2.Rows.Count;
            }
            else
            {
                this.ini = 0;
                this.fin = dataGridView2.Rows.Count;
            }

            dataGridView2.Rows.Clear();
            int indiceInsertar;//
            numeroRegistro = this.ini;
            dataGridView2.ColumnCount = 5;
            dataGridView2.Columns[0].Name = "Tipo Transac";
            dataGridView2.Columns[1].Name = "Fecha";
            dataGridView2.Columns[2].Name = "Monto";
            dataGridView2.Columns[3].Name = "Descripcion";
            dataGridView2.Columns[4].Name = "UserId";
         
            contadorDeFilas = 0;
            for (int i = ini; i < filasPagina * nroPagina; i++)
            {

                fila = dtComprasYSubastas.Rows[i];

                numeroRegistro = numeroRegistro + 1;
                dataGridView2.Rows.Add();

                indiceInsertar = i;
                dataGridView2.Rows[contadorDeFilas].Cells[0].Value = fila[0].ToString();
                dataGridView2.Rows[contadorDeFilas].Cells[1].Value = fila[1].ToString();
                dataGridView2.Rows[contadorDeFilas].Cells[2].Value = fila[2].ToString();
                dataGridView2.Rows[contadorDeFilas].Cells[3].Value = fila[3].ToString();
                dataGridView2.Rows[contadorDeFilas].Cells[4].Value = fila[4].ToString();
 

                contadorDeFilas++;

                if (numeroRegistro == cantidadMaximaDeFilas && nroPagina == int.Parse(lblTotalPagina.Text))
                {
                    i = filasPagina * nroPagina;

                }



            }
        }

        private void numPaginas()
        {
            if (dtComprasYSubastas.Rows.Count % filasPagina == 0)
                lblTotalPagina.Text = (dtComprasYSubastas.Rows.Count / filasPagina).ToString();
            else
            {
                double valor = dtComprasYSubastas.Rows.Count / filasPagina;
                lblTotalPagina.Text = (Convert.ToInt32(valor) + 1).ToString();

            }

            lblActual.Text = "1";
        }



        private void cargarOtrosDatos()
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Historial_Cliente_Acumulados", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = username;
            adapter = new SqlDataAdapter(cmd);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                lblSinCalif.Text = sdr["Sin Calificar"].ToString();
                lblPromedio.Text = sdr["Promedio Estrellas"].ToString();
                lblCantEstrellas.Text = sdr["Estrellas Totales"].ToString();
            }
            //dtComprasYSubastas = new DataTable("ROAD_TO_PROYECTO.Transaccion");
            //adapter.Fill(dtComprasYSubastas);
        }

        private void Historial_Cliente_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Historial_Cliente_Compras_Subastas", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = username;
            adapter = new SqlDataAdapter(cmd);
            dtComprasYSubastas = new DataTable("ROAD_TO_PROYECTO.Transaccion");
            adapter.Fill(dtComprasYSubastas);

            this.cargarOtrosDatos();

            if (dtComprasYSubastas.Rows.Count > 0)
            {
                this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                this.paginar();//empezamos con la paginacion             
                lblCantidadTotal.Text = "Compras/Subastas Encontradas: " + dtComprasYSubastas.Rows.Count.ToString();//Cantidad totoal de registros encontrados
                cantidadMaximaDeFilas = dtComprasYSubastas.Rows.Count;
                dataGridView2.Select();
            }
            else
            {
                dataGridView2.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview

                lblCantidadTotal.Text = "Compras/Subastas Encontradas: 0";
                cantidadMaximaDeFilas = 0;
            }
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Refresh();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lblCantEstrellas_Click(object sender, EventArgs e)
        {

        }
    }
}
