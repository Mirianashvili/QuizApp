namespace QuizApp.Extensions
{
    public class Extension
    {
        public static string Activite(int code)
        {
            return (code == 1) ? ("აქტიური") : ("არ არის აქტიური");
        }

        public static string isRight(int code)
        {
            return (code == 1) ? ("ჭეშმარიტია") : ("მცდარია");
        }
    }
}
