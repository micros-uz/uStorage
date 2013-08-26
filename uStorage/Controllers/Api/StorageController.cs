using System.Linq;
using System.Collections.Generic;
using System.Web.Http;
using uStorage.Interfaces.Services;
using uStorage.Core.Services;
using uStorage.Interfaces.DTO;

namespace uStorage.Web.Web.Controllers.Api
{
    [Authorize]
    public class StorageController : ApiController
    {
        private IStorageService _service;
        public StorageController(IStorageService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<string> GetCollections()
        {
            return _service.GetCollections().Select(x => x.Name);
        }

        [HttpPost]
        public string AddCollection(Collection table)
        {
            return _service.AddCollection(table);
        }

        [HttpPost]
        public string DelCollection(Collection table)
        {
            return _service.DeleteCollection(table);
        }

        [HttpPost]
        public string AddObject(string collectionName, object obj)
        {
            return _service.AddObject(collectionName, obj);
        }
    }
}
