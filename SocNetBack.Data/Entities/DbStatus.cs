using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("statuses")]
[PrimaryKey(nameof(StatusId))]
public class DbStatus
{
    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("status_name")]
    public string StatusName { get; set; }
}