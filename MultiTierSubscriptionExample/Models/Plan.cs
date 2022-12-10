using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MultiTierSubscriptionExample.Models
{
    public class Plan
    {
        [Key]
        public int PlanId { get; set; }
        public string Title { get; set; }
        public decimal PricePerMonth { get; set; }
        public decimal PricePerYear { get; set; }

        public virtual ICollection<PlanFeature> Features { get; set; }
    }
}