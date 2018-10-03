using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("TB_UserTemp")]
public class UserTemp
{
    [Key]
    public int Id { get; private set; }
    public string DisplayName { get; set; }
    public DateTime ExpireDate { get; set; }
}