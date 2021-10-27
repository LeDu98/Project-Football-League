using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class Primanje
    {
        private readonly Socket soket;
        private NetworkStream tok;
        private BinaryFormatter formater;

        public Primanje(Socket soket)
        {
            this.soket = soket;
            this.tok = new NetworkStream(soket);
            this.formater = new BinaryFormatter();
        }

        public object Primi()
        {
            return formater.Deserialize(tok);
        }
    }
}
