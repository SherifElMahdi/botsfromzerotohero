using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace module2MultiDialog.Dialogs
{
    [Serializable]
    public class NextModule : IDialog<string>
    {
            public async Task StartAsync(IDialogContext context)
            {
                await context.PostAsync(" Will you watch our next module ?");
                context.Wait(this.MessageReceivedAsync);
            }
            private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
            {
                var message = await result;

                if (message.Text.Contains("yes"))
                {
                    await context.PostAsync("Awesome well see you there ");
                    context.Done(message.Text);
                }
                else
                {
                    await context.PostAsync("We hope to see you there one day ");
                    context.Done(message);
               }
            }
    }
}