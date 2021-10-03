using System;

namespace DuckDuckGo.Application.Models
{
    public class OperationStatus
    {
        public bool Status { get; set; } = true;

        public string Message { get; set; }

        public object Model { get; set; }

        public Exception Exception { get; set; }
    }
}
