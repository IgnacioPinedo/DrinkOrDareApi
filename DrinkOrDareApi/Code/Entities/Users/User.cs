using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("TB_User")]
public class User
{
    [Key]
    public int Id { get; private set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string DisplayName { get; set; }
    public bool IsUser { get; set; }
    public DateTime ExpireDate { get; set; }
}