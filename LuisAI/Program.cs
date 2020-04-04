using LuisAI.Services;
using LuisManager;
using System;
using System.Collections.Generic;

namespace LuisAI
{
    class Program
    {
        static void Main(string[] args)
        {
            LuisAppService ts = new LuisAppService();
            ts.InitLuis();

            Console.WriteLine("Tanár/Tanító segítő rész: Megadhat egy kérdést és rá választ, melyet a rendszer eltárol. Pár másodpercet vesz csak igénybe");

            Console.WriteLine("Adjon meg egy kérdést, vagy írja be 'nem' szót ha kihagyná kérdés hozzáadás opciót");
            var question = Console.ReadLine();

            if (question != "nem")
            {
                Console.WriteLine();

                Console.WriteLine("Mi a válasz rá?");
                var answer = Console.ReadLine();
                Console.WriteLine();

                var answers = new List<string>
                {
                    answer
                };

                Console.WriteLine("Kérdés hozzáadása rendszerhez folyamatban....");
                ts.AddQuestion(question, answers);
            }

            Console.WriteLine("Diákokat segítő rész: Csak válaszolni kell a kérdésre");

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

                if (result.TopScoringIntent != null && result.TopScoringIntent.Score > 0.8 && result.TopScoringIntent.Intent == q)
                    Console.WriteLine("Helyes válasz");
                else
                    Console.WriteLine("Helytelen válasz");
            }
        }
    }
}
