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
        public string lindtEntity;

        public ChocolateSearch(string lindtEntity)
        {
            this.lindtEntity = lindtEntity;
        }
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("let's start searching");

            SearchResult searchResult = await search.SearchByChocolateName(this.lindtEntity);
            if (searchResult.value.Length != 0)
            {
                HeroCard firstResultcard = new HeroCard();

                firstResultcard.Title = searchResult.value[0].Name;
                firstResultcard.Images = new List<CardImage>();
                firstResultcard.Images.Add(new CardImage() { Url = searchResult.value[0].imageURL });
                firstResultcard.Subtitle = searchResult.value[0].Flavor;
                
                ConnectorClient connector = new ConnectorClient(new Uri(context.Activity.ServiceUrl));
                
                Activity reply = (Activity)context.Activity;
                reply=  reply.CreateReply("here's my GitHub and Twitter accounts");
                reply.Text = "Here's the first search result";
                reply.Attachments = new List<Attachment>();
                reply.Attachments.Add(firstResultcard.ToAttachment());
                
                await context.PostAsync(reply);
            }
            else
            {
                await context.PostAsync($"No chocolates found");
            }

            context.Done<object>(null);
        }
    }
}