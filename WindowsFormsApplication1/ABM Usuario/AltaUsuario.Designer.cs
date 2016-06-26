namespace WindowsFormsApplication1.ABM_Usuario
{
    partial class AltaUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCampos = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdBorrar = new System.Windows.Forms.Button();
            this.lblTipoDNICliente = new System.Windows.Forms.Label();
            this.lblNroDocCliente = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.lblApellidoCliente = new System.Windows.Forms.Label();
            this.dtpCreacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNacCliente = new System.Windows.Forms.Label();
            this.lblTelCliente = new System.Windows.Forms.Label();
            this.lblDom = new System.Windows.Forms.Label();
            this.lblCalle = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblPiso = new System.Windows.Forms.Label();
            this.lblDpto = new System.Windows.Forms.Label();
            this.lblLocal = new System.Windows.Forms.Label();
            this.lblCodPos = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.txtApellidoCliente = new System.Windows.Forms.TextBox();
            this.txtDNICliente = new System.Windows.Forms.TextBox();
            this.txtTelCliente = new System.Windows.Forms.TextBox();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtPiso = new System.Windows.Forms.TextBox();
            this.txtDpto = new System.Windows.Forms.TextBox();
            this.txtCodPos = new System.Windows.Forms.TextBox();
            this.txtLocalidad = new System.Windows.Forms.TextBox();
            this.lblRazonEmpresa = new System.Windows.Forms.Label();
            this.lblCUITEmpresa = new System.Windows.Forms.Label();
            this.lblFechaEmpresa = new System.Windows.Forms.Label();
            this.lblNombreEmpresa = new System.Windows.Forms.Label();
            this.lblTelefonoEmpresa = new System.Windows.Forms.Label();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbEmpresa = new System.Windows.Forms.RadioButton();
            this.txtRazonEmpresa = new System.Windows.Forms.TextBox();
            this.txtCUITEmpresa = new System.Windows.Forms.TextBox();
            this.txtNombreContEmpresa = new System.Windows.Forms.TextBox();
            this.txtTelEmpresa = new System.Windows.Forms.TextBox();
            this.cmdVolver = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblRubroEmpresa = new System.Windows.Forms.Label();
            this.lblCiudadEmpresa = new System.Windows.Forms.Label();
            this.txtCiudadEmpresa = new System.Windows.Forms.TextBox();
            this.cboTipoCliente = new System.Windows.Forms.ComboBox();
            this.cboRubro = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 72);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo de Usuario";
            // 
            // lblCampos
            // 
            this.lblCampos.AllowDrop = true;
            this.lblCampos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCampos.Location = new System.Drawing.Point(126, 42);
            this.lblCampos.Name = "lblCampos";
            this.lblCampos.Size = new System.Drawing.Size(368, 491);
            this.lblCampos.TabIndex = 3;
            this.lblCampos.Text = "(*) Campos obligatorios";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(139, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(139, 63);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(112, 13);
            this.lblNombreUsuario.TabIndex = 5;
            this.lblNombreUsuario.Text = "(*) Nombre de usuario:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(183, 86);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "(*) Password:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(210, 109);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(42, 13);
            this.lblMail.TabIndex = 7;
            this.lblMail.Text = "(*) Mail:";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.Color.LimeGreen;
            this.cmdAceptar.Location = new System.Drawing.Point(22, 126);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(75, 56);
            this.cmdAceptar.TabIndex = 8;
            this.cmdAceptar.Text = "Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdBorrar
            // 
            this.cmdBorrar.BackColor = System.Drawing.Color.IndianRed;
            this.cmdBorrar.Location = new System.Drawing.Point(22, 199);
            this.cmdBorrar.Name = "cmdBorrar";
            this.cmdBorrar.Size = new System.Drawing.Size(75, 51);
            this.cmdBorrar.TabIndex = 9;
            this.cmdBorrar.Text = "Borrar todo";
            this.cmdBorrar.UseVisualStyleBackColor = false;
            this.cmdBorrar.Click += new System.EventHandler(this.cmdBorrar_Click);
            // 
            // lblTipoDNICliente
            // 
            this.lblTipoDNICliente.AutoSize = true;
            this.lblTipoDNICliente.Location = new System.Drawing.Point(187, 199);
            this.lblTipoDNICliente.Name = "lblTipoDNICliente";
            this.lblTipoDNICliente.Size = new System.Drawing.Size(67, 13);
            this.lblTipoDNICliente.TabIndex = 10;
            this.lblTipoDNICliente.Text = "(*)Tipo DOC:";
            // 
            // lblNroDocCliente
            // 
            this.lblNroDocCliente.AutoSize = true;
            this.lblNroDocCliente.Location = new System.Drawing.Point(155, 221);
            this.lblNroDocCliente.Name = "lblNroDocCliente";
            this.lblNroDocCliente.Size = new System.Drawing.Size(95, 13);
            this.lblNroDocCliente.TabIndex = 11;
            this.lblNroDocCliente.Text = "(*)Nro Documento:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 285);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 12;
            // 
            // lblNombreCliente
            // 
            this.lblNombreCliente.AutoSize = true;
            this.lblNombreCliente.Location = new System.Drawing.Point(192, 134);
            this.lblNombreCliente.Name = "lblNombreCliente";
            this.lblNombreCliente.Size = new System.Drawing.Size(60, 13);
            this.lblNombreCliente.TabIndex = 13;
            this.lblNombreCliente.Text = "(*) Nombre:";
            // 
            // lblApellidoCliente
            // 
            this.lblApellidoCliente.AutoSize = true;
            this.lblApellidoCliente.Location = new System.Drawing.Point(193, 158);
            this.lblApellidoCliente.Name = "lblApellidoCliente";
            this.lblApellidoCliente.Size = new System.Drawing.Size(60, 13);
            this.lblApellidoCliente.TabIndex = 14;
            this.lblApellidoCliente.Text = "(*) Apellido:";
            // 
            // dtpCreacion
            // 
            this.dtpCreacion.Location = new System.Drawing.Point(257, 178);
            this.dtpCreacion.Name = "dtpCreacion";
            this.dtpCreacion.Size = new System.Drawing.Size(189, 20);
            this.dtpCreacion.TabIndex = 15;
            // 
            // lblFechaNacCliente
            // 
            this.lblFechaNacCliente.AutoSize = true;
            this.lblFechaNacCliente.Location = new System.Drawing.Point(143, 179);
            this.lblFechaNacCliente.Name = "lblFechaNacCliente";
            this.lblFechaNacCliente.Size = new System.Drawing.Size(109, 13);
            this.lblFechaNacCliente.TabIndex = 16;
            this.lblFechaNacCliente.Text = "(*) Fecha Nacimiento:";
            // 
            // lblTelCliente
            // 
            this.lblTelCliente.AutoSize = true;
            this.lblTelCliente.Location = new System.Drawing.Point(184, 242);
            this.lblTelCliente.Name = "lblTelCliente";
            this.lblTelCliente.Size = new System.Drawing.Size(65, 13);
            this.lblTelCliente.TabIndex = 17;
            this.lblTelCliente.Text = "(*) Telefono:";
            // 
            // lblDom
            // 
            this.lblDom.AllowDrop = true;
            this.lblDom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDom.Location = new System.Drawing.Point(146, 328);
            this.lblDom.Name = "lblDom";
            this.lblDom.Size = new System.Drawing.Size(286, 200);
            this.lblDom.TabIndex = 19;
            this.lblDom.Text = "(*) Domicilio";
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(209, 368);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 20;
            this.lblCalle.Text = "Calle:";
            // 
            // lblNum
            // 
            this.lblNum.AutoSize = true;
            this.lblNum.Location = new System.Drawing.Point(194, 391);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(50, 13);
            this.lblNum.TabIndex = 21;
            this.lblNum.Text = " Numero:";
            // 
            // lblPiso
            // 
            this.lblPiso.AutoSize = true;
            this.lblPiso.Location = new System.Drawing.Point(209, 418);
            this.lblPiso.Name = "lblPiso";
            this.lblPiso.Size = new System.Drawing.Size(33, 13);
            this.lblPiso.TabIndex = 22;
            this.lblPiso.Text = " Piso:";
            // 
            // lblDpto
            // 
            this.lblDpto.AutoSize = true;
            this.lblDpto.Location = new System.Drawing.Point(163, 440);
            this.lblDpto.Name = "lblDpto";
            this.lblDpto.Size = new System.Drawing.Size(80, 13);
            this.lblDpto.TabIndex = 23;
            this.lblDpto.Text = " Departamento:";
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.Location = new System.Drawing.Point(184, 495);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(59, 13);
            this.lblLocal.TabIndex = 24;
            this.lblLocal.Text = " Localidad:";
            // 
            // lblCodPos
            // 
            this.lblCodPos.AutoSize = true;
            this.lblCodPos.Location = new System.Drawing.Point(165, 469);
            this.lblCodPos.Name = "lblCodPos";
            this.lblCodPos.Size = new System.Drawing.Size(78, 13);
            this.lblCodPos.TabIndex = 25;
            this.lblCodPos.Text = " Codigo Postal:";
            this.lblCodPos.Click += new System.EventHandler(this.label20_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(257, 60);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 26;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(257, 83);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 27;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(257, 108);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(100, 20);
            this.txtMail.TabIndex = 28;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(257, 132);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCliente.TabIndex = 29;
            // 
            // txtApellidoCliente
            // 
            this.txtApellidoCliente.Location = new System.Drawing.Point(257, 155);
            this.txtApellidoCliente.Name = "txtApellidoCliente";
            this.txtApellidoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoCliente.TabIndex = 30;
            // 
            // txtDNICliente
            // 
            this.txtDNICliente.Location = new System.Drawing.Point(257, 219);
            this.txtDNICliente.Name = "txtDNICliente";
            this.txtDNICliente.Size = new System.Drawing.Size(100, 20);
            this.txtDNICliente.TabIndex = 32;
            // 
            // txtTelCliente
            // 
            this.txtTelCliente.Location = new System.Drawing.Point(257, 242);
            this.txtTelCliente.Name = "txtTelCliente";
            this.txtTelCliente.Size = new System.Drawing.Size(100, 20);
            this.txtTelCliente.TabIndex = 33;
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(253, 365);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(100, 20);
            this.txtCalle.TabIndex = 34;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(253, 391);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(100, 20);
            this.txtNumero.TabIndex = 35;
            // 
            // txtPiso
            // 
            this.txtPiso.Location = new System.Drawing.Point(253, 417);
            this.txtPiso.Name = "txtPiso";
            this.txtPiso.Size = new System.Drawing.Size(100, 20);
            this.txtPiso.TabIndex = 36;
            // 
            // txtDpto
            // 
            this.txtDpto.Location = new System.Drawing.Point(253, 440);
            this.txtDpto.Name = "txtDpto";
            this.txtDpto.Size = new System.Drawing.Size(100, 20);
            this.txtDpto.TabIndex = 37;
            // 
            // txtCodPos
            // 
            this.txtCodPos.Location = new System.Drawing.Point(253, 469);
            this.txtCodPos.Name = "txtCodPos";
            this.txtCodPos.Size = new System.Drawing.Size(100, 20);
            this.txtCodPos.TabIndex = 38;
            // 
            // txtLocalidad
            // 
            this.txtLocalidad.Location = new System.Drawing.Point(253, 495);
            this.txtLocalidad.Name = "txtLocalidad";
            this.txtLocalidad.Size = new System.Drawing.Size(100, 20);
            this.txtLocalidad.TabIndex = 39;
            // 
            // lblRazonEmpresa
            // 
            this.lblRazonEmpresa.AutoSize = true;
            this.lblRazonEmpresa.Location = new System.Drawing.Point(166, 134);
            this.lblRazonEmpresa.Name = "lblRazonEmpresa";
            this.lblRazonEmpresa.Size = new System.Drawing.Size(86, 13);
            this.lblRazonEmpresa.TabIndex = 40;
            this.lblRazonEmpresa.Text = "(*) Razon Social:";
            // 
            // lblCUITEmpresa
            // 
            this.lblCUITEmpresa.AutoSize = true;
            this.lblCUITEmpresa.Location = new System.Drawing.Point(193, 158);
            this.lblCUITEmpresa.Name = "lblCUITEmpresa";
            this.lblCUITEmpresa.Size = new System.Drawing.Size(57, 13);
            this.lblCUITEmpresa.TabIndex = 41;
            this.lblCUITEmpresa.Text = "(*) C.U.I.T:";
            // 
            // lblFechaEmpresa
            // 
            this.lblFechaEmpresa.AutoSize = true;
            this.lblFechaEmpresa.Location = new System.Drawing.Point(151, 179);
            this.lblFechaEmpresa.Name = "lblFechaEmpresa";
            this.lblFechaEmpresa.Size = new System.Drawing.Size(98, 13);
            this.lblFechaEmpresa.TabIndex = 42;
            this.lblFechaEmpresa.Text = "(*) Fecha Creacion:";
            // 
            // lblNombreEmpresa
            // 
            this.lblNombreEmpresa.AutoSize = true;
            this.lblNombreEmpresa.Location = new System.Drawing.Point(145, 199);
            this.lblNombreEmpresa.Name = "lblNombreEmpresa";
            this.lblNombreEmpresa.Size = new System.Drawing.Size(106, 13);
            this.lblNombreEmpresa.TabIndex = 43;
            this.lblNombreEmpresa.Text = "(*) Nombre Contacto:";
            // 
            // lblTelefonoEmpresa
            // 
            this.lblTelefonoEmpresa.AutoSize = true;
            this.lblTelefonoEmpresa.Location = new System.Drawing.Point(187, 221);
            this.lblTelefonoEmpresa.Name = "lblTelefonoEmpresa";
            this.lblTelefonoEmpresa.Size = new System.Drawing.Size(62, 13);
            this.lblTelefonoEmpresa.TabIndex = 44;
            this.lblTelefonoEmpresa.Text = "(*)Telefono:";
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(22, 63);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(57, 17);
            this.rbCliente.TabIndex = 46;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            this.rbCliente.CheckedChanged += new System.EventHandler(this.rbCliente_CheckedChanged);
            // 
            // rbEmpresa
            // 
            this.rbEmpresa.AutoSize = true;
            this.rbEmpresa.Location = new System.Drawing.Point(22, 86);
            this.rbEmpresa.Name = "rbEmpresa";
            this.rbEmpresa.Size = new System.Drawing.Size(66, 17);
            this.rbEmpresa.TabIndex = 47;
            this.rbEmpresa.Text = "Empresa";
            this.rbEmpresa.UseVisualStyleBackColor = true;
            // 
            // txtRazonEmpresa
            // 
            this.txtRazonEmpresa.Location = new System.Drawing.Point(257, 132);
            this.txtRazonEmpresa.Name = "txtRazonEmpresa";
            this.txtRazonEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtRazonEmpresa.TabIndex = 48;
            // 
            // txtCUITEmpresa
            // 
            this.txtCUITEmpresa.Location = new System.Drawing.Point(257, 155);
            this.txtCUITEmpresa.Name = "txtCUITEmpresa";
            this.txtCUITEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtCUITEmpresa.TabIndex = 49;
            // 
            // txtNombreContEmpresa
            // 
            this.txtNombreContEmpresa.Location = new System.Drawing.Point(257, 196);
            this.txtNombreContEmpresa.Name = "txtNombreContEmpresa";
            this.txtNombreContEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtNombreContEmpresa.TabIndex = 50;
            // 
            // txtTelEmpresa
            // 
            this.txtTelEmpresa.Location = new System.Drawing.Point(257, 219);
            this.txtTelEmpresa.Name = "txtTelEmpresa";
            this.txtTelEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtTelEmpresa.TabIndex = 51;
            // 
            // cmdVolver
            // 
            this.cmdVolver.BackColor = System.Drawing.Color.Cyan;
            this.cmdVolver.Location = new System.Drawing.Point(22, 265);
            this.cmdVolver.Name = "cmdVolver";
            this.cmdVolver.Size = new System.Drawing.Size(75, 53);
            this.cmdVolver.TabIndex = 52;
            this.cmdVolver.Text = "Volver";
            this.cmdVolver.UseVisualStyleBackColor = false;
            this.cmdVolver.Click += new System.EventHandler(this.cmdVolver_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(514, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.NavajoWhite;
            this.statusStrip1.Location = new System.Drawing.Point(0, 568);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(514, 22);
            this.statusStrip1.TabIndex = 54;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblRubroEmpresa
            // 
            this.lblRubroEmpresa.AutoSize = true;
            this.lblRubroEmpresa.Location = new System.Drawing.Point(204, 272);
            this.lblRubroEmpresa.Name = "lblRubroEmpresa";
            this.lblRubroEmpresa.Size = new System.Drawing.Size(49, 13);
            this.lblRubroEmpresa.TabIndex = 55;
            this.lblRubroEmpresa.Text = "(*)Rubro:";
            // 
            // lblCiudadEmpresa
            // 
            this.lblCiudadEmpresa.AutoSize = true;
            this.lblCiudadEmpresa.Location = new System.Drawing.Point(214, 299);
            this.lblCiudadEmpresa.Name = "lblCiudadEmpresa";
            this.lblCiudadEmpresa.Size = new System.Drawing.Size(43, 13);
            this.lblCiudadEmpresa.TabIndex = 58;
            this.lblCiudadEmpresa.Text = "Ciudad:";
            // 
            // txtCiudadEmpresa
            // 
            this.txtCiudadEmpresa.Location = new System.Drawing.Point(257, 295);
            this.txtCiudadEmpresa.Name = "txtCiudadEmpresa";
            this.txtCiudadEmpresa.Size = new System.Drawing.Size(100, 20);
            this.txtCiudadEmpresa.TabIndex = 59;
            // 
            // cboTipoCliente
            // 
            this.cboTipoCliente.FormattingEnabled = true;
            this.cboTipoCliente.Items.AddRange(new object[] {
            "DNI",
            "LC",
            "LE",
            "CI"});
            this.cboTipoCliente.Location = new System.Drawing.Point(257, 196);
            this.cboTipoCliente.Name = "cboTipoCliente";
            this.cboTipoCliente.Size = new System.Drawing.Size(100, 21);
            this.cboTipoCliente.TabIndex = 60;
            this.cboTipoCliente.Text = "Seleccione un tipo de documento";
            // 
            // cboRubro
            // 
            this.cboRubro.FormattingEnabled = true;
            this.cboRubro.Location = new System.Drawing.Point(257, 268);
            this.cboRubro.Name = "cboRubro";
            this.cboRubro.Size = new System.Drawing.Size(189, 21);
            this.cboRubro.TabIndex = 61;
            // 
            // AltaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(514, 590);
            this.Controls.Add(this.cboRubro);
            this.Controls.Add(this.cboTipoCliente);
            this.Controls.Add(this.txtCiudadEmpresa);
            this.Controls.Add(this.lblCiudadEmpresa);
            this.Controls.Add(this.lblRubroEmpresa);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cmdVolver);
            this.Controls.Add(this.txtTelEmpresa);
            this.Controls.Add(this.txtNombreContEmpresa);
            this.Controls.Add(this.txtCUITEmpresa);
            this.Controls.Add(this.txtRazonEmpresa);
            this.Controls.Add(this.rbEmpresa);
            this.Controls.Add(this.rbCliente);
            this.Controls.Add(this.lblTelefonoEmpresa);
            this.Controls.Add(this.lblNombreEmpresa);
            this.Controls.Add(this.lblFechaEmpresa);
            this.Controls.Add(this.lblCUITEmpresa);
            this.Controls.Add(this.lblRazonEmpresa);
            this.Controls.Add(this.txtLocalidad);
            this.Controls.Add(this.txtCodPos);
            this.Controls.Add(this.txtDpto);
            this.Controls.Add(this.txtPiso);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.txtTelCliente);
            this.Controls.Add(this.txtDNICliente);
            this.Controls.Add(this.txtApellidoCliente);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtMail);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblCodPos);
            this.Controls.Add(this.lblLocal);
            this.Controls.Add(this.lblDpto);
            this.Controls.Add(this.lblPiso);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.lblDom);
            this.Controls.Add(this.lblTelCliente);
            this.Controls.Add(this.lblFechaNacCliente);
            this.Controls.Add(this.dtpCreacion);
            this.Controls.Add(this.lblApellidoCliente);
            this.Controls.Add(this.lblNombreCliente);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblNroDocCliente);
            this.Controls.Add(this.lblTipoDNICliente);
            this.Controls.Add(this.cmdBorrar);
            this.Controls.Add(this.cmdAceptar);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblNombreUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCampos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AltaUsuario";
            this.Text = "(*) Nombre";
            this.Load += new System.EventHandler(this.AltaUsuario_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCampos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.Button cmdAceptar;
        private System.Windows.Forms.Button cmdBorrar;
        private System.Windows.Forms.Label lblTipoDNICliente;
        private System.Windows.Forms.Label lblNroDocCliente;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.Label lblApellidoCliente;
        private System.Windows.Forms.Label lblFechaNacCliente;
        private System.Windows.Forms.Label lblTelCliente;
        private System.Windows.Forms.Label lblDom;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblPiso;
        private System.Windows.Forms.Label lblDpto;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblCodPos;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblRazonEmpresa;
        private System.Windows.Forms.Label lblCUITEmpresa;
        private System.Windows.Forms.Label lblFechaEmpresa;
        private System.Windows.Forms.Label lblNombreEmpresa;
        private System.Windows.Forms.Label lblTelefonoEmpresa;
        private System.Windows.Forms.Button cmdVolver;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label lblRubroEmpresa;
        public System.Windows.Forms.DateTimePicker dtpCreacion;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtPassword;
        public System.Windows.Forms.TextBox txtMail;
        public System.Windows.Forms.TextBox txtNombreCliente;
        public System.Windows.Forms.TextBox txtApellidoCliente;
        public System.Windows.Forms.TextBox txtDNICliente;
        public System.Windows.Forms.TextBox txtTelCliente;
        public System.Windows.Forms.TextBox txtCalle;
        public System.Windows.Forms.TextBox txtNumero;
        public System.Windows.Forms.TextBox txtPiso;
        public System.Windows.Forms.TextBox txtDpto;
        public System.Windows.Forms.TextBox txtCodPos;
        public System.Windows.Forms.TextBox txtLocalidad;
        public System.Windows.Forms.RadioButton rbCliente;
        public System.Windows.Forms.RadioButton rbEmpresa;
        public System.Windows.Forms.TextBox txtRazonEmpresa;
        public System.Windows.Forms.TextBox txtCUITEmpresa;
        public System.Windows.Forms.TextBox txtNombreContEmpresa;
        public System.Windows.Forms.TextBox txtTelEmpresa;
        private System.Windows.Forms.Label lblCiudadEmpresa;
        public System.Windows.Forms.TextBox txtCiudadEmpresa;
        public System.Windows.Forms.ComboBox cboTipoCliente;
        public System.Windows.Forms.ComboBox cboRubro;
    }
}