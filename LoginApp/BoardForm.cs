using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class BoardForm : Form
    {
        private readonly List<KanbanCard> _cards = new List<KanbanCard>();
        private readonly Dictionary<ColumnKind, FlowLayoutPanel> _columns =
            new Dictionary<ColumnKind, FlowLayoutPanel>();

        private CardControl _selected;

        public BoardForm()
        {
            InitializeComponent();

            // map designer panels
            _columns[ColumnKind.ToDo] = flpToDo;
            _columns[ColumnKind.InProgress] = flpInProgress;
            _columns[ColumnKind.Done] = flpDone;

            // ensure drag targets configured
            foreach (var flp in _columns.Values)
            {
                flp.AllowDrop = true;
                flp.DragEnter += Column_DragEnter;
                flp.DragOver += Column_DragOver;
                flp.DragDrop += Column_DragDrop;
            }

            RefreshBoard();
        }

        // ==================== CORE RENDERING =====================

        private void RefreshBoard()
        {
            // clear all except header label
            foreach (var kv in _columns)
            {
                var flp = kv.Value;
                for (int i = flp.Controls.Count - 1; i >= 1; i--)
                {
                    Control c = flp.Controls[i];
                    flp.Controls.RemoveAt(i);
                    c.Dispose();
                }
            }

            // add cards
            foreach (KanbanCard card in _cards.OrderBy(c => c.Order))
            {
                CardControl cc = new CardControl(card);
                WireCardHandlers(cc);
                _columns[card.Column].Controls.Add(cc);
            }
        }

        private void WireCardHandlers(CardControl cc)
        {
            cc.Selected += delegate { SelectCard(cc); };
            cc.EditRequested += delegate { EditCard(cc); };
            cc.DeleteRequested += delegate { DeleteCard(cc); };
        }

        private void SelectCard(CardControl cc)
        {
            if (_selected != null && _selected != cc)
                _selected.SetSelected(false);

            _selected = cc;
            _selected.SetSelected(true);
        }

        // ==================== BUTTON ACTIONS =====================

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KanbanCard newCard = new KanbanCard
            {
                Title = "New Card",
                Description = "",
                Column = ColumnKind.ToDo,
                Order = NextOrderFor(ColumnKind.ToDo)
            };

            using (EditCardDialog dlg = new EditCardDialog(newCard))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    _cards.Add(newCard);
                    RefreshBoard();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Select a card first.");
                return;
            }
            EditCard(_selected);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selected == null)
            {
                MessageBox.Show("Select a card first.");
                return;
            }
            DeleteCard(_selected);
        }

        // ==================== CARD ACTIONS =====================

        private void EditCard(CardControl cc)
        {
            if (cc == null) return;
            using (EditCardDialog dlg = new EditCardDialog(cc.Card))
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                    RefreshBoard();
            }
        }

        private void DeleteCard(CardControl cc)
        {
            if (cc == null) return;
            DialogResult res = MessageBox.Show(
                "Delete this card?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                _cards.Remove(cc.Card);
                RefreshBoard();
            }
        }

        private int NextOrderFor(ColumnKind col)
        {
            int max = -1;
            foreach (KanbanCard c in _cards)
                if (c.Column == col && c.Order > max)
                    max = c.Order;
            return max + 1;
        }

        // ==================== DRAG / DROP =====================

        private void Column_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(typeof(CardControl)))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Column_DragOver(object sender, DragEventArgs e)
        {
            // this is crucial; without it, drop never fires
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
            if (cardCtrl == null) return;

            FlowLayoutPanel sourcePanel = cardCtrl.Parent as FlowLayoutPanel;
            FlowLayoutPanel targetPanel = sender as FlowLayoutPanel;
            if (sourcePanel == null || targetPanel == null || sourcePanel == targetPanel)
                return;

            // Determine target column
            ColumnKind targetCol = ColumnKind.ToDo;
            foreach (KeyValuePair<ColumnKind, FlowLayoutPanel> kv in _columns)
            {
                if (kv.Value == targetPanel)
                {
                    targetCol = kv.Key;
                    break;
                }
            }

            // update model
            cardCtrl.Card.Column = targetCol;

            // physically move control
            sourcePanel.Controls.Remove(cardCtrl);
            targetPanel.Controls.Add(cardCtrl);

            // refresh order numbers
            ReorderColumn(targetCol, targetPanel);
            ReorderColumn(GetColumnKind(sourcePanel), sourcePanel);

            SelectCard(cardCtrl);
        }

        private void ReorderColumn(ColumnKind col, FlowLayoutPanel panel)
        {
            int offset = 1; // header label index
            for (int i = offset; i < panel.Controls.Count; i++)
            {
                CardControl cc = panel.Controls[i] as CardControl;
                if (cc != null)
                    cc.Card.Order = i - offset;
            }
        }

        private ColumnKind GetColumnKind(FlowLayoutPanel flp)
        {
            foreach (KeyValuePair<ColumnKind, FlowLayoutPanel> kv in _columns)
                if (kv.Value == flp) return kv.Key;
            return ColumnKind.ToDo;
        }
    }
}
