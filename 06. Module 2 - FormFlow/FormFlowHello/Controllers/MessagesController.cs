using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using static FormFlow.Forms.PickYourTShirtForm;
using Microsoft.Bot.Builder.FormFlow;

namespace FormFlowHello
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        /// 

        internal static IDialog<PickTShirt> MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(PickTShirt.BuildForm)).Do(async (context, order) =>
            {
                try
                {
                    var completed = await order;

                    await context.PostAsync("Just took your order");
                }
                catch (FormCanceledException<PickTShirt> e)
                {
                    string reply;

                    if(e.InnerException == null)
                    {
                        reply = $"you quit on {e.Last}";
                    }
                    else
                    {
                        reply = "Error, please try again";
                    }

                    await context.PostAsync(reply);
                }
              
            });
        }

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                await Conversation.SendAsync(activity, MakeRootDialog);

                
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