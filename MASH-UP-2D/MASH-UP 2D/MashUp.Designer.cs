namespace MASH_UP_2D
{
    partial class MashUp
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.treeFiguras = new System.Windows.Forms.TreeView();
            this.addButton = new System.Windows.Forms.Button();
            this.buttonReproducir = new System.Windows.Forms.Button();
            this.temporizador = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelRotacion = new System.Windows.Forms.Label();
            this.saveStepButton = new System.Windows.Forms.Button();
            this.scrollAnimacion = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.checkfillBlankss = new System.Windows.Forms.CheckBox();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.PCT_SLIDER_Y = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.PCT_SLIDER_X = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAnimacion)).BeginInit();
            this.leftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_SLIDER_Y)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_SLIDER_X)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.canvas.BackColor = System.Drawing.Color.Black;
            this.canvas.Location = new System.Drawing.Point(113, 72);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1516, 744);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            this.canvas.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDoubleClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            this.canvas.Resize += new System.EventHandler(this.Form_Resize);
            // 
            // treeFiguras
            // 
            this.treeFiguras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeFiguras.BackColor = System.Drawing.Color.LightGray;
            this.treeFiguras.Location = new System.Drawing.Point(4, 72);
            this.treeFiguras.Margin = new System.Windows.Forms.Padding(2);
            this.treeFiguras.Name = "treeFiguras";
            this.treeFiguras.Size = new System.Drawing.Size(99, 576);
            this.treeFiguras.TabIndex = 1;
            this.treeFiguras.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeFiguras_AfterSelect);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.addButton.ForeColor = System.Drawing.Color.Black;
            this.addButton.Location = new System.Drawing.Point(7, 652);
            this.addButton.Margin = new System.Windows.Forms.Padding(2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(93, 29);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add Figure";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.AddFigureButton_Click);
            // 
            // buttonReproducir
            // 
            this.buttonReproducir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonReproducir.BackColor = System.Drawing.Color.DarkGreen;
            this.buttonReproducir.Location = new System.Drawing.Point(4, 718);
            this.buttonReproducir.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReproducir.Name = "buttonReproducir";
            this.buttonReproducir.Size = new System.Drawing.Size(93, 29);
            this.buttonReproducir.TabIndex = 4;
            this.buttonReproducir.Text = "Play";
            this.buttonReproducir.UseVisualStyleBackColor = false;
            this.buttonReproducir.Click += new System.EventHandler(this.buttonReproducir_Click);
            // 
            // temporizador
            // 
            this.temporizador.Enabled = true;
            this.temporizador.Tick += new System.EventHandler(this.temporizador_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(391, 533);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // labelRotacion
            // 
            this.labelRotacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRotacion.AutoSize = true;
            this.labelRotacion.BackColor = System.Drawing.Color.Transparent;
            this.labelRotacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelRotacion.ForeColor = System.Drawing.Color.White;
            this.labelRotacion.Location = new System.Drawing.Point(328, 850);
            this.labelRotacion.Name = "labelRotacion";
            this.labelRotacion.Size = new System.Drawing.Size(86, 18);
            this.labelRotacion.TabIndex = 7;
            this.labelRotacion.Text = "ROTACIÓN";
            // 
            // saveStepButton
            // 
            this.saveStepButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveStepButton.BackColor = System.Drawing.Color.Firebrick;
            this.saveStepButton.Location = new System.Drawing.Point(4, 685);
            this.saveStepButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveStepButton.Name = "saveStepButton";
            this.saveStepButton.Size = new System.Drawing.Size(93, 29);
            this.saveStepButton.TabIndex = 9;
            this.saveStepButton.Text = "Record";
            this.saveStepButton.UseVisualStyleBackColor = false;
            this.saveStepButton.Click += new System.EventHandler(this.saveStepButton_Click);
            // 
            // scrollAnimacion
            // 
            this.scrollAnimacion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollAnimacion.Location = new System.Drawing.Point(5, 12);
            this.scrollAnimacion.Margin = new System.Windows.Forms.Padding(2);
            this.scrollAnimacion.Maximum = 500;
            this.scrollAnimacion.Name = "scrollAnimacion";
            this.scrollAnimacion.Size = new System.Drawing.Size(1516, 45);
            this.scrollAnimacion.TabIndex = 10;
            this.scrollAnimacion.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.scrollAnimacion.Scroll += new System.EventHandler(this.scrollAnimacion_Scroll);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(822, 129);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 11;
            // 
            // checkfillBlankss
            // 
            this.checkfillBlankss.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.checkfillBlankss.AutoSize = true;
            this.checkfillBlankss.ForeColor = System.Drawing.Color.Black;
            this.checkfillBlankss.Location = new System.Drawing.Point(7, 16);
            this.checkfillBlankss.Name = "checkfillBlankss";
            this.checkfillBlankss.Size = new System.Drawing.Size(78, 17);
            this.checkfillBlankss.TabIndex = 12;
            this.checkfillBlankss.Text = "Animate All";
            this.checkfillBlankss.UseVisualStyleBackColor = true;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.treeFiguras);
            this.leftPanel.Controls.Add(this.addButton);
            this.leftPanel.Controls.Add(this.saveStepButton);
            this.leftPanel.Controls.Add(this.buttonReproducir);
            this.leftPanel.Controls.Add(this.checkfillBlankss);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(108, 878);
            this.leftPanel.TabIndex = 18;
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.PCT_SLIDER_Y);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(1634, 0);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(69, 878);
            this.RightPanel.TabIndex = 19;
            // 
            // PCT_SLIDER_Y
            // 
            this.PCT_SLIDER_Y.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCT_SLIDER_Y.Location = new System.Drawing.Point(1, 16);
            this.PCT_SLIDER_Y.Name = "PCT_SLIDER_Y";
            this.PCT_SLIDER_Y.Size = new System.Drawing.Size(63, 856);
            this.PCT_SLIDER_Y.TabIndex = 0;
            this.PCT_SLIDER_Y.TabStop = false;
            this.PCT_SLIDER_Y.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_Y_MouseDown);
            this.PCT_SLIDER_Y.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_Y_MouseMove);
            this.PCT_SLIDER_Y.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_Y_MouseUp);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.scrollAnimacion);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(108, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1526, 67);
            this.TopPanel.TabIndex = 20;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.PCT_SLIDER_X);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(108, 822);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1526, 56);
            this.BottomPanel.TabIndex = 21;
            // 
            // PCT_SLIDER_X
            // 
            this.PCT_SLIDER_X.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PCT_SLIDER_X.Location = new System.Drawing.Point(1, 3);
            this.PCT_SLIDER_X.Name = "PCT_SLIDER_X";
            this.PCT_SLIDER_X.Size = new System.Drawing.Size(1520, 50);
            this.PCT_SLIDER_X.TabIndex = 0;
            this.PCT_SLIDER_X.TabStop = false;
            this.PCT_SLIDER_X.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_X_MouseDown);
            this.PCT_SLIDER_X.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_X_MouseMove);
            this.PCT_SLIDER_X.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_SLIDER_X_MoveUp);
            // 
            // MashUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1703, 878);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelRotacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MashUp";
            this.Text = "FormAnimacionDeFiguras";
            this.Load += new System.EventHandler(this.FormAnimacionDeFiguras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollAnimacion)).EndInit();
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_SLIDER_Y)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_SLIDER_X)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TreeView treeFiguras;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button buttonReproducir;
        private System.Windows.Forms.Timer temporizador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelRotacion;
        private System.Windows.Forms.Button saveStepButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkfillBlankss;
        public System.Windows.Forms.TrackBar scrollAnimacion;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.PictureBox PCT_SLIDER_Y;
        private System.Windows.Forms.PictureBox PCT_SLIDER_X;
    }
}

