using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalk.T4PipelineComponent.Commands
{
    public class SharePointTemplateResolverCommand : ICommand, ICommandFactory
    {
        public string Execute()
        {
            throw new NotImplementedException();
        }

        public string CommandName
        {
            get { return "SharePoint"; }
        }

        public string Description
        {
            get { throw new NotImplementedException(); }
        }

        public ICommand MakeCommand(CommandParams arguments)
        {
            throw new NotImplementedException();
        }
    }
}
