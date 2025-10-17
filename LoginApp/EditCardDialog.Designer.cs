using System.Windows.Forms;
using System.Drawing;

namespace LoginApp
{
    partial class EditCardDialog
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnOK;
        private Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(38, 20);
            this.lblTitle.Text = "Title";

            // txtTitle
            this.txtTitle.Location = new Point(110, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(320, 26);

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new Point(12, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new Size(92, 20);
            this.lblDescription.Text = "Description";

            // txtDescription
            this.txtDescription.Location = new Point(110, 52);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = ScrollBars.Vertical;
            this.txtDescription.Size = new Size(320, 140);

            // btnOK
            this.btnOK.Location = new Point(264, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(80, 32);
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);

            // btnCancel
            this.btnCancel.Location = new Point(350, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(80, 32);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // EditCardDialog
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.AutoScaleDimensions = new SizeF(9F, 20F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(444, 250);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCardDialog";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Edit Card";

            // IMPORTANT: no Load event hookup here.
            // (No: this.Load += new System.EventHandler(this.EditCardDialog_Load);)

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
