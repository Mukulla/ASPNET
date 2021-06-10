using System;
using System.Collections.Generic;
using System.Linq;

namespace ASPNET001
{
    public interface IValuesHolder
    {
        public List<string> Values { get; set; }
        public void Set(string newTemp, DateTime dateToFind);
        public void Add(string newTemp, DateTime desiredDate);
        public void Delete(DateTime dateThatDelete);
        public List<string> Get(DateTime min, DateTime max);
    }

    public class ValuesHolder : IValuesHolder
    {
        public List<string> Values { get; set; }

        List<DateTime> LDateTime = new List<DateTime>();

        public ValuesHolder()
        {
            Values = new List<string>();
        }

        public void Set(string newTemp, DateTime dateToFind)
        {
            try
            {
                Values[FindIndex(dateToFind)] = newTemp;
            }
            catch (Exception)
            {
                //Console.WriteLine("Out of Range index");
            }            
        }
        public void Add(string newTemp, DateTime desiredDate)
        {
            Values.Add(newTemp);
            LDateTime.Add(desiredDate);
        }

        public void Delete(DateTime dateThatDelete)
        {
            try
            {
                int foundedIndex = FindIndex(dateThatDelete);
                Values.RemoveAt(foundedIndex);
                LDateTime.RemoveAt(foundedIndex);
            }
            catch (Exception)
            {
                //Console.WriteLine("Out of Range index");
            }

            /*
            for (int i = 0; i < LDateTime.Count(); ++i)
            {
                if (DateTime.Compare(dateToCompare, LDateTime[i]) == 0)
                {
                    Values.RemoveAt(i);
                    LDateTime.RemoveAt(i);
                }
            }*/
        }

        public List<string> Get(DateTime min, DateTime max)
        {
            List<string> Tempo = new List<string>();

            for (int i = 0; i < LDateTime.Count(); ++i)
            {
                if (DateTime.Compare(LDateTime[i], min) > 0 && DateTime.Compare(LDateTime[i], max) < 0)
                {                    
                    Tempo.Add(Values[i]);
                }
            }

            return Tempo;
        }

        int FindIndex(DateTime inputDate)
        {
            for (int i = 0; i < LDateTime.Count(); ++i)
            {
                if (DateTime.Compare(inputDate, LDateTime[i]) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}