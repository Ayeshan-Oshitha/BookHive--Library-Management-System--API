using System.ComponentModel.DataAnnotations;

namespace BookHive.DBClient.EntityModels
{
    public class BookCategory
    {
        [Key]
        public int CateogaryId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
