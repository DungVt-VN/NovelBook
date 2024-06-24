namespace api.Helpers
{
    public class QueryObject
    {
        public QueryObject()
        {
            NewChapter = false;
            MostChapter = false;
            Viewed = false;
            Liked = false;
            Followed = false;
            Commented = false;
            TopDate = false;
            TopWeek = false;
            TopMonth = false;
            TopAll = false;
            NewBook = false;
        }
        public bool NewChapter { get; set; }
        public bool MostChapter { get; set; }
        public bool Viewed { get; set; }
        public bool Liked { get; set; }
        public bool Followed { get; set; }
        public bool Commented { get; set; }
        public bool TopDate { get; set; }
        public bool TopWeek { get; set; }
        public bool TopMonth { get; set; }
        public bool TopAll { get; set; }
        public bool NewBook { get; set; }

        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 36;
    }
}
