namespace MultiTierSubscriptionExample.Models;

public class AppFeature : Enumeration
{
    public readonly int[] IdList;
    public readonly bool ZeroAsUnlimited;

    public static readonly AppFeature ProjectSize = new(0, "Project Size", new[] { 1, 2, 3 }, true);
    public static readonly AppFeature CreateVendors = new(1, "Can Create Vendors", new[] { 4, 5 });
    public static readonly AppFeature AutoSendEmailsOnUpdates = new(2, "Auto-Send Emails on Update", new[] { 6 });

    private AppFeature(int id, string displayName, int[] identifiers, bool zeroAsUnlimited = false)
        : base(id, displayName)
    {
        IdList = identifiers;
        ZeroAsUnlimited = zeroAsUnlimited;
    }
}