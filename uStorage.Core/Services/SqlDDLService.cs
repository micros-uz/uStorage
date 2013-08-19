using System.Linq;
using System.Collections.Generic;
using uStorage.Core.DAL;
using uStorage.Interfaces.DTO;
using uStorage.Interfaces.Services;
using System.Data;
using System;
using System.Data.SqlClient;

namespace uStorage.Core.Services
{
    public class SqlDDLService : ISqlDDLService
    {
        private string MakeColumnsQuery(IEnumerable<Column> columns)
        {
            var res = string.Empty;

            foreach (var col in columns)
            {
                var pk = col.IsPrimaryKey 
                    ? (col.Type == "int" 
                        ? "identity(1, 1) primary key" 
                        : RaiseError()
                    ) 
                    : col.IsNotNull
                        ? "not null" 
                        : "null";

                var unique = col.IsUnique ? "unique" : string.Empty;
                var colStr = string.Format("[{0}] {1} {2} {3}", col.Title, col.Type, pk, unique);

                res += res.Equals(string.Empty) ? colStr : "," + colStr;
            }

            return res;
        }

        private string RaiseError()
        {
            throw new ArgumentException("PK column type should be int");
        }

        #region ISqlDDLService

        IEnumerable<Table> ISqlDDLService.GetTables()
        {
            var res = new List<Table>();

            try
            {
                var table = DbManager.ExecuteTable("select * from INFORMATION_SCHEMA.TABLES");

                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        res.Add(new Table
                        {
                            Name = row[2].ToString()
                        });
                    }
                }
            }
            catch(SqlException ex)
            {

            }

            return res;
        }

        string ISqlDDLService.AddTable(Table table)
        {
            var res = string.Empty;
            var columns = MakeColumnsQuery(table.Columns);

            try
            {
                DbManager.ExecuteNonQuery(string.Format("create table [dbo].[{0}] ({1})", table.Name, columns));
            }
            catch(SqlException ex)
            {
                res = ex.Message;
            }

            return res;
        }

        string ISqlDDLService.DeleteTable(Table table)
        {
            var res = string.Empty;

            try
            {
                DbManager.ExecuteNonQuery(string.Format("drop table {0}", table.Name));
            }
            catch (SqlException ex)
            {
                res = ex.Message;
            }

            return res;
        }

        void ISqlDDLService.AddColumn(Table table, Column column)
        {
            throw new System.NotImplementedException();
        }

        void ISqlDDLService.DeleteColumn(Table table, Column column)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
