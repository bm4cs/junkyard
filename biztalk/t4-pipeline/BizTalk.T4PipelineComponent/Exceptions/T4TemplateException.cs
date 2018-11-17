using System;
using System.Runtime.Serialization;

namespace BizTalk.T4PipelineComponent
{
    public class T4TemplateException : Exception
    {
        public T4TemplateException()
        {
        }

        public T4TemplateException(string message) : base(message)
        {
        }

        public T4TemplateException(string message, Exception inner)
            : base(message, inner)
        {
        }

        public T4TemplateException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public void AddError(string error)
        {            
            this.Data.Add("CompilationError" + this.Data.Count, error);
        }
    }
}
