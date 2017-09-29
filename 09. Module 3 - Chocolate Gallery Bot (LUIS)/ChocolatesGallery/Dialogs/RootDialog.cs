using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading;
using ChocolatesGallery.Models;

namespace ChocolatesGallery.Dialogs
{
    [LuisModel("YOUR LUIS APP ID GOES HERE", "YOUR AZURE SUBSRIPTION KEY GOES HERE")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        AzureSearchService search = new AzureSearchService();

        [LuisIntent("")]
        [LuisIntent("None")]
        private async Task NoIntentReceivedAsync(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("No Intent");
        }

        [LuisIntent("SearchChocolates")]
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var message = await activity;

            EntityRecommendation lindtEntity;

            if (result.TryFindEntity("lindt", out lindtEntity))
            {
                lindtEntity.Type = "lindt";
            }
            context.Call(new ChocolateSearch(lindtEntity.Type), this.ResumeAfterChocolatesList);
        }

        private Task ResumeAfterChocolatesLists(IDialogContext context, IAwaitable<object> result)
        {
            throw new NotImplementedException();
        }

        [LuisIntent("ShowChocolates")]
        private async Task ShowChocolatesAsync(IDialogContext context, LuisResult result)
        {
            context.Call(new ChocolatesList(), this.ResumeAfterChocolatesList);
        }

        private async Task ResumeAfterChocolatesList(IDialogContext context, IAwaitable<object> result)
        {
            await context.PostAsync("just removed the second dialog from the dialogs stack");
        }

        

 

   
    }
}