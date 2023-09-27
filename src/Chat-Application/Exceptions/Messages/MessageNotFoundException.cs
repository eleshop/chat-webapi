namespace Chat.Application.Exceptions.Messages;

public class MessageNotFoundException : NotFoundException
{
    public MessageNotFoundException()
    {
        this.TitleMessage = "Message not found!";
    }
}
