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
            this.StatusImportWarehouse.Location = new System.Drawing.Point(0, 1314);
            this.StatusImportWarehouse.Name = "StatusImportWarehouse";
            this.StatusImportWarehouse.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.StatusImportWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusImportWarehouse.Size = new System.Drawing.Size(2468, 42);
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
            this.Size = new System.Drawing.Size(2468, 1356);
            this.Load += new System.EventHandler(this.Warehouse_UC_Load);
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