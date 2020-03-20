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
        public async Task YouSmell (CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("No you do!").ConfigureAwait(false);

        }
        



    }
}
