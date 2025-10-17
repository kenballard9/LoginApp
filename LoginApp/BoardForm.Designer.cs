using System.Windows.Forms;
using System.Drawing;

namespace LoginApp
{
    partial class BoardForm
    {
        private System.ComponentModel.IContainer components = null;

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flpToDo;
        private FlowLayoutPanel flpInProgress;
        private FlowLayoutPanel flpDone;
        private Label lblToDoHeader;
        private Label lblInProgressHeader;
        private Label lblDoneHeader;

        private ToolStrip toolStrip1;
        private ToolStripButton btnAdd;
        private ToolStripButton btnEdit;
        private ToolStripButton btnDelete;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.toolStrip1 = new ToolStrip();
            this.btnAdd = new ToolStripButton();
            this.btnEdit = new ToolStripButton();
            this.btnDelete = new ToolStripButton();

            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.flpToDo = new FlowLayoutPanel();
            this.flpInProgress = new FlowLayoutPanel();
            this.flpDone = new FlowLayoutPanel();

            this.lblToDoHeader = new Label();
            this.lblInProgressHeader = new Label();
            this.lblDoneHeader = new Label();

            // ----- ToolStrip -----
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new Size(20, 20);
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.btnAdd, this.btnEdit, this.btnDelete });
            this.toolStrip1.Location = new Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new Padding(4, 2, 4, 2);
            this.toolStrip1.Size = new Size(1393, 31);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";

            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // ----- TableLayoutPanel -----
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Margin = new Padding(0);
            this.tableLayoutPanel1.Size = new Size(1393, 796);
            this.tableLayoutPanel1.TabIndex = 0;

            // ----- flpToDo -----
            this.flpToDo.AllowDrop = true;
            this.flpToDo.AutoScroll = true;
            this.flpToDo.BackColor = Color.WhiteSmoke;
            this.flpToDo.Dock = DockStyle.Fill;
            this.flpToDo.FlowDirection = FlowDirection.TopDown;
            this.flpToDo.Location = new Point(6, 6);
            this.flpToDo.Margin = new Padding(6);
            this.flpToDo.Name = "flpToDo";
            this.flpToDo.Padding = new Padding(8);
            this.flpToDo.Size = new Size(455, 784);
            this.flpToDo.TabIndex = 1;
            this.flpToDo.WrapContents = false;

            // header
            this.lblToDoHeader.AutoSize = true;
            this.lblToDoHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblToDoHeader.Location = new Point(11, 8);
            this.lblToDoHeader.Margin = new Padding(3, 0, 3, 8);
            this.lblToDoHeader.Name = "lblToDoHeader";
            this.lblToDoHeader.Size = new Size(78, 30);
            this.lblToDoHeader.Text = "TO DO";
            this.flpToDo.Controls.Add(this.lblToDoHeader);

            // ----- flpInProgress -----
            this.flpInProgress.AllowDrop = true;
            this.flpInProgress.AutoScroll = true;
            this.flpInProgress.BackColor = Color.WhiteSmoke;
            this.flpInProgress.Dock = DockStyle.Fill;
            this.flpInProgress.FlowDirection = FlowDirection.TopDown;
            this.flpInProgress.Location = new Point(473, 6);
            this.flpInProgress.Margin = new Padding(6);
            this.flpInProgress.Name = "flpInProgress";
            this.flpInProgress.Padding = new Padding(8);
            this.flpInProgress.Size = new Size(455, 784);
            this.flpInProgress.TabIndex = 2;
            this.flpInProgress.WrapContents = false;

            this.lblInProgressHeader.AutoSize = true;
            this.lblInProgressHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblInProgressHeader.Location = new Point(11, 8);
            this.lblInProgressHeader.Margin = new Padding(3, 0, 3, 8);
            this.lblInProgressHeader.Name = "lblInProgressHeader";
            this.lblInProgressHeader.Size = new Size(155, 30);
            this.lblInProgressHeader.Text = "IN PROGRESS";
            this.flpInProgress.Controls.Add(this.lblInProgressHeader);

            // ----- flpDone -----
            this.flpDone.AllowDrop = true;
            this.flpDone.AutoScroll = true;
            this.flpDone.BackColor = Color.WhiteSmoke;
            this.flpDone.Dock = DockStyle.Fill;
            this.flpDone.FlowDirection = FlowDirection.TopDown;
            this.flpDone.Location = new Point(940, 6);
            this.flpDone.Margin = new Padding(6);
            this.flpDone.Name = "flpDone";
            this.flpDone.Padding = new Padding(8);
            this.flpDone.Size = new Size(447, 784);
            this.flpDone.TabIndex = 3;
            this.flpDone.WrapContents = false;

            this.lblDoneHeader.AutoSize = true;
            this.lblDoneHeader.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDoneHeader.Location = new Point(11, 8);
            this.lblDoneHeader.Margin = new Padding(3, 0, 3, 8);
            this.lblDoneHeader.Name = "lblDoneHeader";
            this.lblDoneHeader.Size = new Size(76, 30);
            this.lblDoneHeader.Text = "DONE";
            this.flpDone.Controls.Add(this.lblDoneHeader);

            // add columns to table
            this.tableLayoutPanel1.Controls.Add(this.flpToDo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpInProgress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.flpDone, 2, 0);

            // ----- BoardForm -----
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(1393, 827);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BoardForm";
            this.Text = "Kanban Board";
        }
    }
}
