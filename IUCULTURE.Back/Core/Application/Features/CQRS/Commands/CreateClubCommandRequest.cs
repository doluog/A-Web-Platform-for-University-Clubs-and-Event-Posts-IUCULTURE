using MediatR;

namespace IUCULTURE.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateClubCommandRequest : IRequest<Unit>
    {

        public string? ClubName { get; set; }
        public string? ClubLeaderName { get; set; }

        public string? ClubType { get; set; }
        public string? ClubDefinition { get; set; }
        public string? ClubDefinitionBold { get; set; }
        public string? ClubImage { get; set; }

    }
    
}
