namespace Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;

        // by default return first page
        public int PageIndex {get; set;} = 1;

        private int _pageSize = 6;
        public int PageSize 
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int? BrandId {get; set;}

        public int? TypeId {get; set;}

        public string Sort {get; set;}
        //backing field?
        private string _search;

        // when search term comes in to api, conver to lower case
        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}