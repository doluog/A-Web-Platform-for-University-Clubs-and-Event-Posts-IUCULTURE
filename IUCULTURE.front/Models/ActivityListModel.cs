

using IUCULTURE.Back.Core.Application.Dto;
using IUCULTURE.Back.Core.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace IUCULTURE.front.Models
{
    public class ActivityListModel
    {

        public int Id { get; set; }
        public int ClubId { get; set; }
        public string? ClubName { get; set; }
        public string? ActivityName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ActivityDate { get; set; }
        public string? ActivityType { get; set; }
        public string? ActivityDefinition { get; set; }
        public string? ActivityDefinitionBold { get; set; }
        public string? ActivityImage { get; set; }

        //public string? ClubName { get; set; }

        internal static object Find(object ıd)
        {
            throw new NotImplementedException();
        }

        
    }
}
