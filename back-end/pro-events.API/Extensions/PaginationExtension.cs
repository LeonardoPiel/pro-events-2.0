
using System.Text.Json;

namespace pro_events.API.Extensions
{
    public static class PaginationExtension
    {
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var obj = new
            {
                currentPage = currentPage,
                itemsPerPage = itemsPerPage,
                totalItems = totalItems,
                totalPages = totalPages
            };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(obj, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
