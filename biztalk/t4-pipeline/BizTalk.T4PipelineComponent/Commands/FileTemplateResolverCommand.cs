using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BizTalk.T4PipelineComponent.Commands
{
    public class FileTemplateResolverCommand : ICommand, ICommandFactory
    {
        public CommandParams Parameters { get; set; }

        public string Execute()
        {
            return File.ReadAllText(Parameters.TemplateLocation);
        }

        public string CommandName
        {
            get { return "File"; }
        }

        public string Description
        {
            get { return "A simple file system based template resolver."; }
        }

        public ICommand MakeCommand(CommandParams arguments)
        {
            return new FileTemplateResolverCommand {Parameters = arguments};
        }
    }
}
