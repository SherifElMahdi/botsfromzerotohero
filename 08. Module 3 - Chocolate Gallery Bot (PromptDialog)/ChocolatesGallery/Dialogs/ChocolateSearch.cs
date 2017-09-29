using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using ChocolatesGallery.Models;
using Microsoft.Bot.Connector;

namespace ChocolatesGallery.Dialogs
{
    [Serializable]
    public class ChocolateSearch : IDialog<object>
    {
        AzureSearchService search = new AzureSearchService();
        
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("Please write the name of the chocolate you want");
            context.Wait(MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = await result;

            try
            {
                SearchResult searchResult = await search.SearchByChocolateName(message.Text);
                if (searchResult.value.Length != 0)
                {
                    HeroCard firstResultcard = new HeroCard();

                    firstResultcard.Title = searchResult.value[0].Name;
                    firstResultcard.Images = new List<CardImage>();
                    firstResultcard.Images.Add(new CardImage() { Url = searchResult.value[0].imageURL });
                    firstResultcard.Subtitle = searchResult.value[0].Flavor;

                    ConnectorClient connector = new ConnectorClient(new Uri(context.Activity.ServiceUrl));
                    
                    Activity reply = (Activity)context.Activity;
                    reply = reply.CreateReply("here's my GitHub and Twitter accounts");
                    reply.Text = "Here's the first search result";
                    reply.Attachments = new List<Attachment>();
                    reply.Attachments.Add(firstResultcard.ToAttachment());

                    await context.PostAsync(reply);
                }
                else
                {
                    await context.PostAsync($"No chocolates found");
                }
            }
            catch (Exception e)
            {
                string x = e.Message;
                
            }
            context.Done<object>(null);
        }
    }
}