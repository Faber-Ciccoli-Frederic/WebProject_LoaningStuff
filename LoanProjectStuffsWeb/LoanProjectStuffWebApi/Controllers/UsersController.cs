using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoanProjectStuffWebApi.Controllers
{
    public class UsersController : ApiController
    {
        [Route("api/users/{login}/{password}")]
        [HttpGet]
        public DataContracts.User GetUser(String login, String password)
        {
            using (var context = new Data.CorteProjectEntities())
            {
                return context.Users.Where(@u => @u.Login == login && @u.Password == password).Select(@u => new DataContracts.User() { Id = @u.Id, Login = @u.Login, Password = @u.Password, Role = @u.Role, FirstName = @u.FirstName, LastName = @u.LastName, Phone = @u.Phone, MobilePhone = @u.MobilePhone, Address = @u.Address }).FirstOrDefault();
            }
        }

        [Route("api/users")]
        [HttpPost]
        public void InsertUser([FromBody] DataContracts.User user)
        {
            using (var context = new Data.CorteProjectEntities())
            {
                context.Users.Add(new Data.User() {Login = user.Login, Password = user.Password, Role = user.Role, FirstName = user.FirstName, LastName = user.LastName, Phone = user.Phone, MobilePhone = user.MobilePhone, Address = user.Address});
            }
        }

        [Route("api/users/{id}")]
        [HttpGet]
        public DataContracts.User Get(Int32 id)
        {
            using (var context = new Data.CorteProjectEntities())
            {
                return context.Users.Where(@u => @u.Id == id ).Select(@u => new DataContracts.User() { Id = @u.Id, Login = @u.Login, Password = @u.Password, Role = @u.Role, FirstName = @u.FirstName, LastName = @u.LastName, Phone = @u.Phone, MobilePhone = @u.MobilePhone, Address = @u.Address }).FirstOrDefault();
            }
        }
    }
}

/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoanProjectStuffWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Users", action = "Get", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default2",
                url: "{controller}/{action}/{login}/{password}",
                defaults: new { controller = "Users", action = "GetUser", login = UrlParameter.Optional, password = UrlParameter.Optional }
            );
            
        }
    }
}
*/