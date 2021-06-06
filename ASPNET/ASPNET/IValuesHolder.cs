using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET
{
    public interface IValuesHolder
    {
        public List<string> Values { get; set; }
        public void Add(string input);
        public List<string> Get();
    }

    public class ValuesHolder : IValuesHolder
    {
        public List<string> Values { get; set; }

        public void Add(string input)
        {
            Values.Add(input);
        }

        public List<string> Get()
        {
            return Values;
        }
    }
}
