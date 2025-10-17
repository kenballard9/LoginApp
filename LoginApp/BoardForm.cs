using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class BoardForm : Form
    {
        private readonly List<KanbanCard> _cards;
        private readonly Dictionary<ColumnKind, FlowLayoutPanel> _columns;

        public BoardForm()
        {
            InitializeComponent();

            this.Text = "Kanban Board";
            this.BackColor = Color.Gainsboro;

            int colWidth = 270;
            ConfigureColumn(flpToDo, "TO DO", colWidth);
            ConfigureColumn(flpInProgress, "IN PROGRESS", colWidth);
            ConfigureColumn(flpDone, "DONE", colWidth);

            _cards = new List<KanbanCard>();

            _columns = new Dictionary<ColumnKind, FlowLayoutPanel>();
            _columns.Add(ColumnKind.ToDo, flpToDo);
            _columns.Add(ColumnKind.InProgress, flpInProgress);
            _columns.Add(ColumnKind.Done, flpDone);

            Seed();

            // Drag target wiring
            foreach (KeyValuePair<ColumnKind, FlowLayoutPanel> kvp in _columns)
            {
                FlowLayoutPanel flp = kvp.Value;
                flp.DragEnter += Column_DragEnter;
                flp.DragDrop += Column_DragDrop;
            }
        }

        private void ConfigureColumn(FlowLayoutPanel flp, string title, int width)
        {
            flp.Width = width;
            flp.BackColor = Color.WhiteSmoke;
            flp.Padding = new Padding(8);
            flp.AutoScroll = true;
            flp.AllowDrop = true;
            flp.FlowDirection = FlowDirection.TopDown;
            flp.WrapContents = false;

            Label header = new Label();
            header.Text = title;
            header.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            header.AutoSize = true;
            header.Margin = new Padding(3, 0, 3, 8);

            // Make sure header is present only once
            if (flp.Controls.Count == 0 || !(flp.Controls[0] is Label))
                flp.Controls.Add(header);
        }

        private void Seed()
        {
            _cards.Add(new KanbanCard { Title = "Design login form", Description = "User + password fields", Column = ColumnKind.ToDo, Tag = "auth" });
            _cards.Add(new KanbanCard { Title = "Implement Register", Description = "Write to store", Column = ColumnKind.InProgress, Tag = "auth" });
            _cards.Add(new KanbanCard { Title = "Wire Login", Description = "Validate credentials", Column = ColumnKind.Done, Tag = "auth" });

            RefreshBoard();
        }

        private void RefreshBoard()
        {
            // Clear everything except header (index 0)
            foreach (KeyValuePair<ColumnKind, FlowLayoutPanel> kvp in _columns)
            {
                FlowLayoutPanel flp = kvp.Value;
                for (int i = flp.Controls.Count - 1; i >= 1; i--)
                {
                    Control c = flp.Controls[i];
                    flp.Controls.RemoveAt(i);
                    c.Dispose();
                }
            }

            // Add cards to their columns
            List<KanbanCard> ordered = _cards.OrderBy(c => c.Order).ToList();
            for (int i = 0; i < ordered.Count; i++)
            {
                KanbanCard card = ordered[i];
                FlowLayoutPanel target = _columns[card.Column];
                target.Controls.Add(new CardControl(card));
            }
        }

        private void Column_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(CardControl)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Column_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null || !e.Data.GetDataPresent(typeof(CardControl)))
                return;

            CardControl cardCtrl = e.Data.GetData(typeof(CardControl)) as CardControl;
            FlowLayoutPanel sourcePanel = cardCtrl != null ? cardCtrl.Parent as FlowLayoutPanel : null;
            FlowLayoutPanel targetPanel = sender as FlowLayoutPanel;

            if (cardCtrl == null || sourcePanel == null || targetPanel == null || sourcePanel == targetPanel)
                return;

            // Update model
            KanbanCard card = cardCtrl.Card;
            ColumnKind newColumn = GetColumnKindForPanel(targetPanel);
            card.Column = newColumn;

            // Move control in UI (replace with fresh control to ensure layout refresh)
            sourcePanel.Controls.Remove(cardCtrl);
            cardCtrl.Dispose();
            targetPanel.Controls.Add(new CardControl(card));

            // Recalculate order within the target column
            ReorderColumn(newColumn, targetPanel);
        }

        private ColumnKind GetColumnKindForPanel(FlowLayoutPanel panel)
        {
            foreach (KeyValuePair<ColumnKind, FlowLayoutPanel> kvp in _columns)
            {
                if (kvp.Value == panel) return kvp.Key;
            }
            return ColumnKind.ToDo; // fallback
        }

        private void ReorderColumn(ColumnKind column, FlowLayoutPanel panel)
        {
            int headerOffset = 1; // header label at index 0
            for (int i = headerOffset; i < panel.Controls.Count; i++)
            {
                CardControl cc = panel.Controls[i] as CardControl;
                if (cc != null)
                {
                    cc.Card.Order = i - headerOffset;
                }
            }
        }

        private void flpToDo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
