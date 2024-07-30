namespace DeliveryChargeAPI.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string? StreetAddress { get; set; }
        public double City { get; set; }
        public double State { get; set; }
        public double PostalCode { get; set; }
        public double Country { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
