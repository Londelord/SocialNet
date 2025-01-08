using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocNetBack.Domain.Models;

[Table("statuses")]
public class Status
{
    public Status(int statusId, string statusName)
    {
        StatusId = statusId;
        StatusName = statusName;
    }

    [Column("status_id")]
    public int StatusId { get; set; }
    
    [Column("status_name")]
    [MaxLength(20)]
    public string StatusName { get; set; }
}