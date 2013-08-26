using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using uStorage.Interfaces.DTO;
using uStorage.Web.ViewModels;

namespace uStorage.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Processes()
        {
            var model = Process.GetProcesses().Select(x => new ProcessModel
                {
                    Name = x.ProcessName,
                    WorkingSet = x.WorkingSet64
                });
            
            return View(model.OrderBy(x => x.Name));
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult TestTables()
        {
            return View();
        }

        public HttpResponseMessage TestWebApi()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = HttpContext.Request.UrlReferrer;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var addr = @"api/account/login";
            var lm = new LoginModel { UserName = "admin", Password = "dev1234" };
            HttpResponseMessage response = client.PostAsJsonAsync(addr, lm).Result;

            if (response.IsSuccessStatusCode)
            {
                response = client.GetAsync(@"api/sqlddl/gettables").Result;

                if (response.IsSuccessStatusCode)
                {
                    var tables = response.Content.ReadAsAsync<IEnumerable<string>>().Result;
                }

                response = client.PostAsJsonAsync("api/sqlcrud/addobject", new { Name = "fefe", Id = 90 }).Result;
            }

            return response;
        }

        class MongoEntity
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }

        }
        public string TestMongo()
        {
            var http = new HttpClient();

            var response = http.GetAsync(@"https://api.mongohq.com/databases/ustorage/collections/entities?_apikey=s3j8nui1phfxxi1ln6wj").Result;

            //if (response.IsSuccessStatusCode)
            //    return "OK";
            //else
            //    return "BAD";
            
            try
            {
                var connectionString = "mongodb://admin:dev1234@widmore.mongohq.com:10010/ustorage";

                var client = new MongoClient(connectionString);

                var server = client.GetServer();

                var database = server.GetDatabase("ustorage");

                var collection = database.GetCollection<MongoEntity>("entities");

                var cursor = collection.FindAll();

                var s = string.Empty;
                foreach (var item in cursor)
                {
                    s += item.Name + item.Id + "  ";
                }
                //var e = new MongoEntity { Name = "fefe" };
                //collection.Insert(e);
                //var id = e.Id;

                return s;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
                
            }
            
        }
    }
}
