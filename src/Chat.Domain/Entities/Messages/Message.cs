namespace Chat.Domain.Entities.Messages;

public class Message : Auditable
{
    public long SenderId { get; set; }

    public string Messages { get; set; } = String.Empty;

    public long RecipientId { get; set; }
}
