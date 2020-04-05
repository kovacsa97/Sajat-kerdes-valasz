using Cognitive.LUIS.Programmatic;
using Cognitive.LUIS.Programmatic.Apps;
using Cognitive.LUIS.Programmatic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuisAI.Services
{
    public class LuisAppService
    {
        private readonly string subscriptionKey = "17eb6f08cf7e4aa69b869abd0adcd517";
        private readonly string appVersion = "0.1";

        private AppService appService;
        private string appId;

        public void AddQuestion(string question, List<string> answers)
        {
            bool addIntent = AddIntent(question);
            if (!addIntent)
                return;

            foreach (var answer in answers)
            {
                AddExampleToIntent(question, answer);
            }

            var trained = TrainApp();
            PublishApp();
        }

        public List<string> GetQuestions()
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                var intents = client.Intents.GetAllAsync(appId, appVersion).Result;

                return intents.Select(i => i.Name).ToList();
            }
        }

        public List<string> GetCorrectAnswers(String question)
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                return client.Examples.GetAllAsync(appId, appVersion).Result.Where(e => e.IntentLabel == question).Select(e => e.Text).ToList();
            }
        }

        private bool AddIntent(string intentName)
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                var intents = client.Intents.GetAllAsync(appId, appVersion).Result;
                var intent = client.Intents.GetByNameAsync(intentName, appId, appVersion).Result;
                if (intent != null)
                    return false;          

                client.Intents.AddAsync(intentName, appId, appVersion);
                intent = client.Intents.GetByNameAsync(intentName, appId, appVersion).Result;

                if (intent == null)
                    return false;

                return true;
            }
        }

        private void AddExampleToIntent(string intent, string example)
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                var examples = client.Examples.GetAllAsync(appId, appVersion).Result;
                var entityExample = new Example
                {
                    Text = example,
                    IntentName = intent,
                };

                var x = client.Examples.AddAsync(appId, appVersion, entityExample).Result;
            }
        }

        private bool TrainApp()
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                var det = client.Training.TrainAndGetFinalStatusAsync(appId, appVersion, 300).Result;
                return det.Status.Equals("Success");
            }
        }

        private void PublishApp()
        {
            using (var client = new LuisProgClient(subscriptionKey, Regions.WestEurope))
            {
                var publish = client.Publishing.PublishAsync(appId, appVersion).Result;
            }
        }

        public void InitLuis()
        {
            var client = new LuisProgClient(subscriptionKey, Regions.WestEurope);
            var app = client.Apps.GetByNameAsync("LuisEdu").Result;
            if (app != null)
                appId = app.Id;
            else
                appId = client.Apps.AddAsync("LuisEdu", "Luis for education", "en-us", "Luis for education", string.Empty, appVersion).Result;
        }
    }
}
