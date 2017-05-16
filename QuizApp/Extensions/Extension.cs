using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Extensions
{
    public class Extension
    {
        public static string Activite(int code)
        {
            return (code == 1) ? ("აქტიური") : ("არ არის აქტიური");
        }
    }
}
