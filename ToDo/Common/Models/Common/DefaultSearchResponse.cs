using Common.Models.Enums;

namespace Common.Models.Common
{
    public class DefaultSearchResponse
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 10;


        public string SearchText { get; set; }

        public string SearchFields { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string OrderBy { get; set; } = "CreatedAt";


        public OrderingDirection Direction { get; set; } = OrderingDirection.Desc;


        public DefaultSearchResponse()
        {
        }

        public DefaultSearchResponse(string searchText, string searchFields)
        {
            SearchText = searchText;
            SearchFields = searchFields;
        }

        public string[] GetFilteredFields()
        {
            return SearchFields.Split(",");
        }

        public int GetSkip()
        {
            return PageIndex * PageSize;
        }

        public int GetTake()
        {
            return PageSize;
        }
    }
}
