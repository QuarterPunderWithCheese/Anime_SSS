namespace DomainServices.DTO
{
    public class TryChangeUserPasswordDto
    {
        public int UserId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}