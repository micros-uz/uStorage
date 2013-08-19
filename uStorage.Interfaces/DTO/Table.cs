using System.Collections.Generic;

namespace uStorage.Interfaces.DTO
{
    public class Table
    {
        public string Name { get; set; }
        public IEnumerable<Column> Columns { get; set; }
    }
}
