using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

public class LoginController : ApiController
{
    [HttpGet]
    [Route("Login")]
    public IHttpActionResult Login()
    {
        return Ok(new
        {
            Texto = "Fabio é uma bicha louca !"
        });
    }

    [HttpPost]
    [Route("Login")]
    public IHttpActionResult Login(JObject json)
    {
        var email = json["email"];
        var nome = json["nome"];
        var senha = json["senha"];

        return Ok(new
        {
            Email = email,
            Nome = nome,
            Senha = senha
        });
    }
}