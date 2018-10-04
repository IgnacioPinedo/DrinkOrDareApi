using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

[Table("TB_Dare")]
public class Dare
{
    [Key]
    public int Id { get; private set; }
    public string DareText { get; set; }
    public string Description { get; set; }
    public int Shots { get; set; }
    public int Points { get; set; }
}