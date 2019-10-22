namespace Graph_
{
    partial class MainWindow
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
            this.navigationMenu = new System.Windows.Forms.MenuStrip();
            this.fileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitOption = new System.Windows.Forms.ToolStripMenuItem();
            this.graphRoot = new System.Windows.Forms.Panel();
            this.plot = new System.Windows.Forms.PictureBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.vertexValue = new System.Windows.Forms.Label();
            this.edgesValue = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.changeVertexTab = new System.Windows.Forms.TabPage();
            this.changeVertValue = new System.Windows.Forms.NumericUpDown();
            this.deleteVertex = new System.Windows.Forms.Button();
            this.addVertex = new System.Windows.Forms.Button();
            this.changeVertexesLabel = new System.Windows.Forms.Label();
            this.changeEdgesTab = new System.Windows.Forms.TabPage();
            this.clearEdges = new System.Windows.Forms.Button();
            this.makeGraphComplete = new System.Windows.Forms.Button();
            this.toEdgeValue = new System.Windows.Forms.NumericUpDown();
            this.fromEdgeValue = new System.Windows.Forms.NumericUpDown();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.deleteEdge = new System.Windows.Forms.Button();
            this.addEdge = new System.Windows.Forms.Button();
            this.changeEdgesLabel = new System.Windows.Forms.Label();
            this.traversalTab = new System.Windows.Forms.TabPage();
            this.isConnectedComponents = new System.Windows.Forms.RadioButton();
            this.traversalStartVertex = new System.Windows.Forms.NumericUpDown();
            this.startTraversal = new System.Windows.Forms.Button();
            this.isDfs = new System.Windows.Forms.RadioButton();
            this.isBfs = new System.Windows.Forms.RadioButton();
            this.startedVertex = new System.Windows.Forms.Label();
            this.openGraphFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.navigationMenu.SuspendLayout();
            this.graphRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plot)).BeginInit();
            this.tabControl.SuspendLayout();
            this.changeVertexTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeVertValue)).BeginInit();
            this.changeEdgesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toEdgeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromEdgeValue)).BeginInit();
            this.traversalTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traversalStartVertex)).BeginInit();
            this.SuspendLayout();
            // 
            // navigationMenu
            // 
            this.navigationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOption});
            this.navigationMenu.Location = new System.Drawing.Point(0, 0);
            this.navigationMenu.Name = "navigationMenu";
            this.navigationMenu.Size = new System.Drawing.Size(846, 24);
            this.navigationMenu.TabIndex = 0;
            this.navigationMenu.Text = "menuStrip1";
            // 
            // fileOption
            // 
            this.fileOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileOption,
            this.openFileOption,
            this.saveFileOption,
            this.saveAsFileOption,
            this.toolStripSeparator1,
            this.exitOption});
            this.fileOption.Name = "fileOption";
            this.fileOption.Size = new System.Drawing.Size(37, 20);
            this.fileOption.Text = "File";
            // 
            // newFileOption
            // 
            this.newFileOption.Name = "newFileOption";
            this.newFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newFileOption.Size = new System.Drawing.Size(195, 22);
            this.newFileOption.Text = "New";
            this.newFileOption.Click += new System.EventHandler(this.NewFileOption_Click);
            // 
            // openFileOption
            // 
            this.openFileOption.Name = "openFileOption";
            this.openFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openFileOption.Size = new System.Drawing.Size(195, 22);
            this.openFileOption.Text = "Open...";
            this.openFileOption.Click += new System.EventHandler(this.OpenFileOption_Click);
            // 
            // saveFileOption
            // 
            this.saveFileOption.Name = "saveFileOption";
            this.saveFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveFileOption.Size = new System.Drawing.Size(195, 22);
            this.saveFileOption.Text = "Save";
            this.saveFileOption.Click += new System.EventHandler(this.SaveFileOption_Click);
            // 
            // saveAsFileOption
            // 
            this.saveAsFileOption.Name = "saveAsFileOption";
            this.saveAsFileOption.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsFileOption.Size = new System.Drawing.Size(195, 22);
            this.saveAsFileOption.Text = "Save As...";
            this.saveAsFileOption.Click += new System.EventHandler(this.SaveAsFileOption_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // exitOption
            // 
            this.exitOption.Name = "exitOption";
            this.exitOption.Size = new System.Drawing.Size(195, 22);
            this.exitOption.Text = "Exit";
            this.exitOption.Click += new System.EventHandler(this.ExitOption_Click);
            // 
            // graphRoot
            // 
            this.graphRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphRoot.Controls.Add(this.plot);
            this.graphRoot.Controls.Add(this.resetButton);
            this.graphRoot.Controls.Add(this.vertexValue);
            this.graphRoot.Controls.Add(this.edgesValue);
            this.graphRoot.Location = new System.Drawing.Point(13, 28);
            this.graphRoot.Name = "graphRoot";
            this.graphRoot.Size = new System.Drawing.Size(821, 519);
            this.graphRoot.TabIndex = 1;
            // 
            // plot
            // 
            this.plot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plot.Location = new System.Drawing.Point(-1, -1);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(821, 497);
            this.plot.TabIndex = 0;
            this.plot.TabStop = false;
            this.plot.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Plot_GiveFeedback);
            this.plot.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Plot_QueryContinueDrag);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(745, 495);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 3;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // vertexValue
            // 
            this.vertexValue.AutoSize = true;
            this.vertexValue.Location = new System.Drawing.Point(3, 501);
            this.vertexValue.Name = "vertexValue";
            this.vertexValue.Size = new System.Drawing.Size(68, 13);
            this.vertexValue.TabIndex = 2;
            this.vertexValue.Text = "Vertexes: 10;";
            // 
            // edgesValue
            // 
            this.edgesValue.AutoSize = true;
            this.edgesValue.Location = new System.Drawing.Point(77, 501);
            this.edgesValue.Name = "edgesValue";
            this.edgesValue.Size = new System.Drawing.Size(54, 13);
            this.edgesValue.TabIndex = 1;
            this.edgesValue.Text = "Edges: 16;";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.changeVertexTab);
            this.tabControl.Controls.Add(this.changeEdgesTab);
            this.tabControl.Controls.Add(this.traversalTab);
            this.tabControl.Location = new System.Drawing.Point(13, 554);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(821, 116);
            this.tabControl.TabIndex = 8;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // changeVertexTab
            // 
            this.changeVertexTab.Controls.Add(this.changeVertValue);
            this.changeVertexTab.Controls.Add(this.deleteVertex);
            this.changeVertexTab.Controls.Add(this.addVertex);
            this.changeVertexTab.Controls.Add(this.changeVertexesLabel);
            this.changeVertexTab.Location = new System.Drawing.Point(4, 22);
            this.changeVertexTab.Name = "changeVertexTab";
            this.changeVertexTab.Padding = new System.Windows.Forms.Padding(3);
            this.changeVertexTab.Size = new System.Drawing.Size(813, 90);
            this.changeVertexTab.TabIndex = 0;
            this.changeVertexTab.Text = "Изменение вершин";
            this.changeVertexTab.UseVisualStyleBackColor = true;
            // 
            // changeVertValue
            // 
            this.changeVertValue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeVertValue.Location = new System.Drawing.Point(7, 27);
            this.changeVertValue.Name = "changeVertValue";
            this.changeVertValue.Size = new System.Drawing.Size(87, 23);
            this.changeVertValue.TabIndex = 14;
            this.changeVertValue.ValueChanged += new System.EventHandler(this.ChangeVertValue_ValueChanged);
            // 
            // deleteVertex
            // 
            this.deleteVertex.Location = new System.Drawing.Point(127, 27);
            this.deleteVertex.Name = "deleteVertex";
            this.deleteVertex.Size = new System.Drawing.Size(24, 23);
            this.deleteVertex.TabIndex = 13;
            this.deleteVertex.Text = "-";
            this.deleteVertex.UseVisualStyleBackColor = true;
            this.deleteVertex.Click += new System.EventHandler(this.DeleteVertex_Click);
            // 
            // addVertex
            // 
            this.addVertex.Location = new System.Drawing.Point(100, 27);
            this.addVertex.Name = "addVertex";
            this.addVertex.Size = new System.Drawing.Size(24, 23);
            this.addVertex.TabIndex = 12;
            this.addVertex.Text = "+";
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.AddVertex_Click);
            // 
            // changeVertexesLabel
            // 
            this.changeVertexesLabel.AutoSize = true;
            this.changeVertexesLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeVertexesLabel.Location = new System.Drawing.Point(3, 0);
            this.changeVertexesLabel.Name = "changeVertexesLabel";
            this.changeVertexesLabel.Size = new System.Drawing.Size(148, 23);
            this.changeVertexesLabel.TabIndex = 10;
            this.changeVertexesLabel.Text = "Номер вершины:";
            // 
            // changeEdgesTab
            // 
            this.changeEdgesTab.Controls.Add(this.clearEdges);
            this.changeEdgesTab.Controls.Add(this.makeGraphComplete);
            this.changeEdgesTab.Controls.Add(this.toEdgeValue);
            this.changeEdgesTab.Controls.Add(this.fromEdgeValue);
            this.changeEdgesTab.Controls.Add(this.toLabel);
            this.changeEdgesTab.Controls.Add(this.fromLabel);
            this.changeEdgesTab.Controls.Add(this.deleteEdge);
            this.changeEdgesTab.Controls.Add(this.addEdge);
            this.changeEdgesTab.Controls.Add(this.changeEdgesLabel);
            this.changeEdgesTab.Location = new System.Drawing.Point(4, 22);
            this.changeEdgesTab.Name = "changeEdgesTab";
            this.changeEdgesTab.Size = new System.Drawing.Size(813, 90);
            this.changeEdgesTab.TabIndex = 2;
            this.changeEdgesTab.Text = "Изменение рёбер";
            this.changeEdgesTab.UseVisualStyleBackColor = true;
            // 
            // clearEdges
            // 
            this.clearEdges.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearEdges.Location = new System.Drawing.Point(297, 26);
            this.clearEdges.Name = "clearEdges";
            this.clearEdges.Size = new System.Drawing.Size(134, 22);
            this.clearEdges.TabIndex = 24;
            this.clearEdges.Text = "Удалить все ребра";
            this.clearEdges.UseVisualStyleBackColor = true;
            this.clearEdges.Click += new System.EventHandler(this.ClearEdges_Click);
            // 
            // makeGraphComplete
            // 
            this.makeGraphComplete.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.makeGraphComplete.Location = new System.Drawing.Point(157, 27);
            this.makeGraphComplete.Name = "makeGraphComplete";
            this.makeGraphComplete.Size = new System.Drawing.Size(134, 22);
            this.makeGraphComplete.TabIndex = 23;
            this.makeGraphComplete.Text = "Сделать полным";
            this.makeGraphComplete.UseVisualStyleBackColor = true;
            this.makeGraphComplete.Click += new System.EventHandler(this.MakeGraphComplete_Click);
            // 
            // toEdgeValue
            // 
            this.toEdgeValue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toEdgeValue.Location = new System.Drawing.Point(51, 26);
            this.toEdgeValue.Name = "toEdgeValue";
            this.toEdgeValue.Size = new System.Drawing.Size(38, 23);
            this.toEdgeValue.TabIndex = 22;
            this.toEdgeValue.ValueChanged += new System.EventHandler(this.ToEdgeValue_ValueChanged);
            // 
            // fromEdgeValue
            // 
            this.fromEdgeValue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromEdgeValue.Location = new System.Drawing.Point(7, 26);
            this.fromEdgeValue.Name = "fromEdgeValue";
            this.fromEdgeValue.Size = new System.Drawing.Size(38, 23);
            this.fromEdgeValue.TabIndex = 21;
            this.fromEdgeValue.ValueChanged += new System.EventHandler(this.FromEdgeValue_ValueChanged);
            // 
            // toLabel
            // 
            this.toLabel.AutoSize = true;
            this.toLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toLabel.Location = new System.Drawing.Point(47, 55);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(18, 19);
            this.toLabel.TabIndex = 20;
            this.toLabel.Text = "В";
            // 
            // fromLabel
            // 
            this.fromLabel.AutoSize = true;
            this.fromLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fromLabel.Location = new System.Drawing.Point(3, 55);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(26, 19);
            this.fromLabel.TabIndex = 19;
            this.fromLabel.Text = "Из";
            // 
            // deleteEdge
            // 
            this.deleteEdge.Location = new System.Drawing.Point(127, 27);
            this.deleteEdge.Name = "deleteEdge";
            this.deleteEdge.Size = new System.Drawing.Size(24, 23);
            this.deleteEdge.TabIndex = 17;
            this.deleteEdge.Text = "-";
            this.deleteEdge.UseVisualStyleBackColor = true;
            this.deleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click);
            // 
            // addEdge
            // 
            this.addEdge.Location = new System.Drawing.Point(100, 27);
            this.addEdge.Name = "addEdge";
            this.addEdge.Size = new System.Drawing.Size(24, 23);
            this.addEdge.TabIndex = 16;
            this.addEdge.Text = "+";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.AddEdge_Click);
            // 
            // changeEdgesLabel
            // 
            this.changeEdgesLabel.AutoSize = true;
            this.changeEdgesLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changeEdgesLabel.Location = new System.Drawing.Point(3, 0);
            this.changeEdgesLabel.Name = "changeEdgesLabel";
            this.changeEdgesLabel.Size = new System.Drawing.Size(148, 23);
            this.changeEdgesLabel.TabIndex = 14;
            this.changeEdgesLabel.Text = "Номер вершины:";
            // 
            // traversalTab
            // 
            this.traversalTab.Controls.Add(this.isConnectedComponents);
            this.traversalTab.Controls.Add(this.traversalStartVertex);
            this.traversalTab.Controls.Add(this.startTraversal);
            this.traversalTab.Controls.Add(this.isDfs);
            this.traversalTab.Controls.Add(this.isBfs);
            this.traversalTab.Controls.Add(this.startedVertex);
            this.traversalTab.Location = new System.Drawing.Point(4, 22);
            this.traversalTab.Name = "traversalTab";
            this.traversalTab.Padding = new System.Windows.Forms.Padding(3);
            this.traversalTab.Size = new System.Drawing.Size(813, 90);
            this.traversalTab.TabIndex = 1;
            this.traversalTab.Text = "Обходы";
            this.traversalTab.UseVisualStyleBackColor = true;
            // 
            // isConnectedComponents
            // 
            this.isConnectedComponents.AutoSize = true;
            this.isConnectedComponents.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isConnectedComponents.Location = new System.Drawing.Point(134, 59);
            this.isConnectedComponents.Name = "isConnectedComponents";
            this.isConnectedComponents.Size = new System.Drawing.Size(134, 27);
            this.isConnectedComponents.TabIndex = 16;
            this.isConnectedComponents.Text = "Компоненты";
            this.isConnectedComponents.UseVisualStyleBackColor = true;
            // 
            // traversalStartVertex
            // 
            this.traversalStartVertex.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.traversalStartVertex.Location = new System.Drawing.Point(11, 26);
            this.traversalStartVertex.Name = "traversalStartVertex";
            this.traversalStartVertex.Size = new System.Drawing.Size(87, 26);
            this.traversalStartVertex.TabIndex = 15;
            this.traversalStartVertex.ValueChanged += new System.EventHandler(this.traversalStartVertex_ValueChanged);
            this.traversalStartVertex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TraversalStartVertex_KeyUp);
            // 
            // startTraversal
            // 
            this.startTraversal.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTraversal.Location = new System.Drawing.Point(104, 27);
            this.startTraversal.Name = "startTraversal";
            this.startTraversal.Size = new System.Drawing.Size(75, 26);
            this.startTraversal.TabIndex = 12;
            this.startTraversal.Text = "Старт";
            this.startTraversal.UseVisualStyleBackColor = true;
            this.startTraversal.Click += new System.EventHandler(this.StartTraversal_Click);
            // 
            // isDfs
            // 
            this.isDfs.AutoSize = true;
            this.isDfs.Checked = true;
            this.isDfs.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isDfs.Location = new System.Drawing.Point(70, 59);
            this.isDfs.Name = "isDfs";
            this.isDfs.Size = new System.Drawing.Size(58, 27);
            this.isDfs.TabIndex = 11;
            this.isDfs.TabStop = true;
            this.isDfs.Text = "DFS";
            this.isDfs.UseVisualStyleBackColor = true;
            // 
            // isBfs
            // 
            this.isBfs.AutoSize = true;
            this.isBfs.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isBfs.Location = new System.Drawing.Point(7, 59);
            this.isBfs.Name = "isBfs";
            this.isBfs.Size = new System.Drawing.Size(57, 27);
            this.isBfs.TabIndex = 10;
            this.isBfs.Text = "BFS";
            this.isBfs.UseVisualStyleBackColor = true;
            // 
            // startedVertex
            // 
            this.startedVertex.AutoSize = true;
            this.startedVertex.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startedVertex.Location = new System.Drawing.Point(3, 0);
            this.startedVertex.Name = "startedVertex";
            this.startedVertex.Size = new System.Drawing.Size(176, 23);
            this.startedVertex.TabIndex = 8;
            this.startedVertex.Text = "Начальная вершина:";
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(14, 29);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(0, 13);
            this.filePathLabel.TabIndex = 9;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "\"txt\"";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(846, 681);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.graphRoot);
            this.Controls.Add(this.navigationMenu);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.navigationMenu;
            this.Name = "MainWindow";
            this.Text = "GraphViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.navigationMenu.ResumeLayout(false);
            this.navigationMenu.PerformLayout();
            this.graphRoot.ResumeLayout(false);
            this.graphRoot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.plot)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.changeVertexTab.ResumeLayout(false);
            this.changeVertexTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeVertValue)).EndInit();
            this.changeEdgesTab.ResumeLayout(false);
            this.changeEdgesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.toEdgeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromEdgeValue)).EndInit();
            this.traversalTab.ResumeLayout(false);
            this.traversalTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traversalStartVertex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip navigationMenu;
        private System.Windows.Forms.ToolStripMenuItem fileOption;
        private System.Windows.Forms.ToolStripMenuItem openFileOption;
        private System.Windows.Forms.ToolStripMenuItem saveFileOption;
        private System.Windows.Forms.Panel graphRoot;
        private System.Windows.Forms.PictureBox plot;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label vertexValue;
        private System.Windows.Forms.Label edgesValue;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage changeVertexTab;
        private System.Windows.Forms.TabPage traversalTab;
        private System.Windows.Forms.Button startTraversal;
        private System.Windows.Forms.RadioButton isDfs;
        private System.Windows.Forms.RadioButton isBfs;
        private System.Windows.Forms.Label startedVertex;
        private System.Windows.Forms.Label changeVertexesLabel;
        private System.Windows.Forms.TabPage changeEdgesTab;
        private System.Windows.Forms.Button deleteVertex;
        private System.Windows.Forms.Button addVertex;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Button deleteEdge;
        private System.Windows.Forms.Button addEdge;
        private System.Windows.Forms.Label changeEdgesLabel;
        private System.Windows.Forms.OpenFileDialog openGraphFileDialog;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.NumericUpDown changeVertValue;
        private System.Windows.Forms.NumericUpDown toEdgeValue;
        private System.Windows.Forms.NumericUpDown fromEdgeValue;
        private System.Windows.Forms.NumericUpDown traversalStartVertex;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileOption;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem newFileOption;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitOption;
        private System.Windows.Forms.RadioButton isConnectedComponents;
        private System.Windows.Forms.Button makeGraphComplete;
        private System.Windows.Forms.Button clearEdges;
    }
}

