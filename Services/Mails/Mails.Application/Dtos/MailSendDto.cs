﻿namespace Mails.Application.Dtos
{
    public class MailSendDto
    {
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
