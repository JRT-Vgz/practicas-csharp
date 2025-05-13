
namespace RepositoryComponent.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; }

        public ItemModel Item { get; set; }
    }
}
