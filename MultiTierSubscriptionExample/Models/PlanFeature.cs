using System.ComponentModel.DataAnnotations;

namespace MultiTierSubscriptionExample.Models
{
    public class PlanFeature
    {
        [Key]
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
    }
}