using UnityEngine;

public class Instrucciones : MonoBehaviour {

    private int playerCount = 0;
    public void NewPlayerConected(NetworkPlayer player)
    {
        Debug.Log("Player " + playerCount++ + " connected from " + player.ipAddress + ":" + player.port);
        if (playerCount >= 4)
        {
            Destroy(gameObject);
        }
    }
}
