namespace Szkoleniev2
{
    public class StringCalculator
    {
        public int Add(string number) 
        {
            if (number == "")
            {
                return 0;
            }
            List<string> delimiters = new List<string>();
            if (number[0] == '/')
            {
                var input = "";
                bool begin = false;
                for (int index = 0; index < number.Count(); index++)
                {
                    if (number[index] == '[') 
                    {
                        begin = true;
                        continue;
                    }
                    if (number[index] == ']')
                    {
                        begin = false;
                        delimiters.Add(input);
                        input = "";
                        continue;
                    }
                    if (begin) {
                        input = input + number[index];
                    }
                }
                number = number.Substring(number.IndexOf('\n') + 1);
            }
            number = number.Replace('\n', ',');
            foreach (var item in delimiters)
            {
              number = number.Replace(item, ",");
            }
            var numbersParsed = number.Split(",").Select(x => Int32.Parse(x)).Where(x=>x<1000);

            if (numbersParsed.Where(x => x < 0).Any())
            {
                var negative = numbersParsed.Where(x => x < 0).ToList();
                if (negative.Count == 1)
                {
                    throw new Exception($"Negatives not allowed. [{negative[0]}]");
                }
                else 
                {
                    string message = "[";
                    for (int i = 0; i < negative.Count; i++)
                    {
                        message =message+ negative[i];
                        if (i + 1 != negative.Count)
                        {
                            message = message + ",";
                        }
                    }
                    message = message + "]";
                    throw new Exception($"Negatives not allowed. {message}");
                }
            }
            return numbersParsed.Sum();
        }
    }
}