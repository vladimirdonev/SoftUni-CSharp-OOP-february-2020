namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enumeration;
    public interface IMission
    {
        string CodeName { get; }
        State State { get;  set; }
    }
}
