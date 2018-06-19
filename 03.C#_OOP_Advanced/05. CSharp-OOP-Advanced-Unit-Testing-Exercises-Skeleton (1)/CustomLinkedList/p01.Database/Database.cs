namespace p01.Database
{
    using System;
    using System.Linq;

    public class Database : IDatabase
    {
        private const int DefaultCapacity = 16;

        private int[] numbers;
        private int currentIndex;

        public Database()
        {
            this.numbers = new int[DefaultCapacity];
            this.currentIndex = 0;
        }

        public Database(params int[] numbers)
        {
            SetValueOfArray(numbers);
        }

        private void SetValueOfArray(params int[] numbers)
        {
            Array.Copy(numbers, this.numbers, numbers.Length);
            if (this.numbers.Length != DefaultCapacity)
            { 
                throw new InvalidOperationException($"Array's capacity must be 16!");
            }
            this.currentIndex = this.numbers.Length;
        }

        public void AddElement(int number)
        {
            if (this.currentIndex > DefaultCapacity)
            {
                throw new InvalidOperationException("Array is full!");
            }
            this.numbers[currentIndex] = number;
            this.currentIndex++;
        }

        public void RemoveElement()
        {
            if (this.currentIndex == 0)
            {
                throw new InvalidOperationException("Array is empty!");
            }
            this.numbers[currentIndex] = default(int);
            currentIndex--;
        }

        public int[] Fetch()
        {
            int[] newArray = new int[currentIndex];
            Array.Copy(this.numbers, newArray, this.currentIndex);

            return newArray;
        }
    }
}
