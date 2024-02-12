using Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class Payment : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; }

    public int Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public string PaymentMethod { get; set; }
    public string TransactionId { get; set; }
}
