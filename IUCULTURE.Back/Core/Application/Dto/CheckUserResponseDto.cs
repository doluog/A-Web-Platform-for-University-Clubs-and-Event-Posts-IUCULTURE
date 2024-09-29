namespace IUCULTURE.Back.Core.Application.Dto
{
    public class CheckUserResponseDto
    {

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }

        public bool IsExist { get; set; }

    }
}
