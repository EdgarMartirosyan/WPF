using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    class Class1
    {

        private static String[] answers = new String[]
        {
             "Ask one more time.",
               "I can’t say right away.",
               "Without a doubt.",
               "It really is.",
               "Focus and ask again.",
               "Not.",
               "Yes indeed.",
               "I do not think so.",
               "Exactly.",
               "Better not say anything.",
               "Bad point of view.",
               "Probably it is.",
               "Very doubtful.",
               "As I see it, yes.",
               "My answer is no.",
               "Of course.",
               "Yes.",
               "You can be sure.",
               "Good point.",
               "Vague answer, try again."
        };

        public static String GetRandomAnswer()
        {
            return answers[new Random().Next(answers.Length)];
        }
    }
}
