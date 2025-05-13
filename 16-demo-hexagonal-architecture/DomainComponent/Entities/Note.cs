
namespace DomainComponent.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int ItemId { get; private set; }
        public string Message { get; private set; }

        public Note(int id, int itemId, string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("El mensaje es obligatorio.", nameof(message));
            }

            if (message.Length > 100)
            {
                throw new ArgumentException("El mensaje no puede superar los 100 caracteres.", nameof(message));
            }

            Id = id;
            ItemId = itemId;
            Message = message;
        }

        public void UpdateMessage(string newMessage)
        {
            if (string.IsNullOrWhiteSpace(newMessage))
            {
                throw new ArgumentException("El mensaje es obligatorio.", nameof(newMessage));
            }

            if (newMessage.Length > 100)
            {
                throw new ArgumentException("El mensaje no puede superar los 100 caracteres.", nameof(newMessage));
            }

            Message = newMessage;
        }
    }
}
