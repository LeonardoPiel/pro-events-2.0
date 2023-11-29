using Microsoft.AspNetCore.Mvc;

namespace pro_events.API.Models
{
    public class DefaultActionResult : ActionResult
    {
        public string ErrorMessage { get; set; }
        public string Data { get; set; }
    }
}
