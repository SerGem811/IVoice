using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IVoice.Models.Common
{
    public enum TMessage
    {
        TRUE,
        FALSE
    }
    public class Message
    {
        public string Text { get; set; }
        public string Type { get; set; }

        public Message() { }

        public Message(TMessage TMessage)
        {
            Text = TMessage.ToString();
            if (TMessage == TMessage.TRUE)
                Type = "alert";
            else Type = "danger";
        }
        public Message(string msg)
        {
            Type = "alert";
            Text = msg;
        }
        public Message(Exception ex)
        {
            Text = ex.Message;

            Exception exInner = ex.InnerException;
            while (exInner != null)
            {
                Text += exInner.Message.Replace("\"", "").Replace("'", "");
                exInner = exInner.InnerException;
            }

            Type = "danger";
        }
    }

}