using pro_events.Application.DTO.Social;
using pro_events.Application.DTO.Speakers;
using pro_events.Application.DTO.TicketLots;
using pro_events.Domain;
using System.ComponentModel.DataAnnotations;

namespace pro_events.Application.DTO.Events
{
    public class EventDto
    {
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        public DateTime EventDate { get; set; }
        [Required]
        public string Subject { get; set; }
        [Range(1, 200000)]
        public int Amount { get; set; }
        [RegularExpression(@"^.*\.(jpg|jpeg|png|gif|bmp|svg)$", ErrorMessage = "Image not accepted. Accepted types: jpg|jpeg|png|gif|bmp|svg")]
        public string? ImgUrl { get; set; }
        [Phone]
        public string? Cellphone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<TicketLotDto>? TicketLots { get; set; }
        public IEnumerable<SocialDto>? Socials { get; set; }
        public IEnumerable<SpeakerDto>? Speakers { get; set; }
    }
}
