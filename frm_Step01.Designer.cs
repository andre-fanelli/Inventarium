namespace Inventarium
{
    partial class frm_Step01
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Step01));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbox_Equipamento = new System.Windows.Forms.ComboBox();
            this.btn_Avancar02 = new System.Windows.Forms.Button();
            this.lbl_Minimize = new System.Windows.Forms.Label();
            this.lbl_Close = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Name = "label2";
            // 
            // cbox_Equipamento
            // 
            resources.ApplyResources(this.cbox_Equipamento, "cbox_Equipamento");
            this.cbox_Equipamento.FormattingEnabled = true;
            this.cbox_Equipamento.Items.AddRange(new object[] {
            resources.GetString("cbox_Equipamento.Items"),
            resources.GetString("cbox_Equipamento.Items1"),
            resources.GetString("cbox_Equipamento.Items2"),
            resources.GetString("cbox_Equipamento.Items3"),
            resources.GetString("cbox_Equipamento.Items4"),
            resources.GetString("cbox_Equipamento.Items5"),
            resources.GetString("cbox_Equipamento.Items6")});
            this.cbox_Equipamento.Name = "cbox_Equipamento";
            // 
            // btn_Avancar02
            // 
            resources.ApplyResources(this.btn_Avancar02, "btn_Avancar02");
            this.btn_Avancar02.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.btn_Avancar02.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Avancar02.ForeColor = System.Drawing.Color.White;
            this.btn_Avancar02.Name = "btn_Avancar02";
            this.btn_Avancar02.UseVisualStyleBackColor = false;
            // 
            // lbl_Minimize
            // 
            resources.ApplyResources(this.lbl_Minimize, "lbl_Minimize");
            this.lbl_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Minimize.Name = "lbl_Minimize";
            // 
            // lbl_Close
            // 
            resources.ApplyResources(this.lbl_Close, "lbl_Close");
            this.lbl_Close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Close.Name = "lbl_Close";
            // 
            // frm_Step01
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Inventarium.Properties.Resources.bg;
            this.Controls.Add(this.lbl_Minimize);
            this.Controls.Add(this.lbl_Close);
            this.Controls.Add(this.btn_Avancar02);
            this.Controls.Add(this.cbox_Equipamento);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(81)))), ((int)(((byte)(158)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Step01";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cbox_Equipamento;
        private Button btn_Avancar02;
        private Label lbl_Minimize;
        private Label lbl_Close;
    }
}