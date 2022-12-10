using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MultiTierSubscriptionExample.Models;
using MultiTierSubscriptionExample.Services;

namespace MultiTierSubscriptionExample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFeatureService _featureService;

        public Feature Feature { get; set; }
        public Plan Plan { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger,
            IFeatureService featureService)
        {
            _logger = logger;
            _featureService = featureService;
        }

        public void OnGet()
        {
            // grab the PlanId based on a user's subscription plan if you want.
            // var plan = GetByUser(User);
            var plan = PlanType.Corporate;

            Plan = _featureService.Get(plan);
            Feature = _featureService.FindFeature(AppFeature.ProjectSize, plan);

            //var createVendors = _featureService.FindFeature(AppFeature.CreateVendors, plan);
            //if (createVendors.Allowed)
            //{

            //}
        }
    }
}
