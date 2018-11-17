using System;
using System.Runtime.Serialization;

namespace BizTalk.T4PipelineComponent.Exceptions
{
    public class T4TemplatePipelineValidationException : Exception
    {
        public T4TemplatePipelineValidationException()
        {
        }

        public T4TemplatePipelineValidationException(string message)
            : base(message)
        {
        }

        public T4TemplatePipelineValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public T4TemplatePipelineValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
