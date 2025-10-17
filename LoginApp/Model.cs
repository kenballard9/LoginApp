using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp
{
    public enum ColumnKind { ToDo, InProgress, Done }

    public class KanbanCard
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public ColumnKind Column { get; set; } = ColumnKind.ToDo;
        public int Order { get; set; } // position inside column
        public string Tag { get; set; } = ""; // optional label
        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    }
}
