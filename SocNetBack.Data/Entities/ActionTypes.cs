using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SocNetBack.Domain.Models;

[Table("actionTypes")]
public class ActionTypes
{
    public ActionTypes(int actionTypeId, string action)
    {
        ActionTypeId = actionTypeId;
        Action = action;
    }

    [Column("action_type_id")]
    [Key]
    public int ActionTypeId { get; set; }
    
    [Column("action")]
    [MaxLength(30)]
    public string Action { get; set; }
}