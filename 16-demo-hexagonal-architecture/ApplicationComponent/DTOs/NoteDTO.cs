
namespace ApplicationComponent.DTOs
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Message { get; set; }

        public string? Color { get; set; }
    }
}
