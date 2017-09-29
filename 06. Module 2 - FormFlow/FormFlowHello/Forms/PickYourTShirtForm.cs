using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;



namespace FormFlow.Forms
{
    public class PickYourTShirtForm
    {
    
        public enum SizeOptions { Small, Medium, Large };

        public enum ColorOptions { Blue, Red, Black, Green, Purple };
        
        [Serializable]
        public class PickTShirt
        {
            [Prompt ("Would you please select {&} for your t-shirt? {||}")]
            public SizeOptions? Size;

            [Optional]
            public ColorOptions? Color;
          
            public static IForm<PickTShirt> BuildForm()
            {
                return new FormBuilder<PickTShirt>()
                        .Message("Welcome to the simple pick your t-shirt bot!")
                        .Build();
            }
        };
    }
}