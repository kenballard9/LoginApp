using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    // NOTE: not 'partial' anymore since we aren't using a Designer file
    public class CardControl : UserControl
    {
        public KanbanCard Card { get; private set; }

        public CardControl(KanbanCard card)
        {
            Card = card;

            // Defaults that a Designer would usually set
            this.Name = "CardControl";
            this.AutoScaleMode = AutoScaleMode.None;
            this.Margin = new Padding(6);
            this.Padding = new Padding(8);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Width = 240; // FlowLayoutPanel will wrap height
            this.Cursor = Cursors.SizeAll; // hint that it can be dragged

            // Build the UI in code
            var lblTitle = new Label
            {
                Text = card.Title,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var lblTag = new Label
            {
                Text = string.IsNullOrWhiteSpace(card.Tag) ? "" : ("#" + card.Tag),
                AutoSize = true,
                ForeColor = Color.DimGray
            };

            var lblDesc = new Label
            {
                Text = card.Description,
                AutoSize = true,
                MaximumSize = new Size(this.Width - 16, 0)
            };

            var panel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                AutoSize = true
            };
            panel.RowStyles.Clear();
            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblTag);
            panel.Controls.Add(lblDesc);

            this.Controls.Add(panel);

            // Enable drag source
            this.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    DoDragDrop(this, DragDropEffects.Move);
            };

            // Right-click quick edit/delete
            var menu = new ContextMenuStrip();
            menu.Items.Add("Edit...", null, (s, e) => OnEdit());
            menu.Items.Add("Delete", null, (s, e) =>
            {
                if (this.Parent != null)
                    this.Parent.Controls.Remove(this);
            });
            this.ContextMenuStrip = menu;
        }

       private void OnEdit()
        {
            // If you don't have an EditCardDialog yet, you can remove this method
            // or guard it with an #if until it's implemented.
            using (var dlg = new EditCardDialog(Card))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // simple refresh
                    this.Controls.Clear();
                    var refreshed = new CardControl(Card) { Width = this.Width };
                    if (this.Parent != null)
                    {
                        this.Parent.Controls.Add(refreshed);
                        this.Parent.Controls.Remove(this);
                    }
                    refreshed.BringToFront();
                }
            }
        }
    }
}
