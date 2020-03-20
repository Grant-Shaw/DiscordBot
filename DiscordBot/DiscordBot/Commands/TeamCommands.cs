using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class TeamCommands : BaseCommandModule
    {

        [Command("StartQueue")]
        [Description("This starts a kind of poll which asks the users of the channel if they would like to start a queue")]
        public async Task StartQueue(CommandContext ctx)
        {

            var joinEmbed = new DiscordEmbedBuilder
            {
                Title = "Would you like to start a queue?",
                ThumbnailUrl = ctx.Client.CurrentUser.AvatarUrl,
                Color = DiscordColor.Green,

            };

            var joinMessage = await ctx.Channel.SendMessageAsync(embed: joinEmbed).ConfigureAwait(false);

            var thumbsUpEmoji = DiscordEmoji.FromName(ctx.Client, ":+1:");
            var thumbsDownEmoji = DiscordEmoji.FromName(ctx.Client, ":-1:");

                await joinMessage.CreateReactionAsync(thumbsUpEmoji).ConfigureAwait(false);
            await joinMessage.CreateReactionAsync(thumbsDownEmoji).ConfigureAwait(false);

            var interactivity = ctx.Client.GetInteractivity();

           var reactionResult =  await interactivity.WaitForReactionAsync(x => x.Message == joinMessage && x.User == ctx.User &&
                (x.Emoji == thumbsUpEmoji || x.Emoji == thumbsDownEmoji)).ConfigureAwait(false);

            

            if (reactionResult.Result.Emoji == thumbsUpEmoji)
            {
                var role = ctx.Guild.GetRole(690406751958204426);
                await ctx.Member.GrantRoleAsync(role, "Server Muted");
                await ctx.Channel.SendMessageAsync("Muted role assigned").ConfigureAwait(false);


            }

            await joinMessage.DeleteAsync().ConfigureAwait(false);



        }




    }
}
