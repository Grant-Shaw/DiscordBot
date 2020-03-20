using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    class FunCommands : BaseCommandModule
    {
        [Command ("YouSmell")]
        [Description ("Tells you that YOU SMELL")]
        public async Task YouSmell (CommandContext ctx)
        {
           
            await ctx.Channel.SendMessageAsync("No you do!").ConfigureAwait(false);

        }

        [Command ("add")]
        [Description("Adds two numbers")]
        public async Task Add(CommandContext ctx, [Description ("The first number")] int numberOne, [Description("The second number")] int numberTwo)
        {
            await ctx.Channel
                .SendMessageAsync((numberOne + numberTwo).ToString())
                .ConfigureAwait(false);

        }




    }
}
