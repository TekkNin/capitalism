using System.Collections.Generic;
using System.Linq;

namespace Capitalism.Logic.Types
{
    public class WorkResult
    {
        public bool Succeeded { get; private set; }
        public IEnumerable<string> Messages { get; private set; }
        public bool HasMessages => (this.Messages?.Count() ?? 0) > 0;

        private WorkResult(bool succeeded, IEnumerable<string> messages = null)
        {
            this.Succeeded = succeeded;
            if (messages != null)
                this.Messages = messages;
            else
                this.Messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            ((List<string>)this.Messages).Add(message);
        }

        public static WorkResult Empty => new WorkResult(false);
        public static WorkResult Success => new WorkResult(true);
        public static WorkResult Failed(string message) => new WorkResult(false, new List<string> { message });
        public static WorkResult Failed(IEnumerable<string> messages) => new WorkResult(false, messages);
    }
}
