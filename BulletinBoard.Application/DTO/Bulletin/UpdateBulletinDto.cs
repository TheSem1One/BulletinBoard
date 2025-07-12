namespace BulletinBoard.Application.DTO.Bulletin
{
    public class UpdateBulletinDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
