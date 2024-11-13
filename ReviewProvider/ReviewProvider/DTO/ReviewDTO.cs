namespace ReviewProvider.DTO
{
    public class ReviewDTO
    {
        public int ReviewID { get; set; }
        public string? ReviewDescription { get; set; }
        public int Rating { get; set; }
        public string? Status { get; set; }
        public int UserID { get; set; } 
        public int ProductID { get; set; } 
    }
}
