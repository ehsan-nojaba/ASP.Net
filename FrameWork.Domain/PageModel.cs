namespace FrameWork.Domain
{
    public class PageModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int RecordCount { get; set; }
    }
}