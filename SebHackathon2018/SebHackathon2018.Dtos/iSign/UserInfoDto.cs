using System;

namespace SebHackathon2018.Dtos.iSign
{
    public class Subject
    {
        public string country { get; set; }
        public string organisation { get; set; }
        public string organisation_unit { get; set; }
        public string common_name { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string serial_number { get; set; }
    }

    public class Issuer
    {
        public string country { get; set; }
        public string organisation { get; set; }
        public string common_name { get; set; }
        public string email { get; set; }
    }

    public class Certificate
    {
        public string name { get; set; }
        public Subject subject { get; set; }
        public Issuer issuer { get; set; }
        public DateTime valid_from { get; set; }
        public DateTime valid_to { get; set; }
        public string value { get; set; }
    }

    public class UserInfoDto
    {
        public string status { get; set; }
        public string country { get; set; }
        public Certificate certificate { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public string control_code { get; set; }
        public string surname { get; set; }
    }
}