namespace CompuStore.Tab
{
    partial class Warehouse_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() 
        {
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusImportWarehouse = new System.Windows.Forms.StatusStrip();
            this.StatusImportWarehouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_2
            // 
            this.Button_2.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button_2.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_2.CheckedState.Parent = this.Button_2;
            this.Button_2.CustomImages.Parent = this.Button_2;
            this.Button_2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_2.HoverState.Parent = this.Button_2;
            this.Button_2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_2.ShadowDecoration.Parent = this.Button_2;
            this.Button_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_2.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            // 
            // Bottom_1
            // 
            this.Bottom_1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Bottom_1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Bottom_1.CheckedState.Parent = this.Bottom_1;
            this.Bottom_1.CustomImages.Parent = this.Bottom_1;
            this.Bottom_1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Bottom_1.HoverState.Parent = this.Bottom_1;
            this.Bottom_1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bottom_1.ShadowDecoration.Parent = this.Bottom_1;
            this.Bottom_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Bottom_1.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            // 
            // Button_3
            // 
            this.Button_3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.DefaultButton;
            this.Button_3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(133)))), ((int)(((byte)(251)))));
            this.Button_3.CheckedState.Parent = this.Button_3;
            this.Button_3.CustomImages.Parent = this.Button_3;
            this.Button_3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.Button_3.HoverState.Parent = this.Button_3;
            this.Button_3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_3.ShadowDecoration.Parent = this.Button_3;
            this.Button_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Button_3.TextTransform = Guna.UI2.WinForms.Enums.TextTransform.None;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 30);
            this.toolStripProgressBar1.Step = 50;
            this.toolStripProgressBar1.ToolTipText = "Đã nhập được 50/100 sản phẩm";
            this.toolStripProgressBar1.Value = 50;
            // 
            // StatusImportWarehouse
            // 
            this.StatusImportWarehouse.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.StatusImportWarehouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.StatusImportWarehouse.Location = new System.Drawing.Point(0, 1496);
            this.StatusImportWarehouse.Name = "StatusImportWarehouse";
            this.StatusImportWarehouse.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusImportWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusImportWarehouse.Size = new System.Drawing.Size(2880, 42);
            this.StatusImportWarehouse.TabIndex = 10;
            // 
            // Warehouse_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.Controls.Add(this.StatusImportWarehouse);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Warehouse_UC";
            this.Load += new System.EventHandler(this.Warehouse_UC_Load);
            this.Controls.SetChildIndex(this.StatusImportWarehouse, 0);
            this.Controls.SetChildIndex(this.Button_3, 0);
            this.Controls.SetChildIndex(this.Button_2, 0);
            this.Controls.SetChildIndex(this.Bottom_1, 0);
            this.Controls.SetChildIndex(this.SearchBox, 0);
            this.StatusImportWarehouse.ResumeLayout(false);
            this.StatusImportWarehouse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.StatusStrip StatusImportWarehouse;
    }
}