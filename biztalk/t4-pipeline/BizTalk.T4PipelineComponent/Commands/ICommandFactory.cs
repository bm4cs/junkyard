using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalk.T4PipelineComponent.Commands
{
    public interface ICommandFactory
    {
        string CommandName { get; }
        string Description { get; }

        ICommand MakeCommand(CommandParams arguments);
    }
}
