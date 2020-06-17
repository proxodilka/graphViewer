namespace Graph_
{
    partial class TSPsettings
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
            this.migration = new System.Windows.Forms.CheckBox();
            this.befor_frst_migration_txtbx = new System.Windows.Forms.TextBox();
            this.number_of_generations_lb = new System.Windows.Forms.Label();
            this.rnd_pop_txtbx = new System.Windows.Forms.TextBox();
            this.greedy_pop_txtbx = new System.Windows.Forms.TextBox();
            this.number_of_random_populations_lb = new System.Windows.Forms.Label();
            this.number_of_greedy_populations_lb = new System.Windows.Forms.Label();
            this.GAset_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // migration
            // 
            this.migration.AutoSize = true;
            this.migration.Location = new System.Drawing.Point(43, 79);
            this.migration.Name = "migration";
            this.migration.Size = new System.Drawing.Size(88, 21);
            this.migration.TabIndex = 0;
            this.migration.Text = "migration";
            this.migration.UseVisualStyleBackColor = true;
            // 
            // befor_frst_migration_txtbx
            // 
            this.befor_frst_migration_txtbx.Location = new System.Drawing.Point(43, 120);
            this.befor_frst_migration_txtbx.Name = "befor_frst_migration_txtbx";
            this.befor_frst_migration_txtbx.Size = new System.Drawing.Size(109, 22);
            this.befor_frst_migration_txtbx.TabIndex = 1;
            this.befor_frst_migration_txtbx.TextChanged += new System.EventHandler(this.befor_frst_migration_txtbx_TextChanged);
            // 
            // number_of_generations_lb
            // 
            this.number_of_generations_lb.AutoSize = true;
            this.number_of_generations_lb.Location = new System.Drawing.Point(158, 123);
            this.number_of_generations_lb.Name = "number_of_generations_lb";
            this.number_of_generations_lb.Size = new System.Drawing.Size(281, 17);
            this.number_of_generations_lb.TabIndex = 2;
            this.number_of_generations_lb.Text = "number of generations befor first migration ";
            // 
            // rnd_pop_txtbx
            // 
            this.rnd_pop_txtbx.Location = new System.Drawing.Point(43, 148);
            this.rnd_pop_txtbx.Name = "rnd_pop_txtbx";
            this.rnd_pop_txtbx.Size = new System.Drawing.Size(109, 22);
            this.rnd_pop_txtbx.TabIndex = 3;
            this.rnd_pop_txtbx.TextChanged += new System.EventHandler(this.rnd_pop_txtbx_TextChanged);
            // 
            // greedy_pop_txtbx
            // 
            this.greedy_pop_txtbx.Location = new System.Drawing.Point(43, 176);
            this.greedy_pop_txtbx.Name = "greedy_pop_txtbx";
            this.greedy_pop_txtbx.Size = new System.Drawing.Size(109, 22);
            this.greedy_pop_txtbx.TabIndex = 4;
            this.greedy_pop_txtbx.TextChanged += new System.EventHandler(this.greedy_pop_txtbx_TextChanged);
            // 
            // number_of_random_populations_lb
            // 
            this.number_of_random_populations_lb.AutoSize = true;
            this.number_of_random_populations_lb.Location = new System.Drawing.Point(158, 151);
            this.number_of_random_populations_lb.Name = "number_of_random_populations_lb";
            this.number_of_random_populations_lb.Size = new System.Drawing.Size(201, 17);
            this.number_of_random_populations_lb.TabIndex = 5;
            this.number_of_random_populations_lb.Text = "number of random populations";
            // 
            // number_of_greedy_populations_lb
            // 
            this.number_of_greedy_populations_lb.AutoSize = true;
            this.number_of_greedy_populations_lb.Location = new System.Drawing.Point(158, 176);
            this.number_of_greedy_populations_lb.Name = "number_of_greedy_populations_lb";
            this.number_of_greedy_populations_lb.Size = new System.Drawing.Size(197, 17);
            this.number_of_greedy_populations_lb.TabIndex = 6;
            this.number_of_greedy_populations_lb.Text = "number of greedy populations";
            // 
            // GAset_name
            // 
            this.GAset_name.AutoSize = true;
            this.GAset_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.GAset_name.Location = new System.Drawing.Point(23, 21);
            this.GAset_name.Name = "GAset_name";
            this.GAset_name.Size = new System.Drawing.Size(216, 48);
            this.GAset_name.TabIndex = 7;
            this.GAset_name.Text = "GA setting";
            // 
            // TSPsettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 236);
            this.Controls.Add(this.GAset_name);
            this.Controls.Add(this.number_of_greedy_populations_lb);
            this.Controls.Add(this.number_of_random_populations_lb);
            this.Controls.Add(this.greedy_pop_txtbx);
            this.Controls.Add(this.rnd_pop_txtbx);
            this.Controls.Add(this.number_of_generations_lb);
            this.Controls.Add(this.befor_frst_migration_txtbx);
            this.Controls.Add(this.migration);
            this.Name = "TSPsettings";
            this.Text = "TSPsettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox migration;
        private System.Windows.Forms.TextBox befor_frst_migration_txtbx;
        private System.Windows.Forms.Label number_of_generations_lb;
        private System.Windows.Forms.TextBox rnd_pop_txtbx;
        private System.Windows.Forms.TextBox greedy_pop_txtbx;
        private System.Windows.Forms.Label number_of_random_populations_lb;
        private System.Windows.Forms.Label number_of_greedy_populations_lb;
        private System.Windows.Forms.Label GAset_name;
    }
}