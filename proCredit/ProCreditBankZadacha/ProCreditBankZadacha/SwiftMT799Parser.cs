using System.Text.RegularExpressions;

namespace ProCreditBankZadacha
{
    public class SwiftMT799Parser
    {
        public class SwiftMT799Message
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }
        
        }

        public SwiftMT799Message ParseMT799(string message)
        {
            SwiftMT799Message mt799 = new SwiftMT799Message();

          
            Dictionary<string, string> fields = ExtractFields(message);

            if (fields.TryGetValue("Field1", out string field1Value))
            {
                mt799.Field1 = field1Value;
            }

            if (fields.TryGetValue("Field2", out string field2Value))
            {
                mt799.Field2 = field2Value;
            }

            

            return mt799;
        }

        private Dictionary<string, string> ExtractFields(string message)
        {
            
            string pattern = @":(.*?):(.*?)\r\n";

           
            MatchCollection matches = Regex.Matches(message, pattern);

            
            Dictionary<string, string> fields = new Dictionary<string, string>();
            foreach (Match match in matches)
            {
                if (match.Groups.Count == 3)
                {
                    string fieldName = match.Groups[1].Value;
                    string fieldValue = match.Groups[2].Value.Trim();
                    fields[fieldName] = fieldValue;
                }
            }

            return fields;
        }
    }
}
