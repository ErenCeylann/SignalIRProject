﻿namespace SignalRWebUI.Dtos.MailDto
{
    public class CreateMailDto
    {
        public string ReceiverMail { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
    }
}
