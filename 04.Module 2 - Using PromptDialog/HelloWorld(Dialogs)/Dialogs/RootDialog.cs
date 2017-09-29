using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace HelloWorld_Dialogs_.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            if(activity.Text == "OK")
            {
                PromptDialog.Confirm(context, AfterOkAsync, "Are you sure?", "Didn't get that!", promptStyle: PromptStyle.Inline);
            }
         }

        public async Task AfterOkAsync (IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;

            if(confirm)
            {
                await context.PostAsync("ok i will proceed");
            }
            else
            {
                await context.PostAsync("just neglect it");
            }
            context.Wait(MessageReceivedAsync);
        }

    }
}