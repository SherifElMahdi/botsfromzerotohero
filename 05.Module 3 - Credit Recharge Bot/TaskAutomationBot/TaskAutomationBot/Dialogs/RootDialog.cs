using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace TaskAutomationBot.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {

        private const string RechargeOption = "Recharge Credit";
        private const string ShowBalanceOption = "Show your current Balance";

        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            PromptDialog.Choice(
                 context,
                 this.AfterChoiceSelected,
                 new[] { RechargeOption, ShowBalanceOption },
                 "What do you want to do today?",
                 "Sorry, i didn't get that!",
                 attempts: 2);

        }

        private async Task AfterChoiceSelected(IDialogContext context, IAwaitable<string> result)
        {
            try
            {
                var selection = await result;

                switch (selection)
                {
                    case RechargeOption:

                        //TODO redirect the user to the Recharge Dialog
                        break;

                    case ShowBalanceOption:
                        //TODO redirect the user to the ShowBalance Dialog
                        break;
                }
            }
            catch (TooManyAttemptsException)
            {
                await this.StartAsync(context);
            }
        }

    }
}