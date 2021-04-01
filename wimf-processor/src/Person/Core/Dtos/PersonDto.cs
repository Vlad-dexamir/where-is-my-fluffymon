namespace PersonApi
{
    public class PersonDto
    {
#nullable disable
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public PersonLocation Location { get; set; }
        public bool IsAdmin { get; set; }
#nullable enable
        public string? PhoneNumber { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
