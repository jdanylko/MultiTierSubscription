using MultiTierSubscriptionExample.Models;

namespace MultiTierSubscriptionExample.Services;

public interface IFeatureService
{
    Plan Get(PlanType planType);
    Feature FindFeature(AppFeature appFeature, PlanType planType);
}