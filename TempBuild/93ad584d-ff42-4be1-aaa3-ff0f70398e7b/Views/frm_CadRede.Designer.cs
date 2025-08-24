namespace Inventarium
{
    partial class frm_CadRede
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
            this.cboxTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Voltar = new System.Windows.Forms.Button();
            this.btn_Salvar = new System.Windows.Forms.Button();
            this.txtPatrimonio = new System.Windows.Forms.TextBox();
            this.txtNS = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtFabricante = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDepto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUnidade = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Minimize = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxTipo
            // 
            this.cboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipo.FormattingEnabled = true;
            this.cboxTipo.Items.AddRange(new object[] {
            "Switch",
            "Roteador Sem Fio",
            "Access Point",
            "Modem"});
            this.cboxTipo.Location = new System.Drawing.Point(43, 289);
            this.cboxTipo.Name = "cboxTipo";
            this.cboxTipo.Size = new System.Drawing.Size(150, 30);
            this.cboxTipo.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(43, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 22);
            this.label6.TabIndex = 115;
            this.label6.Text = "Tipo:";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(65, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 33);
            this.label4.TabIndex = 114;
            this.label4.Text = "Preencha os campos conforme solicitado.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btn_Voltar.Location = new System.Drawing.Point(43, 404);
            this.btn_Voltar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_Voltar.Name = "btn_Voltar";
            this.btn_Voltar.Size = new System.Drawing.Size(150, 40);
            this.btn_Voltar.TabIndex = 104;
            this.btn_Voltar.Text = "Voltar";
            this.btn_Voltar.UseVisualStyleBackColor = false;
            this.btn_Voltar.Click += new System.EventHandler(this.btn_Voltar_Click);
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
            this.btn_Salvar.Location = new System.Drawing.Point(209, 404);
            this.btn_Salvar.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.btn_Salvar.Name = "btn_Salvar";
            this.btn_Salvar.Size = new System.Drawing.Size(150, 40);
            this.btn_Salvar.TabIndex = 103;
            this.btn_Salvar.Text = "Salvar";
            this.btn_Salvar.UseVisualStyleBackColor = false;
            this.btn_Salvar.Click += new System.EventHandler(this.btn_Salvar_Click);
            // 
            // txtPatrimonio
            // 
            this.txtPatrimonio.Location = new System.Drawing.Point(43, 347);
            this.txtPatrimonio.Name = "txtPatrimonio";
            this.txtPatrimonio.Size = new System.Drawing.Size(150, 25);
            this.txtPatrimonio.TabIndex = 102;
            // 
            // txtNS
            // 
            this.txtNS.Location = new System.Drawing.Point(207, 289);
            this.txtNS.Name = "txtNS";
            this.txtNS.Size = new System.Drawing.Size(150, 25);
            this.txtNS.TabIndex = 101;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(206, 236);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(150, 25);
            this.txtModelo.TabIndex = 99;
            // 
            // txtFabricante
            // 
            this.txtFabricante.Location = new System.Drawing.Point(43, 236);
            this.txtFabricante.Name = "txtFabricante";
            this.txtFabricante.Size = new System.Drawing.Size(150, 25);
            this.txtFabricante.TabIndex = 98;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(43, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 22);
            this.label12.TabIndex = 113;
            this.label12.Text = "Nº Patrimônio:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(209, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 22);
            this.label11.TabIndex = 112;
            this.label11.Text = "Nº de Série:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(209, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 22);
            this.label10.TabIndex = 111;
            this.label10.Text = "Modelo:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(43, 211);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 22);
            this.label9.TabIndex = 110;
            this.label9.Text = "Fabricante:";
            // 
            // txtDepto
            // 
            this.txtDepto.Location = new System.Drawing.Point(206, 182);
            this.txtDepto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDepto.Name = "txtDepto";
            this.txtDepto.Size = new System.Drawing.Size(150, 25);
            this.txtDepto.TabIndex = 97;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(206, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 22);
            this.label2.TabIndex = 109;
            this.label2.Text = "Departamento:";
            // 
            // txtUnidade
            // 
            this.txtUnidade.Location = new System.Drawing.Point(43, 182);
            this.txtUnidade.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUnidade.Name = "txtUnidade";
            this.txtUnidade.Size = new System.Drawing.Size(150, 25);
            this.txtUnidade.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(43, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 108;
            this.label3.Text = "Unidade/Local:";
            // 
            // lbl_Minimize
            // 
            this.lbl_Minimize.AutoSize = true;
            this.lbl_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Minimize.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.lbl_Minimize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lbl_Minimize.Location = new System.Drawing.Point(355, 1);
            this.lbl_Minimize.Name = "lbl_Minimize";
            this.lbl_Minimize.Size = new System.Drawing.Size(22, 24);
            this.lbl_Minimize.TabIndex = 107;
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
            this.lbl_Close.Location = new System.Drawing.Point(374, 1);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(24, 24);
            this.lbl_Close.TabIndex = 106;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 37);
            this.label1.TabIndex = 105;
            this.label1.Text = "Cadastro de Ativos de Rede";
            // 
            // frm_CadRede
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Inventarium.Properties.Resources.bg;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.cboxTipo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_Voltar);
            this.Controls.Add(this.btn_Salvar);
            this.Controls.Add(this.txtPatrimonio);
            this.Controls.Add(this.txtNS);
            this.Controls.Add(this.txtModelo);
            this.Controls.Add(this.txtFabricante);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDepto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUnidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Minimize);
            this.Controls.Add(this.lbl_Close);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frm_CadRede";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_CadRede";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComboBox cboxTipo;
        private Label label6;
        private Label label4;
        private Button btn_Voltar;
        private Button btn_Salvar;
        private TextBox txtPatrimonio;
        private TextBox txtNS;
        private TextBox txtModelo;
        private TextBox txtFabricante;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtDepto;
        private Label label2;
        private TextBox txtUnidade;
        private Label label3;
        private Label lbl_Minimize;
        private Label lbl_Close;
        private Label label1;
    }
}