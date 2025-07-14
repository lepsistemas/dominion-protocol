using System;
using System.Collections.Generic;

namespace DominionProtocol.Domain.Model;

public class Nation
{
    public string Name { get; }
    public string Description { get; }
    public string Color { get; }
    public List<HistoricalPeriod> AvailablePeriods { get; }
    public NationAttributes Attributes { get; private set; }

    public Nation(
        string name,
        string description,
        string color,
        List<HistoricalPeriod> availablePeriods,
        NationAttributes attributes
    )
    {
        Name = name;
        Description = description;
        Color = color;
        AvailablePeriods = availablePeriods;
        Attributes = attributes;
    }

    public bool IsAvailableIn(HistoricalPeriod period)
    {
        return AvailablePeriods.Contains(period);
    }

    public void BoostMilitary(int amount)
    {
        Attributes = Attributes.WithMilitary(Attributes.Military + amount);
    }

    public void BoostTechnology(int amount)
    {
        Attributes = Attributes.WithTechnology(Attributes.Technology + amount);
    }

    public void BoostResources(int amount)
    {
        Attributes = Attributes.WithResources(Attributes.Resources + amount);
    }

    public void BoostDiplomacy(int amount)
    {
        Attributes = Attributes.WithDiplomacy(Attributes.Diplomacy + amount);
    }

    public void ReduceResources(int amount)
    {
        Attributes = Attributes.WithResources(Math.Max(0, Attributes.Resources - amount));
    }

    public void ReduceAllAttributes(int amount)
    {
        Attributes = new NationAttributes(
            Math.Max(0, Attributes.Military - amount),
            Math.Max(0, Attributes.Technology - amount),
            Math.Max(0, Attributes.Resources - amount),
            Math.Max(0, Attributes.Diplomacy - amount)
        );
    }

    public int GetPowerRating()
    {
        return Attributes.Military + Attributes.Technology + Attributes.Resources + Attributes.Diplomacy;
    }
}
