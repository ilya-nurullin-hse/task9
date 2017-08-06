using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    class List
    {
        public List next;
        public String data;

        public List(string data, List next = null)
        {
            this.data = data;
            this.next = next;
        }

        public List map(Func<String, String> f)
        {
            if (next == null)
                return new List(f(data), null);
            return new List(f(data), next.map(f));
        }
    }
}
