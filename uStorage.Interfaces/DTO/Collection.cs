using System.Collections.Generic;

namespace uStorage.Interfaces.DTO
{
    public class Collection
    {
        public string Name { get; set; }
        public IEnumerable<Column> Columns { get; set; }
    }
}
