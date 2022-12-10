namespace MultiTierSubscriptionExample.Models;

public class Feature
{
    public AppFeature AppFeature { get; set; }
    public string Value { get; set; }
    public bool Allowed { get; set; }

    public int AsInt => int.TryParse(Value, out var result)
        ? result
        : 0;

    public bool ZeroAsUnlimited =>
        AppFeature.ZeroAsUnlimited
        && Value == "0"
        && AsInt == 0;
}