namespace Chat.Persistence.Dtos.Messages;

public class MessageCreateDto
{
    public long SenderId { get; set; }

    public string Messages { get; set; } = String.Empty;

    public long RecipientId { get; set; }
}
