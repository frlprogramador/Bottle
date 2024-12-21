namespace ConsomeAPIBottle
{
    partial class FormMain
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
            this.picCaptured = new System.Windows.Forms.PictureBox();
            this.btnOpenFolter = new System.Windows.Forms.Button();
            this.btnOpenImage = new System.Windows.Forms.Button();
            this.lstArquivos = new System.Windows.Forms.ListBox();
            this.lblNotExists = new System.Windows.Forms.Label();
            this.lblAberta = new System.Windows.Forms.Label();
            this.lblFechada = new System.Windows.Forms.Label();
            this.chkAtivar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntervalo = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.timerAtivar = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picCaptured)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // picCaptured
            // 
            this.picCaptured.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCaptured.Location = new System.Drawing.Point(276, 13);
            this.picCaptured.Name = "picCaptured";
            this.picCaptured.Size = new System.Drawing.Size(846, 711);
            this.picCaptured.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCaptured.TabIndex = 0;
            this.picCaptured.TabStop = false;
            // 
            // btnOpenFolter
            // 
            this.btnOpenFolter.Location = new System.Drawing.Point(12, 13);
            this.btnOpenFolter.Name = "btnOpenFolter";
            this.btnOpenFolter.Size = new System.Drawing.Size(237, 23);
            this.btnOpenFolter.TabIndex = 1;
            this.btnOpenFolter.Text = "Carregar Diretório";
            this.btnOpenFolter.UseVisualStyleBackColor = true;
            this.btnOpenFolter.Click += new System.EventHandler(this.btnOpenFolter_Click);
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.Location = new System.Drawing.Point(12, 42);
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(237, 23);
            this.btnOpenImage.TabIndex = 2;
            this.btnOpenImage.Text = "Carregar Arquivo";
            this.btnOpenImage.UseVisualStyleBackColor = true;
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // lstArquivos
            // 
            this.lstArquivos.FormattingEnabled = true;
            this.lstArquivos.Location = new System.Drawing.Point(13, 72);
            this.lstArquivos.Name = "lstArquivos";
            this.lstArquivos.Size = new System.Drawing.Size(236, 602);
            this.lstArquivos.TabIndex = 3;
            this.lstArquivos.SelectedIndexChanged += new System.EventHandler(this.lstArquivos_SelectedIndexChanged);
            // 
            // lblNotExists
            // 
            this.lblNotExists.BackColor = System.Drawing.Color.Gray;
            this.lblNotExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotExists.Location = new System.Drawing.Point(276, 731);
            this.lblNotExists.Name = "lblNotExists";
            this.lblNotExists.Size = new System.Drawing.Size(235, 45);
            this.lblNotExists.TabIndex = 4;
            this.lblNotExists.Text = "Não encontrada";
            this.lblNotExists.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAberta
            // 
            this.lblAberta.BackColor = System.Drawing.Color.Gray;
            this.lblAberta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAberta.Location = new System.Drawing.Point(581, 731);
            this.lblAberta.Name = "lblAberta";
            this.lblAberta.Size = new System.Drawing.Size(235, 45);
            this.lblAberta.TabIndex = 5;
            this.lblAberta.Text = "Aberta";
            this.lblAberta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFechada
            // 
            this.lblFechada.BackColor = System.Drawing.Color.Gray;
            this.lblFechada.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechada.Location = new System.Drawing.Point(886, 731);
            this.lblFechada.Name = "lblFechada";
            this.lblFechada.Size = new System.Drawing.Size(235, 45);
            this.lblFechada.TabIndex = 6;
            this.lblFechada.Text = "Fechada";
            this.lblFechada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkAtivar
            // 
            this.chkAtivar.AutoSize = true;
            this.chkAtivar.Location = new System.Drawing.Point(13, 681);
            this.chkAtivar.Name = "chkAtivar";
            this.chkAtivar.Size = new System.Drawing.Size(53, 17);
            this.chkAtivar.TabIndex = 7;
            this.chkAtivar.Text = "Ativar";
            this.chkAtivar.UseVisualStyleBackColor = true;
            this.chkAtivar.CheckedChanged += new System.EventHandler(this.chkAtivar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 681);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Intervalo:";
            // 
            // txtIntervalo
            // 
            this.txtIntervalo.Location = new System.Drawing.Point(167, 678);
            this.txtIntervalo.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtIntervalo.Minimum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.txtIntervalo.Name = "txtIntervalo";
            this.txtIntervalo.Size = new System.Drawing.Size(51, 20);
            this.txtIntervalo.TabIndex = 9;
            this.txtIntervalo.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 682);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ms.";
            // 
            // timerAtivar
            // 
            this.timerAtivar.Tick += new System.EventHandler(this.timerAtivar_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 808);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIntervalo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAtivar);
            this.Controls.Add(this.lblFechada);
            this.Controls.Add(this.lblAberta);
            this.Controls.Add(this.lblNotExists);
            this.Controls.Add(this.lstArquivos);
            this.Controls.Add(this.btnOpenImage);
            this.Controls.Add(this.btnOpenFolter);
            this.Controls.Add(this.picCaptured);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bottle";
            ((System.ComponentModel.ISupportInitialize)(this.picCaptured)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIntervalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCaptured;
        private System.Windows.Forms.Button btnOpenFolter;
        private System.Windows.Forms.Button btnOpenImage;
        private System.Windows.Forms.ListBox lstArquivos;
        private System.Windows.Forms.Label lblNotExists;
        private System.Windows.Forms.Label lblAberta;
        private System.Windows.Forms.Label lblFechada;
        private System.Windows.Forms.CheckBox chkAtivar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtIntervalo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerAtivar;
    }
}