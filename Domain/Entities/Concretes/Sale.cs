using Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class Sale : BaseEntity
{
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }

    public DateTime SaleDate { get; set; }
    public int SalePrice { get; set; }
}
