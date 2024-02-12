using Domain.Entities.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Domain.Entities.Concretes;

public class Car : BaseEntity
{
    public int TotalPrice { get;  set; }
    public string? Color { get; set; }
    public string Model { get; set; }
    public string? Wheel { get; set; }
    public string? WheelColor { get; set; }
    public string? InteriorLeather { get; set; }
    public string? Seats { get; set; }
    public bool LightsAndVision { get; set; }
    public bool ExteriorDecalsAndLogos { get; set; }
    public bool ExteriorPackages { get; set; }
    public bool AssistanceSystems { get; set; }
    public bool InteriorComfort { get; set; }
    public bool AudioAndCommunication { get; set; }

    public int UserId { get; set; }
    public virtual User User { get; set; }
}