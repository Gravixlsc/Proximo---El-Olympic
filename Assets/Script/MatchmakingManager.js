#pragma strict
import UnityEngine.Networking;
import UnityEngine.Networking.Match;
 
 
 
public class MatchmakingManager extends NetworkManager{
 
    private var networkMatch:NetworkMatch;
 
     function Update(){
         if(networkMatch == null){
             var nm = GetComponent(NetworkMatch);
             if(nm != null){
                 networkMatch = nm as NetworkMatch;
                 var appid:UnityEngine.Networking.Types.AppID;
                 appid= 94451;
                 networkMatch.SetProgramAppID(appid);
             }
         }
     }
}