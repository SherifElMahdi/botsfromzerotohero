using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Cards
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return

                Activity reply = activity.CreateReply("here's my GitHub and Twitter accounts");

                reply.AttachmentLayout = AttachmentLayoutTypes.Carousel;
                reply.Attachments = new List<Attachment>();

                CardAction _GitHubButton= new CardAction("openUrl","My GitHub Account", null, "https://github.com/sherifElMahdi");
                CardAction _TwitterButton = new CardAction("openUrl", "My Twitter Account", null, "https://twitter.com/_SherifElMahdi");
                CardImage _GitHubLogo = new CardImage("https://assets-cdn.github.com/images/modules/logos_page/Octocat.png");
                CardImage _TwitterLogo = new CardImage("http://3.bp.blogspot.com/-NxouMmz2bOY/T8_ac97cesI/AAAAAAAAGg0/e3vY1_bdnbE/s1600/Twitter+logo+2012.png");


                HeroCard githubCard = new HeroCard();

                githubCard.Title = "My GitHub Account ";
                githubCard.Subtitle = "using Hero Cards";
                githubCard.Buttons = new List<CardAction>();
                githubCard.Images = new List<CardImage>();

                githubCard.Buttons.Add(_GitHubButton);
                githubCard.Images.Add(_GitHubLogo);

                ThumbnailCard twitterCard = new ThumbnailCard();

                twitterCard.Title = "My Twitter Account ";
                twitterCard.Subtitle = "using Thumbnail Cards";
                twitterCard.Buttons = new List<CardAction>();
                twitterCard.Images = new List<CardImage>();

                twitterCard.Buttons.Add(_TwitterButton);
                twitterCard.Images.Add(_TwitterLogo);



                reply.Attachments.Add(githubCard.ToAttachment());
                reply.Attachments.Add(twitterCard.ToAttachment());


                await connector.Conversations.ReplyToActivityAsync(reply);

           
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}