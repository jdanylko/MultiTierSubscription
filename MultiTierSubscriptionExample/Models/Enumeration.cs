using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MultiTierSubscriptionExample.Models;

public class Enumeration : IComparable
{
    private readonly int _value;

    protected Enumeration(int value, string displayName)
    {
        _value = value;
        DisplayName = displayName;
    }

    public int Value => _value;
    public string DisplayName { get; }

    public override string ToString()
    {
        return DisplayName;
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var fields = typeof(T).GetFields(
            BindingFlags.Public
            | BindingFlags.Static
            | BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    public override bool Equals(object obj)
    {
        if (obj is not Enumeration otherValue)
        {
            return false;
        }

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = _value.Equals(otherValue.Value);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        var absoluteDifference = Math.Abs(firstValue.Value - secondValue.Value);
        return absoluteDifference;
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        return GetAll<T>().Single(u => u.Value == value);
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        return GetAll<T>().Single(u => u.DisplayName == displayName);
    }

    public int CompareTo(object other)
    {
        return Value.CompareTo(((Enumeration)other).Value);
    }
}