using DataAccess.Contexts;
using DataAccess.Repositories.Concretes;
using Domain.Entities.Concretes;
using DataAccsess.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace DataAccess.Repositories.Concretes;

public class InsurancePolicyRepository<T> : BaseRepository<InsurancePolicy>, IInsurancePolicyRepository
{
    public ICollection<InsurancePolicy> GetAllInsurancePolicies()
    {
        return _context.InsurancePolicies.ToList();
    }
    public int CalculateTotalPremium(DateTime startDate, DateTime endDate)
    {
        return _context.InsurancePolicies
            .Where(p => p.StartDate >= startDate && p.EndDate <= endDate)
            .Sum(p => p.Premium);
    }
}
