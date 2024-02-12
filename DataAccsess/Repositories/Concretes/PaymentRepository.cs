using DataAccess.Contexts;
using DataAccess.Repositories.Concretes;
using Domain.Entities.Concretes;
using DataAccsess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccess.Repositories.Concretes;

public class PaymentRepository<T> : BaseRepository<Payment>, IPaymentRepository
{
    public ICollection<Payment> GetPaymentsByUserId(int userId)
    {
        return _context.Payments.Where(p => p.UserId == userId).ToList();
    }
    public int GetTotalAmountByPaymentMethod(string paymentMethod)
    {
        return _context.Payments.Where(p => p.PaymentMethod == paymentMethod).Sum(p => p.Amount);
    }
}
