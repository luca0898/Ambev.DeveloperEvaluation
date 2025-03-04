namespace Ambev.DeveloperEvaluation.Domain.Models.UserAggregate.Common
{
    public class NameDto
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }

    public class AddressDto
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int Number { get; set; }
        public string Zipcode { get; set; } = string.Empty;
        public GeolocationDto Geolocation { get; set; } = new GeolocationDto();
    }

    public class GeolocationDto
    {
        public string Lat { get; set; } = string.Empty;
        public string Long { get; set; } = string.Empty;
    }
}
