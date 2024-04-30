using System;
using System.Collections.Generic;


namespace OopLaba7
{
    public class MyList
    {
        List<short> arrayList;

        public List<short> ArrayList { get; internal set; }

        public MyList()
        {
            arrayList = new List<short>();
        }

        public int count()
        {
            return arrayList.Count;
        }

        public List<short> returnArrayList()
        {
            return arrayList;
        }

        public void AddElement(short element)
        {
            arrayList.Add(element);
        }

        public short GetElement(int index)
        {
            if (!Validation.ValidateNumber(index, arrayList.Count, 0))
                return Int16.MinValue;
            return arrayList[index];
        }

        public List<short> FindMultiples(short number)
        {
            List<short> multiples = new List<short>();
            foreach (short element in arrayList)
            {
                if (element % number == 0)
                {
                    multiples.Add(element);
                }
            }
            return multiples;
        }
        public void ReplaceEvenPositionElementsWithZero()
        {
            for (int i = 0; i < count(); i++)
            {
                if (i % 2 == 0)
                {
                    arrayList[i] = 0;
                }
            }
        }


        public List<short> GetValuesGreaterThanThreshold(short number)
        {
            List<short> list = new List<short>();
            foreach (short s in arrayList)
            {
                if (number < s)
                {
                    list.Add(s);
                }
            }
            return list;
        }

        public void DeleteElementsAtNonEvenPositions()
        {
            for (int i = count() - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    arrayList.RemoveAt(i);
                }
            }
        }

    }
}