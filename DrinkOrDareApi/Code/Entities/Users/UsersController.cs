using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class UsersController : ApiController
{
    private UserContext UserContext = new UserContext();

    [HttpPost]
    [Route("Users/Login")]
    public IHttpActionResult Login(JObject json)
    {
        var email = json["Email"]?.ToString();
        var password = json["Password"]?.ToString();

        var user = UserContext.Login(email, password);

        if (user != null)
        {
            var sessionToken = UserContext.IniciateUserSession(user.Id, user.IsUser);

            return Ok(new
            {
                SessionToken = sessionToken
            });
        }
        else
            return Ok("Unauthorized");
    }

    [HttpPost]
    [Route("Users/TempLogin")]
    public IHttpActionResult TempLogin(JObject json)
    {
        var displayName = json["DisplayName"]?.ToString();

        var user = UserContext.TempLogin(displayName);

        if (user != null)
        {
            var sessionToken = UserContext.IniciateUserSession(user.Id, user.IsUser);

            return Ok(new
            {
                SessionToken = sessionToken
            });
        }
        else
            return Ok("Unauthorized");
    }

    [HttpPost]
    [Route("Users/Register")]
    public IHttpActionResult Register(JObject json)
    {
        var email = json["Email"]?.ToString();
        var displayName = json["DisplayName"]?.ToString();
        var password = json["Password"]?.ToString();

        bool sucess = false;

        if (email != null || email != "" || displayName != null || displayName != "" || password != null || password != "")
            sucess = UserContext.Register(email, password, displayName);
        else
            return BadRequest("please fill in all fields.");

        return Ok(new
        {
            Sucess = sucess
        });
    }
}