using System;

namespace KryptoKlasy
{
    public class RandomGenerator
    {
        static private RandomGenerator instance;
        private Random random;

        public RandomGenerator()
        {
            this.random = new Random();
        }

        static public RandomGenerator GetInstance()
        {
            if (instance == null)
                instance = new RandomGenerator();
            return instance;
        }

        public string GetRandomString()
        {
            return random.Next().ToString();
        }
    }
}
