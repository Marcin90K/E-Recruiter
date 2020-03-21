namespace Application.Common.Models.Address
{
    public class AddressForManipulationDTO
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int BuildingNumber { get; set; }
        public int? FlatNumber { get; set; }
        public string Zip { get; set; }
    }
}
