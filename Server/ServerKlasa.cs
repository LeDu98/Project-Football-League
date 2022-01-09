using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class ServerKlasa
    {
        private Socket serverskiSoket;
        private List<Socket> klijentskiSoketi;

        public ServerKlasa()
        {
            
            serverskiSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            klijentskiSoketi = new List<Socket>();

        }

        public void Pokreni()
        {
            serverskiSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9100));
        }

        public void OsluskujMrezu()
        {
            try
            {

                serverskiSoket.Listen(5);
                
                while (true)
                {
                    Socket klijent = serverskiSoket.Accept();
                    klijentskiSoketi.Add(klijent);
                    Obrada obrada = new Obrada(klijent);
                    Thread nit = new Thread(obrada.PokreniObradu);
                    nit.IsBackground = true;
                    nit.Start();
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show("Kraj rada.");

                
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                System.Windows.Forms.MessageBox.Show("Greska na serverskoj strani");
            }
        }
        public void ZaustaviServer()
        {
            if (klijentskiSoketi == null)
                return;

            foreach (Socket s in klijentskiSoketi)
            {
                s.Close();

            }
            serverskiSoket.Close();
        }
    }
}
