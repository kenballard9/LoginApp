using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginApp
{
    // Not partial – we’re not using a Designer file for this control
    public class CardControl : UserControl
    {
        public KanbanCard Card { get; }

        public event Action<CardControl> Selected;
        public event Action<CardControl> EditRequested;
        public event Action<CardControl> DeleteRequested;

        private bool _selected;

        public CardControl(KanbanCard card)
        {
            // No InitializeComponent() – UI is built entirely in code
            Card = card;

            Margin = new Padding(6);
            Padding = new Padding(8);
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Width = 240;
            Cursor = Cursors.SizeAll; // show move cursor

            var lblTitle = new Label
            {
                Text = card.Title,
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Dock = DockStyle.Top
            };

            var lblTag = new Label
            {
                Text = string.IsNullOrWhiteSpace(card.Tag) ? "" : $"#{card.Tag}",
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

            var panel = new Panel { Dock = DockStyle.Fill, AutoScroll = true };
            panel.Controls.Add(lblDesc);
            panel.Controls.Add(lblTag);
            panel.Controls.Add(lblTitle);

            Controls.Add(panel);

            // Right-click menu
            var menu = new ContextMenuStrip();
            menu.Items.Add("Edit...", null, (s, e) => { var h = EditRequested; if (h != null) h(this); });
            menu.Items.Add("Delete", null, (s, e) => { var h = DeleteRequested; if (h != null) h(this); });
            ContextMenuStrip = menu;

            // Make everything inside draggable
            AddDragHandlers(this);
            foreach (Control c in Controls)
                AddDragHandlers(c);

            // Left-click selects
            MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    var h = Selected;
                    if (h != null) h(this);
                }
            };
        }

        private void AddDragHandlers(Control ctl)
        {
            ctl.MouseDown += Card_MouseDown;
        }

        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // start drag for the whole card
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        public void SetSelected(bool selected)
        {
            _selected = selected;
            BackColor = selected ? Color.LightBlue : Color.White;
        }
    }
}
