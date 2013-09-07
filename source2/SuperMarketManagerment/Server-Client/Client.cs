using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using Entities;

namespace Server_Client
{
    public class Client
    {
        /// <summary>
        /// Connect to server 
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="port"></param>
        /// <returns></returns>
        public TcpClient Connect(string ipAddress, int port)
        {
            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient();
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
                tcpClient.Connect(serverEndPoint);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }
            return tcpClient;
        }

        /// <summary>
        /// Seriallize Object and objectName
        /// </summary>
        /// <param name="objectName"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public NetworkStream SerializeHepper(TcpClient client, string objectName, object[] obj)
        {
            NetworkStream clientStream = null;
            try
            {
                clientStream = client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(clientStream, objectName);
                formatter.Serialize(clientStream, obj);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }

            return clientStream;
        }

        public NetworkStream SerializeObj(TcpClient client, string objectName, object obj)
        {
            NetworkStream clientStream = null;
            try
            {
                clientStream = client.GetStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(clientStream, objectName);
                formatter.Serialize(clientStream, obj);
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
            }

            return clientStream;
        }
        /// <summary>
        /// DeserializeHepper
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public object DeserializeHepper(NetworkStream clientStream, object obj)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = (object)formatter.Deserialize(clientStream);
                return obj;
            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                return null;
            }
        }

        public object[] DeserializeHepper1(NetworkStream clientStream, object[] obj)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                obj = (object[])formatter.Deserialize(clientStream);
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}
