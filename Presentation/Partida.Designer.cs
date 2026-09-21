namespace Super_Mario_Suika
{
    partial class Partida
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            Puntos = new Label();
            GameOver = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Red;
            label1.Location = new Point(12, 24);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Puntos: ";
            // 
            // Puntos
            // 
            Puntos.AutoSize = true;
            Puntos.ForeColor = Color.Transparent;
            Puntos.Location = new Point(78, 24);
            Puntos.Name = "Puntos";
            Puntos.Size = new Size(17, 20);
            Puntos.TabIndex = 1;
            Puntos.Text = "0";
            // 
            // GameOver
            // 
            GameOver.AutoSize = true;
            GameOver.ForeColor = Color.Red;
            GameOver.Location = new Point(201, 403);
            GameOver.Name = "GameOver";
            GameOver.Size = new Size(91, 20);
            GameOver.TabIndex = 2;
            GameOver.Text = "GAME OVER";
            // 
            // Partida
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            BackgroundImage = Properties.Resources.tuberia;
            ClientSize = new Size(502, 895);
            Controls.Add(GameOver);
            Controls.Add(Puntos);
            Controls.Add(label1);
            Name = "Partida";
            Text = "Partida";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Puntos;
        private Label GameOver;
    }
}
