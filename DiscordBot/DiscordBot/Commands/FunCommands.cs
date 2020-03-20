using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
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


        [Command("respondmessage")]
        public async Task Respondmessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Content);

        }

        [Command("respondreaction")]
        public async Task Respondreaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var message = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(message.Result.Reactions.ToString());

        }


        




        //[Command("Start Queue")]
        //[Description ("Starts a queue for singing")]




        /*
        [RequireRoles(RoleCheckMode.All, "Moderator")]
        [Command("Ready")]
        [Description("Use this command when ready to sing, will mute all members of channel")]
        public async Task Ready(CommandContext ctx)
        {
            
            

        }
        */


    }
}
