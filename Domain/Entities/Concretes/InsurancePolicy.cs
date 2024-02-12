using Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class InsurancePolicy : BaseEntity
{
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    public string InsuranceCompany { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Premium { get; set; }
}
