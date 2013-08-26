using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using uStorage.Core.DAL;
using uStorage.Interfaces.DTO;
using uStorage.Interfaces.Services;
using System.Linq;

namespace uStorage.Core.Services
{
    internal class StorageService : IStorageService
    {
        private IStorageService This
        {
            get
            {
                return this;
            }
        }
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

        IEnumerable<Collection> IStorageService.GetCollections()
        {
            var res = new List<Collection>();

            try
            {
                var table = DbManager.ExecuteTable("select * from INFORMATION_SCHEMA.TABLES where TABLE_NAME not like '%{580947B8-E295-4D6C-9E80-FB889A8EB640}'");

                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        res.Add(new Collection
                        {
                            Name = row[2].ToString()
                        });
                    }
                }
            }
            catch (SqlException ex)
            {

            }

            return res;
        }

        string IStorageService.AddCollection(Collection table)
        {
            var res = string.Empty;
            var columns = MakeColumnsQuery(table.Columns);

            try
            {
                DbManager.ExecuteNonQuery(string.Format("create table [dbo].[{0}] ({1})", table.Name, columns));
                LogManager.Log("Add table", table.Name, null);
            }
            catch (SqlException ex)
            {
                res = ex.Message;
            }

            return res;
        }

        string IStorageService.DeleteCollection(Collection table)
        {
            var res = string.Empty;

            try
            {
                DbManager.ExecuteNonQuery(string.Format("drop table {0}", table.Name));
                LogManager.Log("Delete table", table.Name, null);
            }
            catch (SqlException ex)
            {
                res = ex.Message;
            }

            return res;
        }

        Tuple<bool, string> IStorageService.TestConnection()
        {
            throw new NotImplementedException();
        }

        string IStorageService.AddObject(string collectionName, object obj)
        {
            var collection = This.GetCollections().FirstOrDefault(x => x.Name == collectionName);

            if (collection == null)
            {

            }

            return null;
        }

        #endregion
    }
}
