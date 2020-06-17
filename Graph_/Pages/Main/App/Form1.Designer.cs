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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.graphRoot = new System.Windows.Forms.Panel();
            this.vertexValue = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.edgesValue = new System.Windows.Forms.Label();
            this.centrateButton = new System.Windows.Forms.Button();
            this.edgesAtCircleButton = new System.Windows.Forms.Button();
            this.plot = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.changeVertexTab = new System.Windows.Forms.TabPage();
            this.changeVertValue = new System.Windows.Forms.NumericUpDown();
            this.deleteVertex = new System.Windows.Forms.Button();
            this.addVertex = new System.Windows.Forms.Button();
            this.changeVertexesLabel = new System.Windows.Forms.Label();
            this.changeEdgesTab = new System.Windows.Forms.TabPage();
            this.setWeightsByCoordsButton = new System.Windows.Forms.Button();
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
            this.resetButton = new System.Windows.Forms.Button();
            this.traversalStartVertex = new System.Windows.Forms.NumericUpDown();
            this.startTraversal = new System.Windows.Forms.Button();
            this.isDfs = new System.Windows.Forms.RadioButton();
            this.isBfs = new System.Windows.Forms.RadioButton();
            this.startedVertex = new System.Windows.Forms.Label();
            this.tspTab = new System.Windows.Forms.TabPage();
            this.GASettings = new System.Windows.Forms.Button();
            this.isLivePathUpdate = new System.Windows.Forms.CheckBox();
            this.EvolvSolutionLabel = new System.Windows.Forms.Label();
            this.TSP_startEvolvButton = new System.Windows.Forms.Button();
            this.clearCanvasButton = new System.Windows.Forms.Button();
            this.GreedySolutionLabel = new System.Windows.Forms.Label();
            this.BFSSolutionLabel = new System.Windows.Forms.Label();
            this.BNBSolutionLabel = new System.Windows.Forms.Label();
            this.TSP_startGreedyButton = new System.Windows.Forms.Button();
            this.TSP_startBFSButton = new System.Windows.Forms.Button();
            this.TSP_startBNBButton = new System.Windows.Forms.Button();
            this.TSPStartVertex = new System.Windows.Forms.NumericUpDown();
            this.startedVertexTSPLabel = new System.Windows.Forms.Label();
            this.settingsTab = new System.Windows.Forms.TabPage();
            this.resetNodeSizeButton = new System.Windows.Forms.Button();
            this.nodeSizeLabel = new System.Windows.Forms.Label();
            this.scallerTrackBar = new System.Windows.Forms.TrackBar();
            this.setWeightButton = new System.Windows.Forms.Button();
            this.isWeightedCheckBox = new System.Windows.Forms.CheckBox();
            this.isDirectedCheckBox = new System.Windows.Forms.CheckBox();
            this.navigationMenu = new System.Windows.Forms.MenuStrip();
            this.fileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.exitOption = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.openGraphFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.tspTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSPStartVertex)).BeginInit();
            this.settingsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scallerTrackBar)).BeginInit();
            this.navigationMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.graphRoot);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl);
            // 
            // graphRoot
            // 
            this.graphRoot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graphRoot.Controls.Add(this.vertexValue);
            this.graphRoot.Controls.Add(this.filePathLabel);
            this.graphRoot.Controls.Add(this.edgesValue);
            this.graphRoot.Controls.Add(this.centrateButton);
            this.graphRoot.Controls.Add(this.edgesAtCircleButton);
            this.graphRoot.Controls.Add(this.plot);
            resources.ApplyResources(this.graphRoot, "graphRoot");
            this.graphRoot.Name = "graphRoot";
            // 
            // vertexValue
            // 
            resources.ApplyResources(this.vertexValue, "vertexValue");
            this.vertexValue.Name = "vertexValue";
            // 
            // filePathLabel
            // 
            resources.ApplyResources(this.filePathLabel, "filePathLabel");
            this.filePathLabel.Name = "filePathLabel";
            // 
            // edgesValue
            // 
            resources.ApplyResources(this.edgesValue, "edgesValue");
            this.edgesValue.Name = "edgesValue";
            // 
            // centrateButton
            // 
            resources.ApplyResources(this.centrateButton, "centrateButton");
            this.centrateButton.Name = "centrateButton";
            this.centrateButton.UseVisualStyleBackColor = true;
            this.centrateButton.Click += new System.EventHandler(this.CentrateButton_Click);
            // 
            // edgesAtCircleButton
            // 
            resources.ApplyResources(this.edgesAtCircleButton, "edgesAtCircleButton");
            this.edgesAtCircleButton.Name = "edgesAtCircleButton";
            this.edgesAtCircleButton.UseVisualStyleBackColor = true;
            this.edgesAtCircleButton.Click += new System.EventHandler(this.edgesAtCircleButton_Click);
            // 
            // plot
            // 
            resources.ApplyResources(this.plot, "plot");
            this.plot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plot.Name = "plot";
            this.plot.TabStop = false;
            this.plot.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.Plot_GiveFeedback);
            this.plot.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.Plot_QueryContinueDrag);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.changeVertexTab);
            this.tabControl.Controls.Add(this.changeEdgesTab);
            this.tabControl.Controls.Add(this.traversalTab);
            this.tabControl.Controls.Add(this.tspTab);
            this.tabControl.Controls.Add(this.settingsTab);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl_Selecting);
            // 
            // changeVertexTab
            // 
            this.changeVertexTab.Controls.Add(this.changeVertValue);
            this.changeVertexTab.Controls.Add(this.deleteVertex);
            this.changeVertexTab.Controls.Add(this.addVertex);
            this.changeVertexTab.Controls.Add(this.changeVertexesLabel);
            resources.ApplyResources(this.changeVertexTab, "changeVertexTab");
            this.changeVertexTab.Name = "changeVertexTab";
            this.changeVertexTab.UseVisualStyleBackColor = true;
            // 
            // changeVertValue
            // 
            resources.ApplyResources(this.changeVertValue, "changeVertValue");
            this.changeVertValue.Name = "changeVertValue";
            this.changeVertValue.ValueChanged += new System.EventHandler(this.ChangeVertValue_ValueChanged);
            // 
            // deleteVertex
            // 
            resources.ApplyResources(this.deleteVertex, "deleteVertex");
            this.deleteVertex.Name = "deleteVertex";
            this.deleteVertex.UseVisualStyleBackColor = true;
            this.deleteVertex.Click += new System.EventHandler(this.DeleteVertex_Click);
            // 
            // addVertex
            // 
            resources.ApplyResources(this.addVertex, "addVertex");
            this.addVertex.Name = "addVertex";
            this.addVertex.UseVisualStyleBackColor = true;
            this.addVertex.Click += new System.EventHandler(this.AddVertex_Click);
            // 
            // changeVertexesLabel
            // 
            resources.ApplyResources(this.changeVertexesLabel, "changeVertexesLabel");
            this.changeVertexesLabel.Name = "changeVertexesLabel";
            // 
            // changeEdgesTab
            // 
            this.changeEdgesTab.Controls.Add(this.setWeightsByCoordsButton);
            this.changeEdgesTab.Controls.Add(this.clearEdges);
            this.changeEdgesTab.Controls.Add(this.makeGraphComplete);
            this.changeEdgesTab.Controls.Add(this.toEdgeValue);
            this.changeEdgesTab.Controls.Add(this.fromEdgeValue);
            this.changeEdgesTab.Controls.Add(this.toLabel);
            this.changeEdgesTab.Controls.Add(this.fromLabel);
            this.changeEdgesTab.Controls.Add(this.deleteEdge);
            this.changeEdgesTab.Controls.Add(this.addEdge);
            this.changeEdgesTab.Controls.Add(this.changeEdgesLabel);
            resources.ApplyResources(this.changeEdgesTab, "changeEdgesTab");
            this.changeEdgesTab.Name = "changeEdgesTab";
            this.changeEdgesTab.UseVisualStyleBackColor = true;
            // 
            // setWeightsByCoordsButton
            // 
            resources.ApplyResources(this.setWeightsByCoordsButton, "setWeightsByCoordsButton");
            this.setWeightsByCoordsButton.Name = "setWeightsByCoordsButton";
            this.setWeightsByCoordsButton.UseVisualStyleBackColor = true;
            this.setWeightsByCoordsButton.Click += new System.EventHandler(this.setWeightsByCoordsButton_Click);
            // 
            // clearEdges
            // 
            resources.ApplyResources(this.clearEdges, "clearEdges");
            this.clearEdges.Name = "clearEdges";
            this.clearEdges.UseVisualStyleBackColor = true;
            this.clearEdges.Click += new System.EventHandler(this.ClearEdges_Click);
            // 
            // makeGraphComplete
            // 
            resources.ApplyResources(this.makeGraphComplete, "makeGraphComplete");
            this.makeGraphComplete.Name = "makeGraphComplete";
            this.makeGraphComplete.UseVisualStyleBackColor = true;
            this.makeGraphComplete.Click += new System.EventHandler(this.MakeGraphComplete_Click);
            // 
            // toEdgeValue
            // 
            resources.ApplyResources(this.toEdgeValue, "toEdgeValue");
            this.toEdgeValue.Name = "toEdgeValue";
            this.toEdgeValue.ValueChanged += new System.EventHandler(this.ToEdgeValue_ValueChanged);
            // 
            // fromEdgeValue
            // 
            resources.ApplyResources(this.fromEdgeValue, "fromEdgeValue");
            this.fromEdgeValue.Name = "fromEdgeValue";
            this.fromEdgeValue.ValueChanged += new System.EventHandler(this.FromEdgeValue_ValueChanged);
            // 
            // toLabel
            // 
            resources.ApplyResources(this.toLabel, "toLabel");
            this.toLabel.Name = "toLabel";
            // 
            // fromLabel
            // 
            resources.ApplyResources(this.fromLabel, "fromLabel");
            this.fromLabel.Name = "fromLabel";
            // 
            // deleteEdge
            // 
            resources.ApplyResources(this.deleteEdge, "deleteEdge");
            this.deleteEdge.Name = "deleteEdge";
            this.deleteEdge.UseVisualStyleBackColor = true;
            this.deleteEdge.Click += new System.EventHandler(this.DeleteEdge_Click);
            // 
            // addEdge
            // 
            resources.ApplyResources(this.addEdge, "addEdge");
            this.addEdge.Name = "addEdge";
            this.addEdge.UseVisualStyleBackColor = true;
            this.addEdge.Click += new System.EventHandler(this.AddEdge_Click);
            // 
            // changeEdgesLabel
            // 
            resources.ApplyResources(this.changeEdgesLabel, "changeEdgesLabel");
            this.changeEdgesLabel.Name = "changeEdgesLabel";
            // 
            // traversalTab
            // 
            this.traversalTab.Controls.Add(this.isConnectedComponents);
            this.traversalTab.Controls.Add(this.resetButton);
            this.traversalTab.Controls.Add(this.traversalStartVertex);
            this.traversalTab.Controls.Add(this.startTraversal);
            this.traversalTab.Controls.Add(this.isDfs);
            this.traversalTab.Controls.Add(this.isBfs);
            this.traversalTab.Controls.Add(this.startedVertex);
            resources.ApplyResources(this.traversalTab, "traversalTab");
            this.traversalTab.Name = "traversalTab";
            this.traversalTab.UseVisualStyleBackColor = true;
            // 
            // isConnectedComponents
            // 
            resources.ApplyResources(this.isConnectedComponents, "isConnectedComponents");
            this.isConnectedComponents.Name = "isConnectedComponents";
            this.isConnectedComponents.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            resources.ApplyResources(this.resetButton, "resetButton");
            this.resetButton.Name = "resetButton";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // traversalStartVertex
            // 
            resources.ApplyResources(this.traversalStartVertex, "traversalStartVertex");
            this.traversalStartVertex.Name = "traversalStartVertex";
            this.traversalStartVertex.ValueChanged += new System.EventHandler(this.traversalStartVertex_ValueChanged);
            this.traversalStartVertex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TraversalStartVertex_KeyUp);
            // 
            // startTraversal
            // 
            resources.ApplyResources(this.startTraversal, "startTraversal");
            this.startTraversal.Name = "startTraversal";
            this.startTraversal.UseVisualStyleBackColor = true;
            this.startTraversal.Click += new System.EventHandler(this.StartTraversal_Click);
            // 
            // isDfs
            // 
            resources.ApplyResources(this.isDfs, "isDfs");
            this.isDfs.Checked = true;
            this.isDfs.Name = "isDfs";
            this.isDfs.TabStop = true;
            this.isDfs.UseVisualStyleBackColor = true;
            // 
            // isBfs
            // 
            resources.ApplyResources(this.isBfs, "isBfs");
            this.isBfs.Name = "isBfs";
            this.isBfs.UseVisualStyleBackColor = true;
            // 
            // startedVertex
            // 
            resources.ApplyResources(this.startedVertex, "startedVertex");
            this.startedVertex.Name = "startedVertex";
            // 
            // tspTab
            // 
            resources.ApplyResources(this.tspTab, "tspTab");
            this.tspTab.Controls.Add(this.GASettings);
            this.tspTab.Controls.Add(this.isLivePathUpdate);
            this.tspTab.Controls.Add(this.EvolvSolutionLabel);
            this.tspTab.Controls.Add(this.TSP_startEvolvButton);
            this.tspTab.Controls.Add(this.clearCanvasButton);
            this.tspTab.Controls.Add(this.GreedySolutionLabel);
            this.tspTab.Controls.Add(this.BFSSolutionLabel);
            this.tspTab.Controls.Add(this.BNBSolutionLabel);
            this.tspTab.Controls.Add(this.TSP_startGreedyButton);
            this.tspTab.Controls.Add(this.TSP_startBFSButton);
            this.tspTab.Controls.Add(this.TSP_startBNBButton);
            this.tspTab.Controls.Add(this.TSPStartVertex);
            this.tspTab.Controls.Add(this.startedVertexTSPLabel);
            this.tspTab.Name = "tspTab";
            this.tspTab.UseVisualStyleBackColor = true;
            // 
            // GASettings
            // 
            resources.ApplyResources(this.GASettings, "GASettings");
            this.GASettings.Name = "GASettings";
            this.GASettings.UseVisualStyleBackColor = true;
            this.GASettings.Click += new System.EventHandler(this.GASettings_Click);
            // 
            // isLivePathUpdate
            // 
            resources.ApplyResources(this.isLivePathUpdate, "isLivePathUpdate");
            this.isLivePathUpdate.Name = "isLivePathUpdate";
            this.isLivePathUpdate.UseVisualStyleBackColor = true;
            // 
            // EvolvSolutionLabel
            // 
            resources.ApplyResources(this.EvolvSolutionLabel, "EvolvSolutionLabel");
            this.EvolvSolutionLabel.Name = "EvolvSolutionLabel";
            // 
            // TSP_startEvolvButton
            // 
            resources.ApplyResources(this.TSP_startEvolvButton, "TSP_startEvolvButton");
            this.TSP_startEvolvButton.Name = "TSP_startEvolvButton";
            this.TSP_startEvolvButton.Tag = "Genetic algorithm";
            this.TSP_startEvolvButton.UseVisualStyleBackColor = true;
            this.TSP_startEvolvButton.Click += new System.EventHandler(this.TSP_startEvolvButton_Click);
            // 
            // clearCanvasButton
            // 
            resources.ApplyResources(this.clearCanvasButton, "clearCanvasButton");
            this.clearCanvasButton.Name = "clearCanvasButton";
            this.clearCanvasButton.UseVisualStyleBackColor = true;
            this.clearCanvasButton.Click += new System.EventHandler(this.clearCanvasButton_Click);
            // 
            // GreedySolutionLabel
            // 
            resources.ApplyResources(this.GreedySolutionLabel, "GreedySolutionLabel");
            this.GreedySolutionLabel.Name = "GreedySolutionLabel";
            // 
            // BFSSolutionLabel
            // 
            resources.ApplyResources(this.BFSSolutionLabel, "BFSSolutionLabel");
            this.BFSSolutionLabel.Name = "BFSSolutionLabel";
            // 
            // BNBSolutionLabel
            // 
            resources.ApplyResources(this.BNBSolutionLabel, "BNBSolutionLabel");
            this.BNBSolutionLabel.Name = "BNBSolutionLabel";
            // 
            // TSP_startGreedyButton
            // 
            resources.ApplyResources(this.TSP_startGreedyButton, "TSP_startGreedyButton");
            this.TSP_startGreedyButton.Name = "TSP_startGreedyButton";
            this.TSP_startGreedyButton.Tag = "Greedy algorithm";
            this.TSP_startGreedyButton.UseVisualStyleBackColor = true;
            this.TSP_startGreedyButton.Click += new System.EventHandler(this.TSP_startGreedyButton_Click);
            // 
            // TSP_startBFSButton
            // 
            resources.ApplyResources(this.TSP_startBFSButton, "TSP_startBFSButton");
            this.TSP_startBFSButton.Name = "TSP_startBFSButton";
            this.TSP_startBFSButton.Tag = "Brute force search";
            this.TSP_startBFSButton.UseVisualStyleBackColor = true;
            this.TSP_startBFSButton.Click += new System.EventHandler(this.TSP_startBFSButton_Click);
            // 
            // TSP_startBNBButton
            // 
            resources.ApplyResources(this.TSP_startBNBButton, "TSP_startBNBButton");
            this.TSP_startBNBButton.Name = "TSP_startBNBButton";
            this.TSP_startBNBButton.Tag = "Branch N Bounds";
            this.TSP_startBNBButton.UseVisualStyleBackColor = true;
            this.TSP_startBNBButton.Click += new System.EventHandler(this.startTSPButton_Click);
            // 
            // TSPStartVertex
            // 
            resources.ApplyResources(this.TSPStartVertex, "TSPStartVertex");
            this.TSPStartVertex.Name = "TSPStartVertex";
            // 
            // startedVertexTSPLabel
            // 
            resources.ApplyResources(this.startedVertexTSPLabel, "startedVertexTSPLabel");
            this.startedVertexTSPLabel.Name = "startedVertexTSPLabel";
            // 
            // settingsTab
            // 
            this.settingsTab.Controls.Add(this.resetNodeSizeButton);
            this.settingsTab.Controls.Add(this.nodeSizeLabel);
            this.settingsTab.Controls.Add(this.scallerTrackBar);
            this.settingsTab.Controls.Add(this.setWeightButton);
            this.settingsTab.Controls.Add(this.isWeightedCheckBox);
            this.settingsTab.Controls.Add(this.isDirectedCheckBox);
            resources.ApplyResources(this.settingsTab, "settingsTab");
            this.settingsTab.Name = "settingsTab";
            this.settingsTab.UseVisualStyleBackColor = true;
            // 
            // resetNodeSizeButton
            // 
            resources.ApplyResources(this.resetNodeSizeButton, "resetNodeSizeButton");
            this.resetNodeSizeButton.Name = "resetNodeSizeButton";
            this.resetNodeSizeButton.UseVisualStyleBackColor = true;
            this.resetNodeSizeButton.Click += new System.EventHandler(this.resetNodeSizeButton_Click);
            // 
            // nodeSizeLabel
            // 
            resources.ApplyResources(this.nodeSizeLabel, "nodeSizeLabel");
            this.nodeSizeLabel.Name = "nodeSizeLabel";
            // 
            // scallerTrackBar
            // 
            this.scallerTrackBar.LargeChange = 1;
            resources.ApplyResources(this.scallerTrackBar, "scallerTrackBar");
            this.scallerTrackBar.Maximum = 20;
            this.scallerTrackBar.Minimum = 1;
            this.scallerTrackBar.Name = "scallerTrackBar";
            this.scallerTrackBar.Value = 10;
            this.scallerTrackBar.ValueChanged += new System.EventHandler(this.scallerTrackBar_ValueChanged);
            // 
            // setWeightButton
            // 
            resources.ApplyResources(this.setWeightButton, "setWeightButton");
            this.setWeightButton.Name = "setWeightButton";
            this.setWeightButton.UseVisualStyleBackColor = true;
            this.setWeightButton.Click += new System.EventHandler(this.setWeightButton_Click);
            // 
            // isWeightedCheckBox
            // 
            resources.ApplyResources(this.isWeightedCheckBox, "isWeightedCheckBox");
            this.isWeightedCheckBox.Name = "isWeightedCheckBox";
            this.isWeightedCheckBox.UseVisualStyleBackColor = true;
            this.isWeightedCheckBox.CheckedChanged += new System.EventHandler(this.isWeightedCheckBox_CheckedChanged);
            // 
            // isDirectedCheckBox
            // 
            resources.ApplyResources(this.isDirectedCheckBox, "isDirectedCheckBox");
            this.isDirectedCheckBox.Name = "isDirectedCheckBox";
            this.isDirectedCheckBox.UseVisualStyleBackColor = true;
            this.isDirectedCheckBox.CheckedChanged += new System.EventHandler(this.isDirectedCheckBox_CheckedChanged);
            // 
            // navigationMenu
            // 
            this.navigationMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.navigationMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOption,
            this.editToolStripMenuItem});
            resources.ApplyResources(this.navigationMenu, "navigationMenu");
            this.navigationMenu.Name = "navigationMenu";
            // 
            // fileOption
            // 
            this.fileOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileOption,
            this.openFileOption,
            this.saveFileOption,
            this.saveImageToolStripMenuItem,
            this.saveAsFileOption,
            this.toolStripSeparator1,
            this.settingsOption,
            this.exitOption});
            this.fileOption.Name = "fileOption";
            resources.ApplyResources(this.fileOption, "fileOption");
            // 
            // newFileOption
            // 
            this.newFileOption.Name = "newFileOption";
            resources.ApplyResources(this.newFileOption, "newFileOption");
            this.newFileOption.Click += new System.EventHandler(this.NewFileOption_Click);
            // 
            // openFileOption
            // 
            this.openFileOption.Name = "openFileOption";
            resources.ApplyResources(this.openFileOption, "openFileOption");
            this.openFileOption.Click += new System.EventHandler(this.OpenFileOption_Click);
            // 
            // saveFileOption
            // 
            this.saveFileOption.Name = "saveFileOption";
            resources.ApplyResources(this.saveFileOption, "saveFileOption");
            this.saveFileOption.Click += new System.EventHandler(this.SaveFileOption_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pngToolStripMenuItem,
            this.jpgToolStripMenuItem});
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            resources.ApplyResources(this.saveImageToolStripMenuItem, "saveImageToolStripMenuItem");
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            resources.ApplyResources(this.pngToolStripMenuItem, "pngToolStripMenuItem");
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // jpgToolStripMenuItem
            // 
            this.jpgToolStripMenuItem.Name = "jpgToolStripMenuItem";
            resources.ApplyResources(this.jpgToolStripMenuItem, "jpgToolStripMenuItem");
            this.jpgToolStripMenuItem.Click += new System.EventHandler(this.jpgToolStripMenuItem_Click);
            // 
            // saveAsFileOption
            // 
            this.saveAsFileOption.Name = "saveAsFileOption";
            resources.ApplyResources(this.saveAsFileOption, "saveAsFileOption");
            this.saveAsFileOption.Click += new System.EventHandler(this.SaveAsFileOption_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // settingsOption
            // 
            this.settingsOption.Name = "settingsOption";
            resources.ApplyResources(this.settingsOption, "settingsOption");
            this.settingsOption.Click += new System.EventHandler(this.settingsOption_Click);
            // 
            // exitOption
            // 
            this.exitOption.Name = "exitOption";
            resources.ApplyResources(this.exitOption, "exitOption");
            this.exitOption.Click += new System.EventHandler(this.ExitOption_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // undoButton
            // 
            resources.ApplyResources(this.undoButton, "undoButton");
            this.undoButton.Name = "undoButton";
            this.undoButton.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "\"txt\"";
            this.saveFileDialog.SupportMultiDottedExtensions = true;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.navigationMenu);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.MainMenuStrip = this.navigationMenu;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
            this.tspTab.ResumeLayout(false);
            this.tspTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TSPStartVertex)).EndInit();
            this.settingsTab.ResumeLayout(false);
            this.settingsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scallerTrackBar)).EndInit();
            this.navigationMenu.ResumeLayout(false);
            this.navigationMenu.PerformLayout();
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
        private System.Windows.Forms.Button centrateButton;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoButton;
        private System.Windows.Forms.ToolStripMenuItem settingsOption;
        private System.Windows.Forms.Button edgesAtCircleButton;
        private System.Windows.Forms.TabPage settingsTab;
        private System.Windows.Forms.CheckBox isWeightedCheckBox;
        private System.Windows.Forms.CheckBox isDirectedCheckBox;
        private System.Windows.Forms.Button setWeightButton;
        private System.Windows.Forms.TabPage tspTab;
        private System.Windows.Forms.NumericUpDown TSPStartVertex;
        private System.Windows.Forms.Label startedVertexTSPLabel;
        private System.Windows.Forms.Button TSP_startBNBButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button TSP_startGreedyButton;
        private System.Windows.Forms.Button TSP_startBFSButton;
        private System.Windows.Forms.Label GreedySolutionLabel;
        private System.Windows.Forms.Label BFSSolutionLabel;
        private System.Windows.Forms.Label BNBSolutionLabel;
        private System.Windows.Forms.Button clearCanvasButton;
        private System.Windows.Forms.Button setWeightsByCoordsButton;
        private System.Windows.Forms.TrackBar scallerTrackBar;
        private System.Windows.Forms.Label nodeSizeLabel;
        private System.Windows.Forms.Button resetNodeSizeButton;
        private System.Windows.Forms.Label EvolvSolutionLabel;
        private System.Windows.Forms.Button TSP_startEvolvButton;
        private System.Windows.Forms.CheckBox isLivePathUpdate;
        private System.Windows.Forms.Button GASettings;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jpgToolStripMenuItem;
    }
}

