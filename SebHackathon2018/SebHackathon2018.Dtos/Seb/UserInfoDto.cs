namespace SebHackathon2018.Dtos.Seb
{
    public class Address
    {
        public string line_1 { get; set; }
        public object line_2 { get; set; }
        public object line_3 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }

    public class UserInfoDto
    {
        public string customerId { get; set; }
        public string customerName { get; set; }
        public string registrationCode { get; set; }
        public string registrationCodeCountry { get; set; }
        public string citizenship { get; set; }
        public Address address { get; set; }
        public string email { get; set; }
        public string homePhone { get; set; }
        public string mobilePhone { get; set; }
        public string workPhone { get; set; }
        public string language { get; set; }
        public string pictureBase64 { get; set; }
    }
}