using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

public class DaresController : ApiController
{

    private DareContext DareContext = new DareContext();

    [HttpGet]
    [Route("Dares")]
    public IHttpActionResult Get()
    {
        string userKey = this.Request.Headers.GetValues("uk").FirstOrDefault();
        bool auth = false;
        Dare dare;

        using (UserContext userContext = new UserContext())
        {
            auth = userContext.Authenticate(userKey);
        }

        if(auth)
        {
            dare = DareContext.GetDare();
            return Ok(new
            {
                Dare = dare.DareText,
                dare.Description,
                dare.Shots,
                dare.Points
            });
        }
        else
        {
            return Ok("Unauthorized");
        }
    }
}