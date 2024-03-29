﻿using System;

namespace KryptoKlasy
{
    public class RandomGenerator
    {
        static private RandomGenerator instance;
        private Random random;

        private RandomGenerator()
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

        public double GetRandomDouble(int min, int max)
            => (max - min) * random.NextDouble() + min;
    }
}
