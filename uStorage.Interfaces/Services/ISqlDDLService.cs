using System.Collections.Generic;
using uStorage.Interfaces.DTO;

namespace uStorage.Interfaces.Services
{
    public interface ISqlDDLService
    {
        IEnumerable<Table> GetTables();
        string AddTable(Table table);
        string DeleteTable(Table table);
        void AddColumn(Table table, Column column);
        void DeleteColumn(Table table, Column column);
    }
}
