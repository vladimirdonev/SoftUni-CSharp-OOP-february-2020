namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<Irepair> Repairs { get; }
        void AddRepair(Irepair irepair);
    }
}
