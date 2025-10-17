namespace LoginApp
{
    partial class BoardForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flpToDo = new System.Windows.Forms.FlowLayoutPanel();
            this.lblToDoHeader = new System.Windows.Forms.Label();
            this.flpInProgress = new System.Windows.Forms.FlowLayoutPanel();
            this.lblInProgressHeader = new System.Windows.Forms.Label();
            this.flpDone = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDoneHeader = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.flpToDo.SuspendLayout();
            this.flpInProgress.SuspendLayout();
            this.flpDone.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.flpToDo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpInProgress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpDone, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1393, 827);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flpToDo
            // 
            this.flpToDo.AllowDrop = true;
            this.flpToDo.AutoScroll = true;
            this.flpToDo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpToDo.Controls.Add(this.lblToDoHeader);
            this.flpToDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpToDo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpToDo.Location = new System.Drawing.Point(6, 6);
            this.flpToDo.Margin = new System.Windows.Forms.Padding(6);
            this.flpToDo.Name = "flpToDo";
            this.flpToDo.Padding = new System.Windows.Forms.Padding(8);
            this.flpToDo.Size = new System.Drawing.Size(452, 815);
            this.flpToDo.TabIndex = 1;
            this.flpToDo.WrapContents = false;
            this.flpToDo.Paint += new System.Windows.Forms.PaintEventHandler(this.flpToDo_Paint);
            // 
            // lblToDoHeader
            // 
            this.lblToDoHeader.AutoSize = true;
            this.lblToDoHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblToDoHeader.Location = new System.Drawing.Point(11, 8);
            this.lblToDoHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblToDoHeader.Name = "lblToDoHeader";
            this.lblToDoHeader.Size = new System.Drawing.Size(81, 30);
            this.lblToDoHeader.TabIndex = 0;
            this.lblToDoHeader.Text = "TO DO";
            // 
            // flpInProgress
            // 
            this.flpInProgress.AllowDrop = true;
            this.flpInProgress.AutoScroll = true;
            this.flpInProgress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpInProgress.Controls.Add(this.lblInProgressHeader);
            this.flpInProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpInProgress.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpInProgress.Location = new System.Drawing.Point(470, 6);
            this.flpInProgress.Margin = new System.Windows.Forms.Padding(6);
            this.flpInProgress.Name = "flpInProgress";
            this.flpInProgress.Padding = new System.Windows.Forms.Padding(8);
            this.flpInProgress.Size = new System.Drawing.Size(452, 815);
            this.flpInProgress.TabIndex = 2;
            this.flpInProgress.WrapContents = false;
            // 
            // lblInProgressHeader
            // 
            this.lblInProgressHeader.AutoSize = true;
            this.lblInProgressHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblInProgressHeader.Location = new System.Drawing.Point(11, 8);
            this.lblInProgressHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblInProgressHeader.Name = "lblInProgressHeader";
            this.lblInProgressHeader.Size = new System.Drawing.Size(154, 30);
            this.lblInProgressHeader.TabIndex = 0;
            this.lblInProgressHeader.Text = "IN PROGRESS";
            // 
            // flpDone
            // 
            this.flpDone.AllowDrop = true;
            this.flpDone.AutoScroll = true;
            this.flpDone.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flpDone.Controls.Add(this.lblDoneHeader);
            this.flpDone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpDone.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDone.Location = new System.Drawing.Point(934, 6);
            this.flpDone.Margin = new System.Windows.Forms.Padding(6);
            this.flpDone.Name = "flpDone";
            this.flpDone.Padding = new System.Windows.Forms.Padding(8);
            this.flpDone.Size = new System.Drawing.Size(453, 815);
            this.flpDone.TabIndex = 3;
            this.flpDone.WrapContents = false;
            // 
            // lblDoneHeader
            // 
            this.lblDoneHeader.AutoSize = true;
            this.lblDoneHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDoneHeader.Location = new System.Drawing.Point(11, 8);
            this.lblDoneHeader.Margin = new System.Windows.Forms.Padding(3, 0, 3, 8);
            this.lblDoneHeader.Name = "lblDoneHeader";
            this.lblDoneHeader.Size = new System.Drawing.Size(75, 30);
            this.lblDoneHeader.TabIndex = 0;
            this.lblDoneHeader.Text = "DONE";
            // 
            // BoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1393, 827);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BoardForm";
            this.Text = "Kanban Board";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flpToDo.ResumeLayout(false);
            this.flpToDo.PerformLayout();
            this.flpInProgress.ResumeLayout(false);
            this.flpInProgress.PerformLayout();
            this.flpDone.ResumeLayout(false);
            this.flpDone.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpToDo;
        private System.Windows.Forms.FlowLayoutPanel flpInProgress;
        private System.Windows.Forms.FlowLayoutPanel flpDone;
        private System.Windows.Forms.Label lblToDoHeader;
        private System.Windows.Forms.Label lblInProgressHeader;
        private System.Windows.Forms.Label lblDoneHeader;
    }
}
