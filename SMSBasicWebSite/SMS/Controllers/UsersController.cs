using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Models;
using SMS.Services.Contracts;

namespace SMS.Controllers
{

    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(Request request, IUserService userService)
            : base(request)
        {
            this.userService = userService;
        }

        public Response Register()
            => View(new { IsAuthenticated = false });

        public Response Login()
            => View(new { IsAuthenticated = false });


        [HttpPost]
        public Response Register(RegisterFormViewModel model)
        {
            var (isValid, error) = userService.AddRegister(model);

            if (!isValid) 
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            return View(new { IsAuthenticated = false }, "/Users/Login");
        }
        
        [HttpPost]
        public Response Login(LoginFormViewModel model) 
        {
            Request.Session.Clear();
            

            var (isLogin, userId) = userService.Login(model);

            if (!isLogin)
            {
                return View(new { ErrorMessage = "Invalid username or password" }, "/Error");
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName, Request.Session.Id);

            return Redirect("/");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }

    }
}
