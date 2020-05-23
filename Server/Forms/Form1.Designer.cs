using Server.Controls;
using System.Windows.Forms;

namespace Server.Forms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.contextClientsListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.computerOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAndExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.TimerCounter = new System.Windows.Forms.Timer(this.components);
            this.TimerPing = new System.Windows.Forms.Timer(this.components);
            this.clientsListView = new Server.Controls.BetterListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextClientsListView.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextClientsListView
            // 
            this.contextClientsListView.DropShadowEnabled = false;
            this.contextClientsListView.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextClientsListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.computerOptionsToolStripMenuItem,
            this.clientOptionsToolStripMenuItem,
            this.downloadAndExecuteToolStripMenuItem});
            this.contextClientsListView.Name = "contextClientsListView";
            this.contextClientsListView.Size = new System.Drawing.Size(219, 94);
            // 
            // computerOptionsToolStripMenuItem
            // 
            this.computerOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.logoffToolStripMenuItem});
            this.computerOptionsToolStripMenuItem.Image = global::Server.Properties.Resources.icons__3_;
            this.computerOptionsToolStripMenuItem.Name = "computerOptionsToolStripMenuItem";
            this.computerOptionsToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.computerOptionsToolStripMenuItem.Text = "Computer Options";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_restart_40;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_shutdown_40;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.ShutdownToolStripMenuItem_Click);
            // 
            // logoffToolStripMenuItem
            // 
            this.logoffToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_disclaimer_40;
            this.logoffToolStripMenuItem.Name = "logoffToolStripMenuItem";
            this.logoffToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.logoffToolStripMenuItem.Text = "Logoff";
            this.logoffToolStripMenuItem.Click += new System.EventHandler(this.LogoffToolStripMenuItem_Click);
            // 
            // clientOptionsToolStripMenuItem
            // 
            this.clientOptionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.restartToolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.clientOptionsToolStripMenuItem.Image = global::Server.Properties.Resources.icons__2_;
            this.clientOptionsToolStripMenuItem.Name = "clientOptionsToolStripMenuItem";
            this.clientOptionsToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.clientOptionsToolStripMenuItem.Text = "Client Options";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_downloading_updates_40;
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.UpdateToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_multiply_40;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem1
            // 
            this.restartToolStripMenuItem1.Image = global::Server.Properties.Resources.icons8_refresh_40;
            this.restartToolStripMenuItem1.Name = "restartToolStripMenuItem1";
            this.restartToolStripMenuItem1.Size = new System.Drawing.Size(119, 22);
            this.restartToolStripMenuItem1.Text = "Restart";
            this.restartToolStripMenuItem1.Click += new System.EventHandler(this.RestartToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Server.Properties.Resources.icons8_close_window_40;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // downloadAndExecuteToolStripMenuItem
            // 
            this.downloadAndExecuteToolStripMenuItem.Image = global::Server.Properties.Resources.icons__1_;
            this.downloadAndExecuteToolStripMenuItem.Name = "downloadAndExecuteToolStripMenuItem";
            this.downloadAndExecuteToolStripMenuItem.Size = new System.Drawing.Size(218, 30);
            this.downloadAndExecuteToolStripMenuItem.Text = "Download And Execute";
            this.downloadAndExecuteToolStripMenuItem.Click += new System.EventHandler(this.DownloadAndExecuteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(53)))), ((int)(((byte)(94)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 298);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(9, 0, 1, 0);
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(640, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "...";
            // 
            // TimerCounter
            // 
            this.TimerCounter.Enabled = true;
            this.TimerCounter.Interval = 1000;
            this.TimerCounter.Tick += new System.EventHandler(this.TimerCounter_Tick);
            // 
            // TimerPing
            // 
            this.TimerPing.Enabled = true;
            this.TimerPing.Interval = 30000;
            this.TimerPing.Tick += new System.EventHandler(this.TimerPing_Tick);
            // 
            // clientsListView
            // 
            this.clientsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.clientsListView.ContextMenuStrip = this.contextClientsListView;
            this.clientsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clientsListView.FullRowSelect = true;
            this.clientsListView.HideSelection = false;
            this.clientsListView.Location = new System.Drawing.Point(0, 0);
            this.clientsListView.Margin = new System.Windows.Forms.Padding(2);
            this.clientsListView.Name = "clientsListView";
            this.clientsListView.Size = new System.Drawing.Size(640, 298);
            this.clientsListView.TabIndex = 2;
            this.clientsListView.UseCompatibleStateImageBehavior = false;
            this.clientsListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Address";
            this.columnHeader1.Width = 163;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Username";
            this.columnHeader2.Width = 162;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Operating System ";
            this.columnHeader3.Width = 201;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Version";
            this.columnHeader4.Width = 153;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 320);
            this.Controls.Add(this.clientsListView);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DcBot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextClientsListView.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextClientsListView;
        private System.Windows.Forms.ToolStripMenuItem computerOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAndExecuteToolStripMenuItem;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Timer TimerCounter;
        private Timer TimerPing;
        public BetterListView clientsListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}