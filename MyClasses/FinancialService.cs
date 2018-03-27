namespace MyClasses
{
    public enum FinancialStatus
    {
        Bad,
        Average,
        Good,
        Excellent
    }

    public class FinancialService : IFinancialService
    {
        public string GetFinancialScore(decimal balance)
        {
            string score = string.Empty;
            switch (balance)
            {
                case decimal n when (n <= 1000):
                    score = FinancialStatus.Bad.ToString();
                    break;
                case decimal n when (n > 1000 && n <= 10000):
                    score = FinancialStatus.Average.ToString();
                    break;
                case decimal n when (n > 10000 && n <= 50000):
                    score = FinancialStatus.Good.ToString();
                    break;
                case decimal n when (n > 50000):
                    score = FinancialStatus.Excellent.ToString();
                    break;
            }
            return score;
        }
    }
}
