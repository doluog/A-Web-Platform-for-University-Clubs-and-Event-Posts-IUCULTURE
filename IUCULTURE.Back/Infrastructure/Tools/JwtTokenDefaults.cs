namespace IUCULTURE.Back.Infrastructure.Tools
{
    public class JwtTokenDefaults
    {
        /*
           ValidAudience = "http://localhost",
            ValidIssuer = "http://localhost",
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("iuculture.w0w.12")),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        */

        public const string ValidAudience = "http://localhost";
        public const string ValidIssuer = "http://localhost";
        public const string Key = "iuculture.w0w.12";
        public const int Expire = 5;
    }
}
