using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginApp
{
    // No Designer file for this control
    public class CardControl : UserControl
    {
        public KanbanCard Card { get; }

        // Use EventHandler so BoardForm wiring like `cc.Selected += delegate { ... }` works cleanly
        public event EventHandler Selected;
        public event EventHandler EditRequested;
        public event EventHandler DeleteRequested;

        private bool _isSelected;

        public CardControl(KanbanCard card)
        {
            Card = card; // UI is built entirely in code

            Margin = new Padding(6);
            Padding = new Padding(8);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Width = 240;
            Cursor = Cursors.SizeAll; // hint it can be dragged

            var lblTitle = new Label
            {
                Text = card.Title,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Top
            };

            var lblTag = new Label
            {
                Text = string.IsNullOrWhiteSpace(card.Tag) ? "" : ("#" + card.Tag),
                AutoSize = true,
                ForeColor = Color.DimGray,
                Dock = DockStyle.Top
            };

            var lblDesc = new Label
            {
                Text = card.Description,
                AutoSize = true,
                MaximumSize = new Size(Width - 16, 0),
                Dock = DockStyle.Top
            };

            var content = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            content.Controls.Add(lblDesc);
            content.Controls.Add(lblTag);
            content.Controls.Add(lblTitle);

            Controls.Add(content);

            // Context menu (Edit/Delete)
            var menu = new ContextMenuStrip();
            menu.Items.Add("Edit...", null, (s, e) => { var h = EditRequested; if (h != null) h(this, EventArgs.Empty); });
            menu.Items.Add("Delete", null, (s, e) => { var h = DeleteRequested; if (h != null) h(this, EventArgs.Empty); });
            ContextMenuStrip = menu;

            // Make EVERYTHING (this control and all children) selectable + draggable
            WireAllChildControls(this);
        }

        // Wire recursively so clicks on labels/panel also select and start drag
        private void WireAllChildControls(Control parent)
        {
            parent.MouseDown += Card_MouseDown;

            foreach (Control child in parent.Controls)
            {
                child.MouseDown += Card_MouseDown;
                if (child.HasChildren)
                    WireAllChildControls(child);
            }
        }

        // Select on MouseDown (before starting DoDragDrop) so click always selects
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            // Fire selection immediately
            var sel = Selected;
            if (sel != null) sel(this, EventArgs.Empty);

            // Begin drag operation
            DoDragDrop(this, DragDropEffects.Move);
        }

        public void SetSelected(bool selected)
        {
            _isSelected = selected;
            BackColor = selected ? Color.LightBlue : Color.White;
        }
    }
}
