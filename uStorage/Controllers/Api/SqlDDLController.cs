using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using uStorage.Interfaces.Services;
using uStorage.Core.Services;
using uStorage.Interfaces.DTO;

namespace uStorage.Controllers.Api
{
    [Authorize]
    public class SqlDDLController : ApiController
    {
        private ISqlDDLService _service;
        public SqlDDLController()
        {
            _service = new SqlDDLService();
        }

        [HttpGet]
        public IEnumerable<string> GetTables()
        {
            return _service.GetTables().Select(x => x.Name);
        }

        [HttpPost]
        public string AddTable(Table table)
        {
            return _service.AddTable(table);
        }

        [HttpPost]
        public string DeleteTable(Table table)
        {
            return _service.DeleteTable(table)
        }
    }
}
