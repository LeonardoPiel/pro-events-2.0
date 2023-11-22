using pro_events.Application.DTO.Events;
using pro_events.Application.DTO.Speakers;

namespace pro_events.Application.DTO.Social
{
    public class SocialDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public int? SpeakerId { get; set; }
        public SpeakerDto? Speaker { get; set; }
        public int? EventId { get; set; }
        public EventDto? Event { get; set; }
    }
}
