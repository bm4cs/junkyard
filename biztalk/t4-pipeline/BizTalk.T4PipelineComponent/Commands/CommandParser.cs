using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizTalk.T4PipelineComponent.Commands
{
    public class CommandParser
    {
        private readonly IEnumerable<ICommandFactory> availableCommands;

        //public CommandParser() : this(new ICommandFactory[]
        //    {
        //        new FileTemplateResolverCommand(),
        //        new SharePointTemplateResolverCommand()
        //    })
        //{
        //}

        public CommandParser(IEnumerable<ICommandFactory> availableCommands)
        {
            this.availableCommands = availableCommands;
        }

        internal ICommand ParseCommand(string requestedCommandName, CommandParams arguments)
        {
            var command = FindCommand(requestedCommandName);

            if (null == command)
                return new NotFoundCommand { Name = requestedCommandName };

            return command.MakeCommand(arguments);
        }

        ICommandFactory FindCommand(string commandName)
        {
            return availableCommands.FirstOrDefault(cmd => cmd.CommandName == commandName);
        }
    }
}
