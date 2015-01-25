namespace ControllerServer
{
    partial class ControllerServer
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
            this.lblWebSockets = new System.Windows.Forms.Label();
            this.picWebSocketsActivated = new System.Windows.Forms.PictureBox();
            this.lvControllers = new System.Windows.Forms.ListView();
            this.bwServerRunner = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picWebSocketsActivated)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWebSockets
            // 
            this.lblWebSockets.AutoSize = true;
            this.lblWebSockets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lblWebSockets.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebSockets.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.lblWebSockets.Location = new System.Drawing.Point(25, 39);
            this.lblWebSockets.Name = "lblWebSockets";
            this.lblWebSockets.Size = new System.Drawing.Size(304, 37);
            this.lblWebSockets.TabIndex = 0;
            this.lblWebSockets.Text = "WebSockets Connection";
            // 
            // picWebSocketsActivated
            // 
            this.picWebSocketsActivated.BackgroundImage = global::ControllerServer.Properties.Resources.inactive;
            this.picWebSocketsActivated.Image = global::ControllerServer.Properties.Resources.inactive;
            this.picWebSocketsActivated.Location = new System.Drawing.Point(348, 39);
            this.picWebSocketsActivated.Name = "picWebSocketsActivated";
            this.picWebSocketsActivated.Size = new System.Drawing.Size(42, 42);
            this.picWebSocketsActivated.TabIndex = 1;
            this.picWebSocketsActivated.TabStop = false;
            // 
            // lvControllers
            // 
            this.lvControllers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.lvControllers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvControllers.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvControllers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(246)))), ((int)(((byte)(255)))));
            this.lvControllers.Location = new System.Drawing.Point(32, 103);
            this.lvControllers.Name = "lvControllers";
            this.lvControllers.Size = new System.Drawing.Size(358, 266);
            this.lvControllers.TabIndex = 3;
            this.lvControllers.UseCompatibleStateImageBehavior = false;
            this.lvControllers.View = System.Windows.Forms.View.Tile;
            // 
            // ControllerServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ControllerServer.Properties.Resources.circuit_board_wallpaper;
            this.ClientSize = new System.Drawing.Size(422, 381);
            this.Controls.Add(this.lvControllers);
            this.Controls.Add(this.picWebSocketsActivated);
            this.Controls.Add(this.lblWebSockets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ControllerServer";
            this.ShowIcon = false;
            this.Text = "ControllerServer";
            ((System.ComponentModel.ISupportInitialize)(this.picWebSocketsActivated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWebSockets;
        private System.Windows.Forms.PictureBox picWebSocketsActivated;
        private System.Windows.Forms.ListView lvControllers;
        private System.ComponentModel.BackgroundWorker bwServerRunner;
    }
}

