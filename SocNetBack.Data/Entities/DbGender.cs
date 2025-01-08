using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("genders")]
[PrimaryKey(nameof(GenderId))]
public class DbGender
{
    public DbGender(int genderId, string genderName)
    {
        GenderId = genderId;
        GenderName = genderName;
    }

    [Column("gender_id")]
    public int GenderId { get; set; }
    
    [Column("gender")]
    [MaxLength(20)]
    public string GenderName { get; set; }
}