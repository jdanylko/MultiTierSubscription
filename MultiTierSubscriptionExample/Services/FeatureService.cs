using MultiTierSubscriptionExample.Data;
using MultiTierSubscriptionExample.Models;
using System.Collections.Generic;
using System.Linq;

namespace MultiTierSubscriptionExample.Services;

public class FeatureService : IFeatureService
{
    private readonly IFeatureDbContext _context;

    public FeatureService(IFeatureDbContext context)
    {
        _context = context;
    }

    public Feature FindFeature(AppFeature featureEnum, PlanType planId) =>
        GetFeaturesByPlanId(planId)
            .FirstOrDefault(e =>
                e.AppFeature.Value.Equals(featureEnum.Value));

    public Plan Get(PlanType planType) =>
        _context.Plans.FirstOrDefault(e => e.PlanId.Equals(planType.Value));

    private List<PlanFeature> GetFeaturesFor(PlanType planType) =>
        _context.PlanFeatures
            .Where(e => e.PlanId.Equals(planType.Value))
            .ToList();

    private string GetFeatureValue(PlanFeature feature)
    {
        return feature == null || string.IsNullOrEmpty(feature.Value)
            ? string.Empty
            : feature.Value;
    }

    private IEnumerable<Feature> GetFeaturesByPlanId(PlanType planType)
    {
        var features = GetFeaturesFor(planType);

        return Enumeration
            .GetAll<AppFeature>()
            .Select(af =>
            {
                var feature = features.FirstOrDefault(e =>
                    af.IdList.Contains(e.FeatureId));
                return new Feature
                {
                    AppFeature = af,
                    Value = GetFeatureValue(feature),
                    Allowed = feature != null
                };
            });
    }
}