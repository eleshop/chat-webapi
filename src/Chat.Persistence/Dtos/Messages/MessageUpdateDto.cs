namespace Chat.Persistence.Dtos.Messages;

public class MessageUpdateDto
{
    public long SenderId { get; set; }

    public string Messages { get; set; } = String.Empty;
}
