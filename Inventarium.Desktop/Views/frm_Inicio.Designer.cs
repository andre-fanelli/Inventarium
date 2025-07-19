namespace Inventarium
{
    partial class frm_Inicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Inicio));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Avancar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.lbl_Minimize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(90, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "INVENTARIUM";
            // 
            // btn_Avancar
            // 
            this.btn_Avancar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Avancar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btn_Avancar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Avancar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Avancar.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_Avancar.ForeColor = System.Drawing.Color.White;
            this.btn_Avancar.Location = new System.Drawing.Point(120, 290);
            this.btn_Avancar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Avancar.Name = "btn_Avancar";
            this.btn_Avancar.Size = new System.Drawing.Size(150, 60);
            this.btn_Avancar.TabIndex = 1;
            this.btn_Avancar.Text = "Avançar";
            this.btn_Avancar.UseVisualStyleBackColor = false;
            this.btn_Avancar.Click += new System.EventHandler(this.btn_Avancar_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(12, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(376, 71);
            this.label2.TabIndex = 2;
            this.label2.Text = "Olá, siga as instruções para cadastrar o(s) equipamento(s) desejado(s)! Observe a" +
    "tentamente as informações pedidas e, após confirmação, faça o envio dos dados!";
            // 
            // lbl_Close
            // 
            this.lbl_Close.AutoSize = true;
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Close.Location = new System.Drawing.Point(374, 2);
            this.lbl_Close.Name = "lbl_Close";
            this.lbl_Close.Size = new System.Drawing.Size(24, 24);
            this.lbl_Close.TabIndex = 3;
            this.lbl_Close.Text = "X";
            this.lbl_Close.Click += new System.EventHandler(this.lbl_Close_Click);
            // 
            // lbl_Minimize
            // 
            this.lbl_Minimize.AutoSize = true;
            this.lbl_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Minimize.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_Minimize.Location = new System.Drawing.Point(355, 2);
            this.lbl_Minimize.Name = "lbl_Minimize";
            this.lbl_Minimize.Size = new System.Drawing.Size(22, 24);
            this.lbl_Minimize.TabIndex = 4;
            this.lbl_Minimize.Text = "_";
            // 
            // frm_Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.lbl_Minimize);
            this.Controls.Add(this.lbl_Close);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Avancar);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventarium - Início";
            this.Load += new System.EventHandler(this.frm_Inicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btn_Avancar;
        private Label label2;
        private Label lbl_Close;
        private Label lbl_Minimize;
    }
}