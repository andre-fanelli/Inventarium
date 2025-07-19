namespace Inventarium
{
    partial class frm_CadPC
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
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.txtProcessador = new System.Windows.Forms.TextBox();
            this.txtRAM = new System.Windows.Forms.TextBox();
            this.txtStorage = new System.Windows.Forms.TextBox();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.txtPatrimonio = new System.Windows.Forms.TextBox();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.lbl_Minimize = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.txtSO = new System.Windows.Forms.TextBox();
            this.ckbProcessador = new System.Windows.Forms.CheckBox();
            this.ckbStorage = new System.Windows.Forms.CheckBox();
            this.ckbFabricante = new System.Windows.Forms.CheckBox();
            this.ckbNS = new System.Windows.Forms.CheckBox();
            this.ckbSO = new System.Windows.Forms.CheckBox();
            this.ckbRAM = new System.Windows.Forms.CheckBox();
            this.ckbHostname = new System.Windows.Forms.CheckBox();
            this.ckbModelo = new System.Windows.Forms.CheckBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnConcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Salvar
            // 
            this.btn_Salvar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btn_Salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salvar.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Salvar.ForeColor = System.Drawing.Color.White;
            this.btn_Salvar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Salvar.Location = new System.Drawing.Point(194, 518);
            this.btn_Salvar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(150, 40);
            this.btn_Salvar.TabIndex = 12;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = false;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cadastro de Computador";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 69);
            this.label2.TabIndex = 5;
            this.label2.Text = "Preencha os campos conforme solicitado. Algumas informações são carregadas automa" +
    "ticamente. Caso haja divergência, faça a correção manualmente.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label3.Location = new System.Drawing.Point(28, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Unidade/Local:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label4.Location = new System.Drawing.Point(194, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Departamento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label5.Location = new System.Drawing.Point(28, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Processador:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label6.Location = new System.Drawing.Point(194, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 22);
            this.label6.TabIndex = 9;
            this.label6.Text = "Qtde RAM (Em GB):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label7.Location = new System.Drawing.Point(28, 266);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 22);
            this.label7.TabIndex = 10;
            this.label7.Text = "HD/SSD (Em GB):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label8.Location = new System.Drawing.Point(194, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 22);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nome da Máquina:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label9.Location = new System.Drawing.Point(28, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 12;
            this.label9.Text = "Fabricante:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label10.Location = new System.Drawing.Point(194, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 22);
            this.label10.TabIndex = 13;
            this.label10.Text = "Modelo:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label11.Location = new System.Drawing.Point(28, 377);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 22);
            this.label11.TabIndex = 14;
            this.label11.Text = "Nº de Série:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label12.Location = new System.Drawing.Point(194, 377);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 22);
            this.label12.TabIndex = 15;
            this.label12.Text = "Nº Patrimônio:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label13.Location = new System.Drawing.Point(28, 430);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 22);
            this.label13.TabIndex = 16;
            this.label13.Text = "S.O.:";
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(28, 185);
            this.txtUnidade.MaxLength = 30;
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(150, 25);
            this.txtUnidade.TabIndex = 1;
            this.txtUnidade.TextChanged += new System.EventHandler(this.txtbox_Unidade_TextChanged);
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(194, 185);
            this.txtDepto.MaxLength = 30;
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(150, 25);
            this.txtDepto.TabIndex = 2;
            // 
            // txtProcessador
            // 
            this.txtProcessador.Location = new System.Drawing.Point(28, 238);
            this.txtProcessador.MaxLength = 50;
            this.txtProcessador.Name = "txtProcessador";
            this.txtProcessador.ReadOnly = true;
            this.txtProcessador.Size = new System.Drawing.Size(150, 25);
            this.txtProcessador.TabIndex = 3;
            // 
            // txtRAM
            // 
            this.txtRAM.Location = new System.Drawing.Point(194, 238);
            this.txtRAM.MaxLength = 3;
            this.txtRAM.Name = "txtRAM";
            this.txtRAM.ReadOnly = true;
            this.txtRAM.Size = new System.Drawing.Size(150, 25);
            this.txtRAM.TabIndex = 4;
            // 
            // txtStorage
            // 
            this.txtStorage.Location = new System.Drawing.Point(28, 291);
            this.txtStorage.MaxLength = 10;
            this.txtStorage.Name = "txtStorage";
            this.txtStorage.ReadOnly = true;
            this.txtStorage.Size = new System.Drawing.Size(150, 25);
            this.txtStorage.TabIndex = 5;
            // 
            // txtHostname
            // 
            this.txtHostname.Location = new System.Drawing.Point(194, 291);
            this.txtHostname.MaxLength = 50;
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.ReadOnly = true;
            this.txtHostname.Size = new System.Drawing.Size(150, 25);
            this.txtHostname.TabIndex = 6;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(28, 349);
            this.txtFabricante.MaxLength = 30;
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.ReadOnly = true;
            this.txtFabricante.Size = new System.Drawing.Size(150, 25);
            this.txtFabricante.TabIndex = 7;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(194, 349);
            this.txtModelo.MaxLength = 30;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(150, 25);
            this.txtModelo.TabIndex = 8;
            // 
            // txtNS
            // 
            this.txtNS.Location = new System.Drawing.Point(28, 402);
            this.txtNS.MaxLength = 50;
            this.txtNS.Name = "txtNS";
            this.txtNS.ReadOnly = true;
            this.txtNS.Size = new System.Drawing.Size(150, 25);
            this.txtNS.TabIndex = 9;
            // 
            // txtPatrimonio
            // 
            this.txtPatrimonio.Location = new System.Drawing.Point(194, 402);
            this.txtPatrimonio.MaxLength = 30;
            this.txtPatrimonio.Name = "txtPatrimonio";
            this.txtPatrimonio.Size = new System.Drawing.Size(150, 25);
            this.txtPatrimonio.TabIndex = 10;
            // 
            // btn_Voltar
            // 
            this.btn_Voltar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Voltar.BackColor = System.Drawing.Color.White;
            this.btn_Voltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Voltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Voltar.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Voltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btn_Voltar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Voltar.Location = new System.Drawing.Point(28, 518);
            this.btn_Voltar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(150, 40);
            this.btn_Voltar.TabIndex = 13;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = false;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
            // 
            // lbl_Minimize
            // 
            this.lbl_Minimize.AutoSize = true;
            this.lbl_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Minimize.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.lbl_Minimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Minimize.Location = new System.Drawing.Point(354, 2);
            this.lbl_Minimize.Name = "lbl_Minimize";
            this.lbl_Minimize.Size = new System.Drawing.Size(22, 24);
            this.lbl_Minimize.TabIndex = 30;
            this.lbl_Minimize.Text = "_";
            this.lbl_Minimize.Click += new System.EventHandler(this.lbl_Minimize_Click);
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.lbl_Close.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Close.Location = new System.Drawing.Point(373, 2);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(24, 24);
            this.lbl_Close.TabIndex = 29;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // txtSO
            // 
            this.txtSO.Location = new System.Drawing.Point(28, 455);
            this.txtSO.MaxLength = 30;
            this.txtSO.Name = "txtSO";
            this.txtSO.ReadOnly = true;
            this.txtSO.Size = new System.Drawing.Size(150, 25);
            this.txtSO.TabIndex = 11;
            // 
            // ckbProcessador
            // 
            this.ckbProcessador.AutoSize = true;
            this.ckbProcessador.ForeColor = System.Drawing.Color.Transparent;
            this.ckbProcessador.Location = new System.Drawing.Point(10, 246);
            this.ckbProcessador.Name = "ckbProcessador";
            this.ckbProcessador.Size = new System.Drawing.Size(15, 14);
            this.ckbProcessador.TabIndex = 32;
            this.ckbProcessador.UseVisualStyleBackColor = true;
            this.ckbProcessador.Visible = false;
            this.ckbProcessador.CheckedChanged += new System.EventHandler(this.ckbProcessador_CheckedChanged);
            // 
            // ckbStorage
            // 
            this.ckbStorage.AutoSize = true;
            this.ckbStorage.ForeColor = System.Drawing.Color.Transparent;
            this.ckbStorage.Location = new System.Drawing.Point(10, 299);
            this.ckbStorage.Name = "ckbStorage";
            this.ckbStorage.Size = new System.Drawing.Size(15, 14);
            this.ckbStorage.TabIndex = 33;
            this.ckbStorage.UseVisualStyleBackColor = true;
            this.ckbStorage.Visible = false;
            this.ckbStorage.CheckedChanged += new System.EventHandler(this.ckbStorage_CheckedChanged);
            // 
            // ckbFabricante
            // 
            this.ckbFabricante.AutoSize = true;
            this.ckbFabricante.ForeColor = System.Drawing.Color.Transparent;
            this.ckbFabricante.Location = new System.Drawing.Point(10, 357);
            this.ckbFabricante.Name = "ckbFabricante";
            this.ckbFabricante.Size = new System.Drawing.Size(15, 14);
            this.ckbFabricante.TabIndex = 34;
            this.ckbFabricante.UseVisualStyleBackColor = true;
            this.ckbFabricante.Visible = false;
            this.ckbFabricante.CheckedChanged += new System.EventHandler(this.ckbFabricante_CheckedChanged);
            // 
            // ckbNS
            // 
            this.ckbNS.AutoSize = true;
            this.ckbNS.ForeColor = System.Drawing.Color.Transparent;
            this.ckbNS.Location = new System.Drawing.Point(10, 410);
            this.ckbNS.Name = "ckbNS";
            this.ckbNS.Size = new System.Drawing.Size(15, 14);
            this.ckbNS.TabIndex = 35;
            this.ckbNS.UseVisualStyleBackColor = true;
            this.ckbNS.Visible = false;
            this.ckbNS.CheckedChanged += new System.EventHandler(this.ckbNS_CheckedChanged);
            // 
            // ckbSO
            // 
            this.ckbSO.AutoSize = true;
            this.ckbSO.ForeColor = System.Drawing.Color.Transparent;
            this.ckbSO.Location = new System.Drawing.Point(10, 463);
            this.ckbSO.Name = "ckbSO";
            this.ckbSO.Size = new System.Drawing.Size(15, 14);
            this.ckbSO.TabIndex = 36;
            this.ckbSO.UseVisualStyleBackColor = true;
            this.ckbSO.Visible = false;
            this.ckbSO.CheckedChanged += new System.EventHandler(this.ckbSO_CheckedChanged);
            // 
            // ckbRAM
            // 
            this.ckbRAM.AutoSize = true;
            this.ckbRAM.ForeColor = System.Drawing.Color.Transparent;
            this.ckbRAM.Location = new System.Drawing.Point(350, 246);
            this.ckbRAM.Name = "ckbRAM";
            this.ckbRAM.Size = new System.Drawing.Size(15, 14);
            this.ckbRAM.TabIndex = 37;
            this.ckbRAM.UseVisualStyleBackColor = true;
            this.ckbRAM.Visible = false;
            this.ckbRAM.CheckedChanged += new System.EventHandler(this.ckbRAM_CheckedChanged);
            // 
            // ckbHostname
            // 
            this.ckbHostname.AutoSize = true;
            this.ckbHostname.ForeColor = System.Drawing.Color.Transparent;
            this.ckbHostname.Location = new System.Drawing.Point(350, 299);
            this.ckbHostname.Name = "ckbHostname";
            this.ckbHostname.Size = new System.Drawing.Size(15, 14);
            this.ckbHostname.TabIndex = 38;
            this.ckbHostname.UseVisualStyleBackColor = true;
            this.ckbHostname.Visible = false;
            this.ckbHostname.CheckedChanged += new System.EventHandler(this.ckbHostname_CheckedChanged);
            // 
            // ckbModelo
            // 
            this.ckbModelo.AutoSize = true;
            this.ckbModelo.ForeColor = System.Drawing.Color.Transparent;
            this.ckbModelo.Location = new System.Drawing.Point(350, 357);
            this.ckbModelo.Name = "ckbModelo";
            this.ckbModelo.Size = new System.Drawing.Size(15, 14);
            this.ckbModelo.TabIndex = 39;
            this.ckbModelo.UseVisualStyleBackColor = true;
            this.ckbModelo.Visible = false;
            this.ckbModelo.CheckedChanged += new System.EventHandler(this.ckbModelo_CheckedChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditar.Location = new System.Drawing.Point(194, 448);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(150, 40);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnConcluir
            // 
            this.btnConcluir.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnConcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btnConcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConcluir.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConcluir.ForeColor = System.Drawing.Color.White;
            this.btnConcluir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnConcluir.Location = new System.Drawing.Point(194, 448);
            this.btnConcluir.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btnConcluir.Name = "btnConcluir";
            this.btnConcluir.Size = new System.Drawing.Size(150, 40);
            this.btnConcluir.TabIndex = 15;
            this.btnConcluir.Text = "Concluir";
            this.btnConcluir.UseVisualStyleBackColor = false;
            this.btnConcluir.Visible = false;
            this.btnConcluir.Click += new System.EventHandler(this.btnConcluir_Click);
            // 
            // frm_CadPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = global::Inventarium.Properties.Resources.bg__400x600_;
            this.ClientSize = new System.Drawing.Size(400, 600);
            this.Controls.Add(this.btnConcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.ckbModelo);
            this.Controls.Add(this.ckbHostname);
            this.Controls.Add(this.ckbRAM);
            this.Controls.Add(this.ckbSO);
            this.Controls.Add(this.ckbNS);
            this.Controls.Add(this.ckbFabricante);
            this.Controls.Add(this.ckbStorage);
            this.Controls.Add(this.ckbProcessador);
            this.Controls.Add(this.txtSO);
            this.Controls.Add(this.lbl_Minimize);
            this.Controls.Add(this.lbl_Close);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.txtPatrimonio);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.txtHostname);
            this.Controls.Add(this.txtStorage);
            this.Controls.Add(this.txtRAM);
            this.Controls.Add(this.txtProcessador);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Salvar);
            this.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CadPC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_CadPC";
            this.Load += new System.EventHandler(this.frm_CadPC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Salvar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private TextBox txtUnidade;
        private TextBox txtDepto;
        private TextBox txtProcessador;
        private TextBox txtRAM;
        private TextBox txtStorage;
        private TextBox txtHostname;
        private TextBox txtFabricante;
        private TextBox txtModelo;
        private TextBox txtNS;
        private TextBox txtPatrimonio;
        private Button btn_Voltar;
        private Label lbl_Minimize;
        private Label lbl_Close;
        private TextBox txtSO;
        private CheckBox ckbProcessador;
        private CheckBox ckbStorage;
        private CheckBox ckbFabricante;
        private CheckBox ckbNS;
        private CheckBox ckbSO;
        private CheckBox ckbRAM;
        private CheckBox ckbHostname;
        private CheckBox ckbModelo;
        private Button btnEditar;
        private Button btnConcluir;
    }
}