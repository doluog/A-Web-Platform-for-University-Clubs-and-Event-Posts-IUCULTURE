namespace IUCULTURE.Back.Core.Domain
{
    public class AppRole
    {
        public int Id { get; set; }

        public string? RoleName { get; set; }
        public string? Definition { get; set; }
        public List<AppUser>? AppUsers { get; set; }

      
    }



}
