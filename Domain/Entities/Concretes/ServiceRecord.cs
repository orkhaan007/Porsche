using Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class ServiceRecord : BaseEntity
{
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    public DateTime ServiceDate { get; set; }
    public string ServiceType { get; set; }
    public string Description { get; set; }
    public int Cost { get; set; }
}