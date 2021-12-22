using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public class Slanje
    {
        private readonly Socket soket;
        private NetworkStream tok;
        private BinaryFormatter formater;

        public Slanje(Socket soket)
        {
            this.soket = soket;
            this.tok = new NetworkStream(soket);
            this.formater = new BinaryFormatter();
        }

        public void Posalji(object message)
        {
            try
            {
                formater.Serialize(tok, message);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.WriteLine("Heloo worlde");
            }
        }
    }
}
