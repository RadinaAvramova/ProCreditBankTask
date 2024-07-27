namespace ProCreditBankZadacha.Services
{
    public class SwiftMT799Service
    {
        public class SwiftMT799Message
        {
            public string Field1 { get; set; }
            public string Field2 { get; set; }

        }

        public SwiftMT799Message ParseMT799(string message)
        {
            SwiftMT799Message mt799 = new SwiftMT799Message();
            
            return mt799;
        }
    }
}
