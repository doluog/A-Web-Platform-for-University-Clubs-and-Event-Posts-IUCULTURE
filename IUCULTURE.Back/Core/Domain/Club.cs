using System.ComponentModel.DataAnnotations.Schema;

namespace IUCULTURE.Back.Core.Domain
{
    public class Club
    {
        public int Id { get; set; }

        public string? ClubName { get; set; }

        public string? ClubType { get; set; }
        public string? ClubLeaderName { get; set; }
        public string? ClubDefinition { get; set; }
        public string? ClubDefinitionBold { get; set; }
        public string? ClubImage { get; set; }

        public List<Activity>? Activities { get; set; }

      
    }
}
