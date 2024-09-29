namespace IUCULTURE.Back.Core.Application.Dto
{
    public class TokenResponseDto
    {
        public TokenResponseDto(string token, DateTime expireDate)
        {
            Token = token;
            ExpireDate = expireDate;
        }

        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}
