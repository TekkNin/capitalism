using System;
using System.Collections;
using System.Collections.Generic;

namespace Capitalism.Logic.Types
{
    public class ActionResults : IEnumerable<ActionResult>
    {
        private IList<ActionResult> _actionResults = new List<ActionResult>();        

        public ActionResults(ActionResult actionResult)
        {
            _actionResults.Add(actionResult);
        }

        public void AddResult(ActionResult actionResult)
        {
            _actionResults.Add(actionResult);
        }

        public static ActionResults Success(string message = null) => new ActionResults(ActionResult.Success(message));
        public static ActionResults Failed(string message) => new ActionResults(ActionResult.Failed(message));

        public IEnumerator<ActionResult> GetEnumerator()
        {
            foreach (var actionResult in _actionResults)
                yield return actionResult;
        }

        IEnumerator IEnumerable.GetEnumerator() => _actionResults.GetEnumerator();
    }

    public class ActionResult
    {
        public ActionResultType ResultType { get; private set; }
        public string Message { get; private set; }
        public bool HasMessage => !String.IsNullOrEmpty(this.Message);

        private ActionResult(ActionResultType resultType, string message = null)
        {
            this.ResultType = resultType;
            this.Message = message;
        }

        public static ActionResult Success() => new ActionResult(ActionResultType.Success);
        public static ActionResult Info(string message) => new ActionResult(ActionResultType.Info, message);
        public static ActionResult Success(string message) => new ActionResult(ActionResultType.Success, message);
        public static ActionResult Warning(string message) => new ActionResult(ActionResultType.Warning, message);
        public static ActionResult Failed(string message) => new ActionResult(ActionResultType.Error, message);

    }

    public enum ActionResultType
    {
        UNDEFINED,
        Info,
        Success,
        Warning,
        Error
    }
}
