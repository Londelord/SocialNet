using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Data.Entities;

[Table("actionTypes")]
[PrimaryKey(nameof(ActionTypeId))]
public class DbActionTypes
{
    [Column("action_type_id")]
    public int ActionTypeId { get; set; }
    
    [Column("action")]
    public string Action { get; set; }
}