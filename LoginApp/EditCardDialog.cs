using System;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class EditCardDialog : Form
    {
        private KanbanCard _card;

        public EditCardDialog(KanbanCard card)
        {
            InitializeComponent();
            _card = card;

            txtTitle.Text = card.Title;
            txtDescription.Text = card.Description;
        }

        private void EditCardDialog_Load(object sender, EventArgs e)
        {
            // This method is called when the dialog loads.
            // You can leave it empty or add setup logic here.
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            _card.Title = txtTitle.Text.Trim();
            _card.Description = txtDescription.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
