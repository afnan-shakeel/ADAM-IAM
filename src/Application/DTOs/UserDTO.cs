namespace Application.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; } // Made optional by using nullable type
    }
}