using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace ChocolatesGallery.Dialogs
{
    [Serializable]
    public class ChocolatesList : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync("ChocolatesList Invoked");
            context.Done<object>(null);
        }
      

           
    }
}