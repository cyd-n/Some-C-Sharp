using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TCP;

public class SimpleServer
{
    private int lastIdJoined = 0;
    
    private TcpListener listener;
    private List<Client> clients = new List<Client>(); // Keeps track of connected clients

    private float version = 0.1f;
    
    public void Start(int _port) {
        listener = new TcpListener(IPAddress.Any, _port);
        listener.Start();
        Console.WriteLine("Server started, waiting for connections...");

        Thread acceptThread = new Thread(AcceptClients);
        acceptThread.Start();
    }

    private void AcceptClients() {
        while (true) {
            try {
                TcpClient _client = listener.AcceptTcpClient();
                Client client = new Client(lastIdJoined, _client);
                lastIdJoined++;
                
                clients.Add(client);
                Console.WriteLine("Client connected.");

                Thread clientThread = new Thread(() => MessageFromClient(client));
                clientThread.Start();
            } catch (Exception ex) {
                Console.WriteLine("Error accepting client: " + ex.Message);
            }
        }
    }

    private void MessageFromClient(Client _client) {
        NetworkStream stream = _client.baseClient.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        try {
            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0) {
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine("Received: " + message);
                
                string[] coreData = message.Split(':');
                if (coreData[0] == "101") { // 101: means login in 
                    string[] data = coreData[1].Split('$');

                    if(float.Parse(data[0]) == version) {
                        LoginClient(_client, data[2]);
                    } else {
                        MessageToClient(_client, "Error: You have the wrong version!");  
                    }
                }
            }
        } catch (Exception ex) {
            Console.WriteLine("Error communicating with client: " + ex.Message);
        } finally {
            stream.Close();
        }
    }
    
    private void MessageToClient(Client _client, string _message) {
        NetworkStream stream = _client.baseClient.GetStream();
        
        try {
            byte[] response = Encoding.UTF8.GetBytes(_message);
            stream.Write(response, 0, response.Length);
        } catch (Exception ex) {
            Console.WriteLine("Error communicating with client: " + ex.Message);
        } finally {
            stream.Close();
        }
    }
    
    private void StopClient(Client _client) {
        _client.baseClient.Close();
        clients.Remove(_client);
        Console.WriteLine("Client disconnected.");
    }
    
    private void LoginClient(Client _client, string _data) {
        NetworkStream stream = _client.baseClient.GetStream();
        
        byte[] binaryData = Convert.FromBase64String(_data);
        string decodedString = System.Text.Encoding.UTF8.GetString(binaryData);
        
        // auth for acount later.
        string[] data = decodedString.Split(':');
        
        _client.isLogin = true;
        _client.name = data[0];
        
        byte[] response = Encoding.UTF8.GetBytes($"Welcome {_client.name}");
        stream.Write(response, 0, response.Length);
    }

}

class Program
{
    static void Main()
    {
        SimpleServer server = new SimpleServer();
        server.Start(5454); // Choose your port, any port!
    }
};

/*
 Server status -	Track whether the server is running	 - Easy
   Login status - Know whether a client has authenticated -	Easy
   Username validation	Prevent empty or duplicate usernames -	Easy
   Server messages	Send different response codes -	Easy
   Connection limits	Limit how many clients can connect -	Easy
   Server uptime	Track how long the server has been running -	Easy
   Ping system	Measure client connection latency -	Medium
   Server commands	Commands such as /clients and /status -	Medium
   Kick client	Disconnect a selected client  -  Medium
*/