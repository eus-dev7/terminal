namespace Terminal2
{
    partial class BNormal
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
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.grficbusnormal = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.SuspendLayout();
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.grficbusnormal});
            this.shapeContainer1.Size = new System.Drawing.Size(1370, 750);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // grficbusnormal
            // 
            this.grficbusnormal.BackgroundImage = global::Terminal2.Properties.Resources.bus_normal;
            this.grficbusnormal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.grficbusnormal.Location = new System.Drawing.Point(12, 16);
            this.grficbusnormal.Name = "grficbusnormal";
            this.grficbusnormal.Size = new System.Drawing.Size(840, 295);
            this.grficbusnormal.Visible = false;
            // 
            // BNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 750);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "BNormal";
            this.Text = "BNormal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BNormal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.RectangleShape grficbusnormal;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
    }
}