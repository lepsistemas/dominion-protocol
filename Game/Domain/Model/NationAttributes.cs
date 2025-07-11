namespace DominionProtocol.Domain.Model;

public class NationAttributes
{
    public int Military { get; }
    public int Technology { get; }
    public int Resources { get; }
    public int Diplomacy { get; }

    public NationAttributes(int military, int technology, int resources, int diplomacy)
    {
        Military = military;
        Technology = technology;
        Resources = resources;
        Diplomacy = diplomacy;
    }

    public NationAttributes WithMilitary(int newMilitary) =>
        new NationAttributes(newMilitary, Technology, Resources, Diplomacy);

    public NationAttributes WithTechnology(int newTechnology) =>
        new NationAttributes(Military, newTechnology, Resources, Diplomacy);

    public NationAttributes WithResources(int newResources) =>
        new NationAttributes(Military, Technology, newResources, Diplomacy);

    public NationAttributes WithDiplomacy(int newDiplomacy) =>
        new NationAttributes(Military, Technology, Resources, newDiplomacy);
}
