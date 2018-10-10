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

    [HttpGet]
    [Route("Users")]
    public IHttpActionResult Get()
    {
        string userKey = this.Request.Headers.GetValues("uk").FirstOrDefault();
        bool auth = false;
        User user;

        using (UserContext userContext = new UserContext())
        {
            auth = userContext.Authenticate(userKey);
        }

        if (auth)
        {
            user = UserContext.Get(userKey);

            return Ok(new
            {
                user.Id,
                user.DisplayName,
                user.IsUser
            });
        }

        return Ok("Unauthorized");
    }

    [HttpGet]
    [Route("Users({id})")]
    public IHttpActionResult Get(int id)
    {
        string userKey = this.Request.Headers.GetValues("uk").FirstOrDefault();
        bool auth = false;
        User user;

        using (UserContext userContext = new UserContext())
        {
            auth = userContext.Authenticate(userKey);
        }

        if (auth)
        {
            user = UserContext.Get(id);

            return Ok(new
            {
                user.Id,
                user.DisplayName,
                user.IsUser
            });
        }

        return Ok("Unauthorized");
    }

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
                SessionToken = sessionToken,
                User = new
                {
                    user.Id,
                    user.DisplayName,
                    user.IsUser
                }
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

        if(!IsValidEmail(email))
            return BadRequest("Not valid email.");

        if(displayName != null || displayName != "" || password != null || password != "")
            sucess = UserContext.Register(email, password, displayName);
        else
            return BadRequest("Please fill in all fields.");

        return Ok(new
        {
            Sucess = sucess
        });
    }

    bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}