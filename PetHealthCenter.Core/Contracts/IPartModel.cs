namespace PetHealthCenter.Core.Contracts
{
    public interface IPartModel
    {
        public string Name { get; }

        public string Manufacturer { get; }

        public string OriginalMpn { get; }
    }
}
