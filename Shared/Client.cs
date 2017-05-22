using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [Serializable]
    public class Client
    {
        public int cpf { get; set; }
        public string Name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }
    }
}
