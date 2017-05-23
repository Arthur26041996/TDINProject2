using System;

namespace Shared
{
    [Serializable]
    public class Client
    {
        public long cpf { get; set; }
        public string Name { get; set; }
        public int phone { get; set; }
        public string email { get; set; }
        public string address { get; set; }

        public override bool Equals(object obj)
        {
            return cpf == ((Client)obj).cpf;
        }
    }
}
