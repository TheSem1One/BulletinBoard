namespace BulletinBoard.Application.DTO.Bulletin
{
    public class BulletinGetAllDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
