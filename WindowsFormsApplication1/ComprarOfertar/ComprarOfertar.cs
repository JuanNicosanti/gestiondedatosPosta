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

namespace

WindowsFormsApplication1.ComprarOfertar
{
    public partial class ComprarOfertar : Form
    {

        

        SqlCommand cmd;
        SqlCommand cmd2;
        SqlDataReader sdr;
        SqlDataAdapter adapter;
        
        private DataBase db;
        private String listaDeRubrosFiltros;
        String descripcionFiltros;
        private int tieneEnvio;
        private int cash;
       

        private Boolean seSigueCargandoPrimeraPagina=true;
        private Boolean yaSeCompro = false;

        public static ComprarOfertar cO;
        public String compradorID;
        public int publisSinCalif;

        private int proximaFila = 0;
        private int contadorDeFilas;
        private int cantidadMaximaDeFilas;
        private int cantidad;
        private int indiceInsertar;//
        int filasPagina = 10; // Definimos el numero de filas que deseamos ver por pagina
        int nroPagina = 1;//Esto define el numero de pagina actual en al que nos encontramos
        int ini = 0; //inicio del paginado
        int fin = 0;//fin del paginado

        DataTable dtPublicaciones = new DataTable();
        DataRow fila;

        int numeroRegistro;

        public ComprarOfertar()
        {
            InitializeComponent();
            db = DataBase.GetInstance();
            ComprarOfertar.cO = this;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdVolver_Click(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }

        private void ComprarOfertar_Load(object sender, EventArgs e)
        {

            txtGuita.Visible = false;
            txtCantidad.Visible = false;
            lblGuita.Visible = false;
            lblCantidad.Visible = false;
            cmd = new SqlCommand("ROAD_TO_PROYECTO.ListaRubros", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable("ROAD_TO_PROYECTO.Rubro");
            adapter.Fill(dt);
            this.lstRubros.DataSource = dt;
            this.lstRubros.DisplayMember = "DescripLarga";

            lstRubros.ValueMember = lstRubros.DisplayMember;
           
            lstRubrosElegidos.Items.Clear();

            cmd = new SqlCommand("ROAD_TO_PROYECTO.Cantidad_Compras_Subastas_Sin_Calificar", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = compradorID;

            sdr = cmd.ExecuteReader();
            sdr.Read();
            publisSinCalif = (int)sdr["cantPublis"];                    
            sdr.Close();
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
                dataGridView1.Rows.Clear();

                if (filasPagina > dtPublicaciones.Rows.Count)
                {
                    filasPagina = dtPublicaciones.Rows.Count;
                }
                
                numeroRegistro = this.ini;
                dataGridView1.ColumnCount = 10;
                dataGridView1.Columns[0].Name = "PublId";
                dataGridView1.Columns[1].Name = "Descripcion";
                dataGridView1.Columns[2].Name = "Stock";
                dataGridView1.Columns[3].Name = "FechaInicio";
                dataGridView1.Columns[4].Name = "FechaFin";
                dataGridView1.Columns[5].Name = "Precio";
                dataGridView1.Columns[6].Name = "Rubro";
                dataGridView1.Columns[7].Name = "Tipo";
                dataGridView1.Columns[8].Name = "UserId";
                dataGridView1.Columns[9].Name = "EnvioHabilitado";
                
                while (seSigueCargandoPrimeraPagina)
                {
                    fila = dtPublicaciones.Rows[ini];

                   
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[contadorDeFilas].Cells[0].Value = fila[0].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[1].Value = fila[1].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[2].Value = fila[2].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[3].Value = fila[3].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[4].Value = fila[4].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[5].Value = fila[5].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[6].Value = fila[6].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[7].Value = fila[7].ToString();
                    dataGridView1.Rows[contadorDeFilas].Cells[8].Value = fila[8].ToString();
                    if (fila[9].Equals(0))
                    {
                        dataGridView1.Rows[contadorDeFilas].Cells[9].Value = "No";
                    }
                    else
                    {
                        dataGridView1.Rows[contadorDeFilas].Cells[9].Value = "Si";
                    }
                    ini++;
                    contadorDeFilas++;
                    proximaFila++;

                    if (proximaFila == filasPagina)
                    {
                        seSigueCargandoPrimeraPagina = false;
                    }
                }
                return;
            }

            dataGridView1.Rows.Clear();
           
            numeroRegistro = this.ini;
            dataGridView1.ColumnCount = 10;
            dataGridView1.Columns[0].Name = "PublId";
            dataGridView1.Columns[1].Name = "Descripcion";
            dataGridView1.Columns[2].Name = "Stock";
            dataGridView1.Columns[3].Name = "FechaInicio";
            dataGridView1.Columns[4].Name = "FechaFin";
            dataGridView1.Columns[5].Name = "Precio";
            dataGridView1.Columns[6].Name = "Rubro";
            dataGridView1.Columns[7].Name = "Tipo";
            dataGridView1.Columns[8].Name = "UserId";
            dataGridView1.Columns[9].Name = "EnvioHabilitado";
         
            contadorDeFilas = 0;
            for (int i = ini; i < filasPagina * nroPagina; i++)
            {

                fila = dtPublicaciones.Rows[i];

                numeroRegistro = numeroRegistro + 1;
                dataGridView1.Rows.Add();

                indiceInsertar = i;
                dataGridView1.Rows[contadorDeFilas].Cells[0].Value = fila[0].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[1].Value = fila[1].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[2].Value = fila[2].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[3].Value = fila[3].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[4].Value = fila[4].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[5].Value = fila[5].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[6].Value = fila[6].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[7].Value = fila[7].ToString();
                dataGridView1.Rows[contadorDeFilas].Cells[8].Value = fila[8].ToString();
                if(fila[9].Equals(0))
                {
                    dataGridView1.Rows[contadorDeFilas].Cells[9].Value = "No";
                }
                else
                   {
                       dataGridView1.Rows[contadorDeFilas].Cells[9].Value = "Si";
                   }
               
                contadorDeFilas++;

                if (numeroRegistro == cantidadMaximaDeFilas && nroPagina == int.Parse(lblTotalPagina.Text))
                {
                    i = filasPagina * nroPagina;

                }



            }
        }

        private void numPaginas()
        {
            if (dtPublicaciones.Rows.Count % filasPagina == 0)
                lblTotalPagina.Text = (dtPublicaciones.Rows.Count / filasPagina).ToString();
            else
            {
                double valor = dtPublicaciones.Rows.Count / filasPagina;
                lblTotalPagina.Text = (Convert.ToInt32(valor) + 1).ToString();

            }

            lblPaginaActual.Text = "1";
        }

      

        private void cmdSeleccionarRubro_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lstRubrosElegidos.Items.Count; i++)
            {
                if (lstRubrosElegidos.Items[i].ToString().Equals(lstRubros.SelectedValue.ToString()))
                {
                    MessageBox.Show("Ya ha seleccionado ese rubro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            lstRubrosElegidos.Items.Add(lstRubros.SelectedValue.ToString());
        }

        private void cmdBorrarFiltro_Click(object sender, EventArgs e)
        {
            if(lstRubrosElegidos.SelectedIndex == -1){
                MessageBox.Show("Debe seleccionar un rubro", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
              
            lstRubrosElegidos.Items.RemoveAt(lstRubrosElegidos.SelectedIndex);
        }


        private void pedirPublicacionesYOrdenar()
        {
            cmd = new SqlCommand("ROAD_TO_PROYECTO.Buscar_Publicaciones", db.Connection);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@Parametros", SqlDbType.NVarChar).Value = listaDeRubrosFiltros;
            cmd.Parameters.AddWithValue("@PubliDesc", SqlDbType.NVarChar).Value = descripcionFiltros;
            adapter = new SqlDataAdapter(cmd);
            dtPublicaciones = new DataTable("ROAD_TO_PROYECTO.Publicacion");
            adapter.Fill(dtPublicaciones);
            if (yaSeCompro)
            {
                cantidadMaximaDeFilas = dtPublicaciones.Rows.Count;
            }
            


            if (dtPublicaciones.Rows.Count > 0)
            {
              
                this.numPaginas(); //Funcion para calcular el numero total de paginas que tendra nuestra vista
                this.paginar();//empezamos con la paginacion             
                lblCantidadTotal.Text = "Publicaciones Encontradas: " + dtPublicaciones.Rows.Count.ToString();//Cantidad totoal de registros encontrados
                if (!yaSeCompro)
                {
                    cantidadMaximaDeFilas = dtPublicaciones.Rows.Count;
                }
                
                dataGridView1.Select();
                
                
            }
            else
            {
                dataGridView1.Rows.Clear();//En el caso de que la busqueda no genere ningun registro limopiamos el datagridview

                lblCantidadTotal.Text = "Publicaciones Encontradas: 0";
                cantidadMaximaDeFilas = 0;
            }
        }

       

        private void cmdBuscar_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            seSigueCargandoPrimeraPagina = true;
            yaSeCompro = false;
            contadorDeFilas = 0;
            proximaFila = 0;
            filasPagina = 10;
            listaDeRubrosFiltros = "";
            for (int i = 0; i < lstRubrosElegidos.Items.Count ; i++)
            {
                listaDeRubrosFiltros += lstRubrosElegidos.Items[i].ToString() +",";
            }
            descripcionFiltros = txtDescripcion.Text.ToString();
            if(!lstRubrosElegidos.Items.Count.Equals(0))
            {
                    listaDeRubrosFiltros = listaDeRubrosFiltros.TrimEnd(',');
            }
            else {
                listaDeRubrosFiltros = "";
            }

            this.pedirPublicacionesYOrdenar();
           
          

            //listaDeRubrosFiltros = "";
           
        }

        private void cmdLimpiar_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            txtDescripcion.Text = "";
            lstRubrosElegidos.Items.Clear();
            lblCantidadTotal.Text = "";
            lblPaginaActual.Text = "";
            lblTotalPagina.Text = "";

            txtCantidad.Text = "";
            txtGuita.Text ="";
            txtGuita.Visible = false;
            txtCantidad.Visible = false;
            rbEnvioNo.Checked = false;
            rbEnvioSi.Checked = false;
        }

    

        private void cmdVolver_Click_1(object sender, EventArgs e)
        {
            Form1.f1.Show();
            this.Hide();
        }

        private void cmdPrimera_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblTotalPagina.Text) > 1)
            {
                this.nroPagina = 1;

                lblPaginaActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdProxima_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblPaginaActual.Text) < Convert.ToInt32(lblTotalPagina.Text))
            {
                this.nroPagina += 1;


                lblPaginaActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdAnterior_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblPaginaActual.Text) > 1)
            {
                this.nroPagina -= 1;


                lblPaginaActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdUltima_Click_1(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblTotalPagina.Text) > 1)
            {
                this.nroPagina = Convert.ToInt32(lblTotalPagina.Text);

                lblPaginaActual.Text = this.nroPagina.ToString();
                this.paginar();
            }
        }

        private void cmdComprarOfertar_Click(object sender, EventArgs e)
        {
            int val = 0;
            int fila = dataGridView1.CurrentRow.Index;            

            String ofertante = dataGridView1[8, fila].Value.ToString();
            if (compradorID.Equals(ofertante))
            {
                MessageBox.Show("No está permitido comprar una publicación propia", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

           

            String envioOfertante = dataGridView1[9, fila].Value.ToString();
            if (rbEnvioSi.Checked == true && envioOfertante.Equals("No"))
            {
                MessageBox.Show("La publicacion no permite envio", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
          
            if (dataGridView1.CurrentRow == null)
            {

                MessageBox.Show("Debe seleccionar una publicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }

            
            String ofertaOCompra = dataGridView1[7, fila].Value.ToString();
          
            
            if(rbEnvioNo.Checked == false && rbEnvioSi.Checked == false)
            {
                MessageBox.Show("Debe completar la informacion de pago", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            
            if (ofertaOCompra.Equals("Subasta"))
            {
                String valorSubastaString = dataGridView1[5, fila].Value.ToString();
                double valorSubastaDouble = double.Parse(valorSubastaString);
                if(string.IsNullOrEmpty(txtGuita.Text))
                {
                    MessageBox.Show("Debe completar la informacion de pago", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (!string.IsNullOrEmpty(txtGuita.Text))
                {
                    if (!(Int32.TryParse(txtGuita.Text, out val)))
                    {
                        MessageBox.Show("No se permiten letras en el campo de la oferta de la publicacion ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;

                    }
                    else
                    {
                        if (int.Parse(txtGuita.Text) <= 0)
                        {
                            MessageBox.Show("No se permiten valores negativos o cero para la oferta de la publicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                        if (double.Parse(txtGuita.Text) < valorSubastaDouble)
                        {
                             MessageBox.Show("El valor a ofertar debe superar el minimo de la subasta", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }
            }
            if (ofertaOCompra.Equals("Compra Inmediata"))
            {
                String valorStockString = dataGridView1[2, fila].Value.ToString();
                int valorStockInt = int.Parse(valorStockString);
                if (string.IsNullOrEmpty(txtCantidad.Text))
                {
                    MessageBox.Show("Debe completar la informacion de pago", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (!string.IsNullOrEmpty(txtCantidad.Text))
                {
                    if (!(Int32.TryParse(txtCantidad.Text, out val)))
                    {
                        MessageBox.Show("No se permiten letras en el campo de la compra de la publicacion ", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;

                    }
                    else
                    {
                        if (int.Parse(txtCantidad.Text) <= 0)
                        {
                            MessageBox.Show("No se permiten valores negativos o cero para la compra de la publicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                        if (int.Parse(txtCantidad.Text) > valorStockInt)
                        {
                            MessageBox.Show("El valor de stock ingresado supera el stock de la publicacion", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            return;
                        }
                    }
                }
            }
            if (publisSinCalif >= 3)
            {
                MessageBox.Show("Debe calificar las publicaciones que tiene pendientes antes de poder comprar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            
            if (ofertaOCompra.Equals("Subasta"))
            {
                //cash = int.Parse(txtGuita.Text.ToString());
            }
            if (ofertaOCompra.Equals("Compra Inmediata"))
            {
                cantidad = int.Parse(txtCantidad.Text.ToString());
            }  

            int celdaIdPublicacion = int.Parse(dataGridView1[0, fila].Value.ToString());
            
           
            
            String ofertanteID = dataGridView1[8, fila].Value.ToString();
            if(rbEnvioSi.Checked)
            {
                tieneEnvio = 1;
            }
            else {
                tieneEnvio = 0;
            }
            
           

            if (ofertaOCompra == "Compra Inmediata")
            {
                SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Comprar_Publicacion", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = celdaIdPublicacion;
                cmd.Parameters.AddWithValue("@FechaActual", SqlDbType.DateTime).Value = Fecha.getFechaActual();
                cmd.Parameters.AddWithValue("@Cantidad", SqlDbType.Int).Value =  cantidad;
                cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = compradorID;
                cmd.Parameters.AddWithValue("@ConEnvio", SqlDbType.Int).Value = tieneEnvio;

                cmd.ExecuteNonQuery();

                MessageBox.Show("Se ha realizado la compra satisfactoriamente", "Sr.Usuario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);


            }
            if (ofertaOCompra == "Subasta") {
                SqlCommand cmd = new SqlCommand("ROAD_TO_PROYECTO.Ofertar_Publicacion", db.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@PubliId", SqlDbType.Int).Value = celdaIdPublicacion;
                cmd.Parameters.AddWithValue("@FechaActual", SqlDbType.DateTime).Value = Fecha.getFechaActual();
                cmd.Parameters.AddWithValue("@MontoOfertaString", SqlDbType.NVarChar).Value = txtGuita.Text;
                cmd.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = ofertanteID;
                cmd.Parameters.AddWithValue("@ConEnvio", SqlDbType.Int).Value = tieneEnvio;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha ofertado satisfactoriamente", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
           
            yaSeCompro = true;
            this.hacerRefresh();

            txtCantidad.Text = "";
            txtGuita.Text = "";
            txtGuita.Visible = false;
            txtCantidad.Visible = false;
            rbEnvioNo.Checked = false;
            rbEnvioSi.Checked = false;

            cmd2 = new SqlCommand("ROAD_TO_PROYECTO.Cantidad_Compras_Subastas_Sin_Calificar", db.Connection);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@Usuario", SqlDbType.NVarChar).Value = compradorID;

            sdr = cmd2.ExecuteReader();
            sdr.Read();
            publisSinCalif = (int)sdr["cantPublis"];
            sdr.Close();
        
        }        
     
        private void hacerRefresh()
        {
            this.pedirPublicacionesYOrdenar();
            this.irAPagina(nroPagina);
        }

        private void irAPagina(int nroPagina)
        {
            lblPaginaActual.Text = this.nroPagina.ToString();
            this.paginar();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int filaAux = dataGridView1.CurrentRow.Index;
            String ofertaOCompra = dataGridView1[7, filaAux].Value.ToString();
            if (dataGridView1.CurrentRow != null)
            {
                if (ofertaOCompra.Equals("Subasta"))
                {
                    txtCantidad.Visible = false;
                    txtGuita.Visible = true;
                    lblGuita.Visible = true;
                    lblCantidad.Visible = false;

                }
                if (ofertaOCompra.Equals("Compra Inmediata"))
                {
                    txtGuita.Visible = false;
                    txtCantidad.Visible = true;
                    lblGuita.Visible = false;
                    lblCantidad.Visible = true;
                }
            } //timer1.Start();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            WindowsFormsApplication1.Form1.f1.Close();
        }

       
    }
}
        


    
