namespace Player1
{
    partial class Menu
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
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelJogo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.Location = new System.Drawing.Point(84, 51);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(116, 32);
            this.buttonIniciar.TabIndex = 4;
            this.buttonIniciar.Text = "Iniciar jogo";
            this.buttonIniciar.UseVisualStyleBackColor = true;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Batalha Naval";
            // 
            // labelJogo
            // 
            this.labelJogo.AutoSize = true;
            this.labelJogo.Location = new System.Drawing.Point(84, 33);
            this.labelJogo.Name = "labelJogo";
            this.labelJogo.Size = new System.Drawing.Size(115, 13);
            this.labelJogo.TabIndex = 5;
            this.labelJogo.Text = "À espera do 2º jogador";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 96);
            this.Controls.Add(this.labelJogo);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.label1);
            this.Name = "Menu";
            this.Text = "Menu [ Player 1 ]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelJogo;
    }
}