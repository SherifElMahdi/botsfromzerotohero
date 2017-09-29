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
    public class CourseDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Do you like this Course ?");
            context.Wait(this.MessageReceivedAsync);
        }
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            if (message.Text.Contains("yes"))
            {
                await context.PostAsync("Awesome were glad you do ");
                context.Done(message.Text);
            }
            else
            {
                await context.PostAsync("sorry we only take yes as an answer ");
                context.Done(message.Text);
            }
        }
    }
}