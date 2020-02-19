using System;
using System.Collections.Generic;

namespace Euromonitor.Assessment.Domain
{
    public class Response
    {
        public Response(IEnumerable<string> preConditions)
        {
            this.PreConditions = string.Join(Environment.NewLine, preConditions) ;
            Outcome = ResponseType.ValidationFail;
        }

        public Response(int calculatedAmount)
        {
            CalculatedAmount = calculatedAmount;
            Outcome = ResponseType.Success;
        }

        public Response(Exception exception)
        {
            ExceptionMessage = exception.Message;
            Outcome = ResponseType.Exception;
        }

        public string PreConditions { get; }

        public int CalculatedAmount { get; }

        public ResponseType Outcome { get; }

        public string ExceptionMessage { get; }
    }

    public enum ResponseType
    {
        Exception = 0,
        Success = 1,
        ValidationFail = 2
    }
}
