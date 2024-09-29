using System.ComponentModel.DataAnnotations.Schema;

namespace IUCULTURE.Back.Core.Application.Dto
{
    public class ClubListDto
    {

        public int Id { get; set; }

        public string? ClubName { get; set; }
        public string? ClubLeaderName { get; set; }

        public string? ClubType { get; set; }
        public string? ClubDefinition { get; set; }
        public string? ClubDefinitionBold { get; set; }
        public string? ClubImage { get; set; }


    }
}
