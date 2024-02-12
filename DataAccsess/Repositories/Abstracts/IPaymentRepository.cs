using DataAccess.Repositories.Abstracts;
using Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Repositories.Abstracts;

public interface IPaymentRepository : IBaseRepository<Payment>
{
    ICollection<Payment> GetPaymentsByUserId(int userId);
    int GetTotalAmountByPaymentMethod(string paymentMethod);
}
