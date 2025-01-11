using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("genders")]
[PrimaryKey(nameof(GenderId))]
public class DbGender
{
    [Column("gender_id")]
    public int GenderId { get; set; }
    
    [Column("gender")]
    public string GenderName { get; set; }
}