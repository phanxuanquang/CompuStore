namespace CompuStore.GUI
{
    partial class Waiting_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Waiting_Form));
            this.Loading_ProgressBar = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.SuspendLayout();
            // 
            // Loading_ProgressBar
            // 
            this.Loading_ProgressBar.Animated = true;
            this.Loading_ProgressBar.BackColor = System.Drawing.Color.Transparent;
            this.Loading_ProgressBar.FillColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.Loading_ProgressBar, "Loading_ProgressBar");
            this.Loading_ProgressBar.Name = "Loading_ProgressBar";
            this.Loading_ProgressBar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Loading_ProgressBar.ProgressColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Loading_ProgressBar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.Loading_ProgressBar.ShadowDecoration.Parent = this.Loading_ProgressBar;
            this.Loading_ProgressBar.UseTransparentBackground = true;
            this.Loading_ProgressBar.UseWaitCursor = true;
            this.Loading_ProgressBar.ValueChanged += new System.EventHandler(this.Loading_ProgressBar_ValueChanged);
            // 
            // Waiting_Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.Loading_ProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Waiting_Form";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Waiting_Form_FormClosing);
            this.Load += new System.EventHandler(this.Waiting_Form_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CircleProgressBar Loading_ProgressBar;
    }
}