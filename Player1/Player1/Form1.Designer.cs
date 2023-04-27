namespace Player1
{
    partial class Form1
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
            this.lbl_Batalha_Naval = new System.Windows.Forms.Label();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.btn_instrucoes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Batalha_Naval
            // 
            this.lbl_Batalha_Naval.AutoSize = true;
            this.lbl_Batalha_Naval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Batalha_Naval.Location = new System.Drawing.Point(109, 11);
            this.lbl_Batalha_Naval.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Batalha_Naval.Name = "lbl_Batalha_Naval";
            this.lbl_Batalha_Naval.Size = new System.Drawing.Size(146, 25);
            this.lbl_Batalha_Naval.TabIndex = 0;
            this.lbl_Batalha_Naval.Text = "Batalha Naval";
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(115, 55);
            this.btn_Conectar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(155, 39);
            this.btn_Conectar.TabIndex = 2;
            this.btn_Conectar.Text = "Entrar no jogo";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // btn_instrucoes
            // 
            this.btn_instrucoes.Location = new System.Drawing.Point(115, 102);
            this.btn_instrucoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_instrucoes.Name = "btn_instrucoes";
            this.btn_instrucoes.Size = new System.Drawing.Size(155, 39);
            this.btn_instrucoes.TabIndex = 3;
            this.btn_instrucoes.Text = "Instruções";
            this.btn_instrucoes.UseVisualStyleBackColor = true;
            this.btn_instrucoes.Click += new System.EventHandler(this.btn_instrucoes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 160);
            this.Controls.Add(this.btn_instrucoes);
            this.Controls.Add(this.btn_Conectar);
            this.Controls.Add(this.lbl_Batalha_Naval);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Batalha Naval [ Player 1 ]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Batalha_Naval;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_instrucoes;
    }
}

