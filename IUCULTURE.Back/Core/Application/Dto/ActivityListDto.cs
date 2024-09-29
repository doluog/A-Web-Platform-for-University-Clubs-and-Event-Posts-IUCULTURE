using System.ComponentModel.DataAnnotations.Schema;

namespace IUCULTURE.Back.Core.Application.Dto
{
    public class ActivityListDto
    {
        public int Id { get; set; }
        public int ClubId { get; set; }

        public string? ClubName { get; set; }
        public string? ActivityName { get; set; }
        public DateTime? ActivityDate { get; set; }
        public string? ActivityType { get; set; }
        public string? ActivityDefinition { get; set; }
        public string? ActivityDefinitionBold { get; set; }
        public string? ActivityImage { get; set; }

    }
}
