namespace MultiTierSubscriptionExample.Models;

public class PlanType : Enumeration
{
    public static readonly PlanType Basic = new(1, "Basic");
    public static readonly PlanType Professional = new(2, "Professional");
    public static readonly PlanType Corporate = new(3, "Corporate");

    private PlanType(int id, string displayName)
        : base(id, displayName) { }
}
