using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace robot_IHM
{


    class Robot
    {
        private Byte[] Commande;
        private TcpClient SocketClient;
        private string Serveur;
        private int Port;
        private NetworkStream NetStream;
        public Robot(string _Serveur, int _Port)
        {
            Port = _Port;
            Serveur = _Serveur;
            // Instanciation du serveur
            SocketClient = new TcpClient();
            // Connexion au serveur
            try {SocketClient.Connect(Serveur, Port); }
            catch(SocketException e)
            {
                Console.WriteLine("Erreur à la connexion" + e);
            }
            NetStream = SocketClient.GetStream();

        }

        public void Commander(Byte[] Ordre)
        {
            Commande = Ordre;
            NetStream.Write(Commande, 0, 2);
        }


          

    }
}
