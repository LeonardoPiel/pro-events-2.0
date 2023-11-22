using pro_events.Application.DTO.Social;
using pro_events.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.DTO.Speakers
{
    public class SpeakerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? ImgUrl { get; set; }
        public string? Description { get; set; }
        public IEnumerable<SocialDto>? Socials { get; set; }
        public IEnumerable<SpeakerDto>? Speakers{ get; set; }
    }
}
