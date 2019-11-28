namespace Graph_
{
    partial class GraphWeightSettings
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
            this.increaseMatrixButton = new System.Windows.Forms.Button();
            this.decreaseMatrixButton = new System.Windows.Forms.Button();
            this.resetWeightButton = new System.Windows.Forms.Button();
            this.syncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // increaseMatrixButton
            // 
            this.increaseMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.increaseMatrixButton.Location = new System.Drawing.Point(12, 12);
            this.increaseMatrixButton.Name = "increaseMatrixButton";
            this.increaseMatrixButton.Size = new System.Drawing.Size(32, 29);
            this.increaseMatrixButton.TabIndex = 0;
            this.increaseMatrixButton.Text = "+";
            this.increaseMatrixButton.UseVisualStyleBackColor = true;
            this.increaseMatrixButton.Click += new System.EventHandler(this.increaseMatrixButton_Click);
            // 
            // decreaseMatrixButton
            // 
            this.decreaseMatrixButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decreaseMatrixButton.Location = new System.Drawing.Point(50, 12);
            this.decreaseMatrixButton.Name = "decreaseMatrixButton";
            this.decreaseMatrixButton.Size = new System.Drawing.Size(32, 29);
            this.decreaseMatrixButton.TabIndex = 1;
            this.decreaseMatrixButton.Text = "-";
            this.decreaseMatrixButton.UseVisualStyleBackColor = true;
            this.decreaseMatrixButton.Click += new System.EventHandler(this.decreaseMatrixButton_Click);
            // 
            // resetWeightButton
            // 
            this.resetWeightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resetWeightButton.Location = new System.Drawing.Point(550, 12);
            this.resetWeightButton.Name = "resetWeightButton";
            this.resetWeightButton.Size = new System.Drawing.Size(112, 29);
            this.resetWeightButton.TabIndex = 2;
            this.resetWeightButton.Text = "reset weights";
            this.resetWeightButton.UseVisualStyleBackColor = true;
            // 
            // syncButton
            // 
            this.syncButton.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.syncButton.Location = new System.Drawing.Point(88, 12);
            this.syncButton.Name = "syncButton";
            this.syncButton.Size = new System.Drawing.Size(160, 29);
            this.syncButton.TabIndex = 3;
            this.syncButton.Text = "sync graph and matrix";
            this.syncButton.UseVisualStyleBackColor = true;
            this.syncButton.Click += new System.EventHandler(this.syncButton_Click);
            // 
            // GraphWeightSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(674, 466);
            this.Controls.Add(this.syncButton);
            this.Controls.Add(this.resetWeightButton);
            this.Controls.Add(this.decreaseMatrixButton);
            this.Controls.Add(this.increaseMatrixButton);
            this.Name = "GraphWeightSettings";
            this.Text = "GraphWeightSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button increaseMatrixButton;
        private System.Windows.Forms.Button decreaseMatrixButton;
        private System.Windows.Forms.Button resetWeightButton;
        private System.Windows.Forms.Button syncButton;
    }
}