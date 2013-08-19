using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using uStorage.Web.ViewModels;

namespace uStorage.Web.Web.Controllers.Api
{
    [Authorize]
    public class AccountController : ApiController
    {
        public AccountController()
        {

        }

        [AllowAnonymous]
        [AcceptVerbs("GET")]
        public string Index()
        {
            return "value";
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage Login(LoginModel model)
        {
            if (model != null)
            {
                if (model.UserName == "admin" && model.Password == "dev1234")
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }

            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Invalid username/password");
        }

        [HttpGet]
        public HttpResponseMessage Logout()
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
