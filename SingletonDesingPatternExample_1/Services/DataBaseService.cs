namespace SingletonDesingPatternExample_1.Services
{
    public class DataBaseService
    {
        private DataBaseService()
        {
            Console.WriteLine($"{nameof(DataBaseService)} is created.");
        }

        private static DataBaseService _dataBaseService;
        public static DataBaseService GetInstance
        {
            get
            {
                if (_dataBaseService == null)
                    _dataBaseService = new DataBaseService();

                return _dataBaseService;
            }
        }

        public int Count { get; set; }
        public bool Connection()
        {
            Count++;
            Console.WriteLine("Baglanti saglandi.");
            return true;
        }

        public bool DisConnection()
        {
            Console.WriteLine("Baglanti koparildi.");
            return true;
        }
    }
}
