using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ServerManager : NetworkBehaviour
{

    NetworkManager netManager;
    NetworkClient myClient;

    public GameObject loginScreen;
    public GameObject Instructions;

    public void Iniciar()
    {
        netManager = GetComponent<NetworkManager>();
        SetupServer();
    }

    public void SetupServer()
    {
        netManager.StartHost();
        NetworkServer.Listen("localhost", 7777);
    }

    public void SetupClient()
    {
        myClient = new NetworkClient();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
        myClient.Connect("localhost", 7777);
    }

    public void SetupLocalClient()
    {
        myClient = ClientScene.ConnectLocalServer();
        myClient.RegisterHandler(MsgType.Connect, OnConnected);
    }

    public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server");
    }
    private int playerCount = 0;

    public void NewPlayerConected()
    {
        playerCount++;
        Instructions.SetActive(false);
        if (playerCount == 4)
            loginScreen.SetActive(false);
    }
}