using System;

namespace FairyNails.Ressources
{
    /// <summary>
    /// Class for message passed at a view
    /// MessageType is Bootstrap alert- class like success or danger
    /// </summary>
    public class ViewMessage
    {
        public string MessageType { get; set; }
        public string Content { get; set; }
    }
}
