using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.Networking.Types;

public class MatchmakingManager : NetworkManager {

    private NetworkMatch networkMatch;

    void Update()
    {
        if (networkMatch == null)
        {
            NetworkMatch nm = GetComponent<NetworkMatch>();
            if (nm != null)
            {
                networkMatch = nm as NetworkMatch;
                AppID appid;
                //appid = 94451;
                //networkMatch.SetProgramAppID(appid);
                
            }
        }
    }
}
