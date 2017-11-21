# Developing Intelligent Bots from Zero to Hero
This repository contains all the code samples of "Developing Intelligent Bots from Zero to Hero" channel9/MVA course.

**Watch the course:**  [https://aka.ms/botszeroheromva](https://aka.ms/botszeroheromva)

**Course Blog Post:** [https://aka.ms/botszerohero](https://aka.ms/botszerohero)

**Slide Decks:** [https://aka.ms/botdevslidedecks](https://aka.ms/botdevslidedecks)

**Prerequisites** 
---------------------------------------------------------------------------------------------------
- [Visual Studio 2015 or higher](https://www.visualstudio.com/downloads/ "Visual Studio 2015 or higher")
- [Bot Project Template for Visual Studio](http://aka.ms/bf-bc-vstemplate)
- [Bot Framework Channel Emulator](http://emulator.botframework.com/ "Bot Framework Channel Emulator")
- [Bot Builder SDK for .NET](https://github.com/Microsoft/BotBuilder "Bot Builder SDK for .NET")

**For Module #3, you need the following:**
- You must have a Microsoft Azure subscription. If you do not already have a subscription, you can register for a [free trial](https://azure.microsoft.com/en-us/free/). 
- Create Azure Cosmos Document DB and populate it with some data. Watch Module 3 to know how-to.
- Create Azure Search Service and add your Document DB as its data source. Watch Module 3 to know how-to.
- Add *Your Azure Search Service Name*,  *Your Azure Search Index Name* and *Your Azure Search Key *to Web.Config.

Applies only for "botsfromzerotohero/09. Module 3 - Chocolate Gallery Bot (LUIS)/":
- Create LUIS App from [here](https://www.luis.ai/home) and add 2 intents; *SearchChocolates* and *ShowChocolates* in addition to some chocolate types as entities then train your LUIS model. Watch Module 3 to know how-to.
- In the root dialog, add your LUIS APP ID and AZURE SUBSCRIPTION KEY to your LUIS MODEL Attribute. 
