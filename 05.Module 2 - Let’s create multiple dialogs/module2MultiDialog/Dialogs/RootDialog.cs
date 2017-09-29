using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace module2MultiDialog.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            await context.PostAsync("Hey there I'm Mr bot i have a question for you ");
            context.Call(new CourseDialog(), this.CourseDialogresumeafter);
        }

        private async Task CourseDialogresumeafter(IDialogContext context, IAwaitable<String> result)
        {
            try
            {
                context.Call(new NextModule(), this.NextModuleResumeafter);
            }
            catch
            {
                await context.PostAsync("Sorry i dont understand that ");
            }
        }

        private async Task NextModuleResumeafter(IDialogContext context, IAwaitable<String> result)
        {
            await context.PostAsync("Great you have reached end of the second dialog ");        
        }
    }
}
