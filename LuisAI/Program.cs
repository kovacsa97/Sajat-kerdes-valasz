using LuisAI.Services;
using LuisManager;
using System;
using System.Collections.Generic;
using System.Threading;

namespace LuisAI
{
    class Program
    {
        static LuisAppService ts = new LuisAppService();

        static void Main(string[] args)
        {
            ts.InitLuis();

            Bemutato();

            Console.WriteLine("Adjon meg egy kérdést, melyet feltenne a diákoknak");
            var question = Console.ReadLine();


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Mi a válasz rá?");
            var answer = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var answers = new List<string>
                {
                    answer
                };

            Console.WriteLine("Kérdés hozzáadása rendszerhez folyamatban....");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("A betanítás és kitelepítés folyamata zajlik, mely igénybe vehet 1-2 percet is");
            Console.WriteLine("Ezt azonban elég egy teljes dolgozat megadása után elvégezni, " +
                "1-2 perc a lefutás abban az esetben is, ha több a kérdés, melyet be kell tanulni");

            ts.AddQuestion(question, answers);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("És most jön a teszt az eddigi felvett kérdésekből :)");

            var questions = ts.GetQuestions();

            foreach (var q in questions)
            {
                if (q == "None")
                    break;
                Console.WriteLine(q);
                var answerForQuestion = Console.ReadLine();
                var result = LuisService.GetIntent(answerForQuestion).Result;

                if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.45 && result.TopScoringIntent.Intent == q)
                    Console.WriteLine("Helyes válasz");
                else { 
                    Console.WriteLine("Helytelen válasz");
                    Console.WriteLine("Helyes válaszlehetőségek: ");
                    var correctAnswers = ts.GetCorrectAnswers(q);
                    foreach(var c in correctAnswers)
                    {
                        Console.Write(c + " ");
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static void Bemutato()
        {
            Console.WriteLine("Bemutató az elkészült programból, mely után ki is próbálható");
            Thread.Sleep(1500);

            var question = "Ki a híres bűvös sárkány a dal szerint?";
            Console.WriteLine(question);
            Thread.Sleep(1500);

            var answerForQuestion = "Paff";
            Console.WriteLine(answerForQuestion);
            
            var result = LuisService.GetIntent(answerForQuestion).Result;

            if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.45 && result.TopScoringIntent.Intent == question)
                Console.WriteLine("Helyes válasz");
            else
            {
                Console.WriteLine("Helytelen válasz");
                Console.WriteLine("Helyes válaszlehetőségek: ");
                var correctAnswers = ts.GetCorrectAnswers(question);
                foreach (var c in correctAnswers)
                {
                    Console.Write(c + " ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);


            question = "Ki a híres bűvös sárkány a dal szerint?";
            Console.WriteLine(question);
            Thread.Sleep(1500);


            answerForQuestion = "Paff  a bűvös sárkány";
            Console.WriteLine(answerForQuestion);
            Thread.Sleep(1500);


            result = LuisService.GetIntent(answerForQuestion).Result;

            if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.45 && result.TopScoringIntent.Intent == question)
                Console.WriteLine("Helyes válasz");
            else
            {
                Console.WriteLine("Helytelen válasz");
                Console.WriteLine("Helyes válaszlehetőségek: ");
                var correctAnswers = ts.GetCorrectAnswers(question);
                foreach (var c in correctAnswers)
                {
                    Console.Write(c + ", ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);


            question = "Ki a híres bűvös sárkány a dal szerint?";
            Console.WriteLine(question);

            Thread.Sleep(1500);


            answerForQuestion = "Szerintem paff";
            Console.WriteLine(answerForQuestion);

            Thread.Sleep(1500);


            result = LuisService.GetIntent(answerForQuestion).Result;

            if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.45 && result.TopScoringIntent.Intent == question)
                Console.WriteLine("Helyes válasz");
            else
            {
                Console.WriteLine("Helytelen válasz");
                Console.WriteLine("Helyes válaszlehetőségek: ");
                var correctAnswers = ts.GetCorrectAnswers(question);
                foreach (var c in correctAnswers)
                {
                    Console.Write(c + ", ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(1500);


            question = "Ki a híres bűvös sárkány a dal szerint?";
            Console.WriteLine(question);

            Thread.Sleep(1500);


            answerForQuestion = "Süsü?";
            Console.WriteLine(answerForQuestion);

            Thread.Sleep(1500);


            result = LuisService.GetIntent(answerForQuestion).Result;

            if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.45 && result.TopScoringIntent.Intent == question)
                Console.WriteLine("Helyes válasz");
            else
            {
                Console.WriteLine("Helytelen válasz");
                Console.WriteLine("Helyes válaszlehetőségek: ");
                var correctAnswers = ts.GetCorrectAnswers(question);
                foreach (var c in correctAnswers)
                {
                    Console.Write(c + ", ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Thread.Sleep(2000);

        }
    }
}
