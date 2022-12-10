using Microsoft.EntityFrameworkCore;
using MultiTierSubscriptionExample.Models;

namespace MultiTierSubscriptionExample.Data
{
    public interface IFeatureDbContext
    {
        DbSet<Plan> Plans { get; set; }
        DbSet<PlanFeature> PlanFeatures { get; set; }
    }
}
