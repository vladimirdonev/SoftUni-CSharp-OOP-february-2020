namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumeration;
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
