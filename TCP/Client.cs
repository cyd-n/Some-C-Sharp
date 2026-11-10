using System.Net.Sockets;

namespace TCP;

public class Client {
    public int id = 0;
    public string name = "";
    public TcpClient baseClient { get; }
    public bool isLogin;
    
    public bool isBanned; // make work over seesion now if clietn leave the ban left to
    
    public Client(int _id,  TcpClient _client) {
        this.id = _id;
        this.name = "";
        this.baseClient = _client;
        this.isLogin = false;
        this.isBanned = false;
    }   
}