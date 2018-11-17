using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalk.T4PipelineComponent.Commands
{
    public interface ICommand
    {
        string Execute();
        //bool Validate(string arguments);
    }
}
