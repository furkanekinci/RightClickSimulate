namespace RightClickSimulate
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.doubleClickTimer = new System.Windows.Forms.Timer(this.components);
            this.sysTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cntMnuSysTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntMnuSysTray_Static = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMnuSysTray_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.cntMnuSysTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // sysTray
            // 
            this.sysTray.ContextMenuStrip = this.cntMnuSysTray;
            this.sysTray.Icon = ((System.Drawing.Icon)(resources.GetObject("sysTray.Icon")));
            this.sysTray.Text = "Right Click Simulate";
            this.sysTray.Visible = true;
            this.sysTray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sysTray_MouseClick);
            this.sysTray.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sysTray_MouseUp);
            // 
            // cntMnuSysTray
            // 
            this.cntMnuSysTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntMnuSysTray_Static,
            this.cntMnuSysTray_Exit});
            this.cntMnuSysTray.Name = "cntMnuSysTray";
            this.cntMnuSysTray.Size = new System.Drawing.Size(101, 48);
            this.cntMnuSysTray.MouseLeave += new System.EventHandler(this.cntMnuSysTray_MouseLeave);
            // 
            // cntMnuSysTray_Static
            // 
            this.cntMnuSysTray_Static.CheckOnClick = true;
            this.cntMnuSysTray_Static.Name = "cntMnuSysTray_Static";
            this.cntMnuSysTray_Static.Size = new System.Drawing.Size(100, 22);
            this.cntMnuSysTray_Static.Text = "Sabit";
            this.cntMnuSysTray_Static.CheckedChanged += new System.EventHandler(this.cntMnuSysTray_Static_CheckedChanged);
            // 
            // cntMnuSysTray_Exit
            // 
            this.cntMnuSysTray_Exit.Name = "cntMnuSysTray_Exit";
            this.cntMnuSysTray_Exit.Size = new System.Drawing.Size(100, 22);
            this.cntMnuSysTray_Exit.Text = "Çıkış";
            this.cntMnuSysTray_Exit.Click += new System.EventHandler(this.cntMnuSysTray_Exit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(50, 50);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(50, 50);
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Right Click Simulate";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmMain_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
            this.cntMnuSysTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer doubleClickTimer;
        private System.Windows.Forms.NotifyIcon sysTray;
        private System.Windows.Forms.ContextMenuStrip cntMnuSysTray;
        private System.Windows.Forms.ToolStripMenuItem cntMnuSysTray_Static;
        private System.Windows.Forms.ToolStripMenuItem cntMnuSysTray_Exit;

    }
}

