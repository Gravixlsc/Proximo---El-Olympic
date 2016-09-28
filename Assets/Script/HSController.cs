using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HSController : MonoBehaviour
{
    //http://wiki.unity3d.com/index.php?title=Server_Side_Highscores //WEB DONDE ESTA EL TUTO.

    private string secretKey = "mySecretKey"; 
    public string addScoreURL = "http://thoseguyslabs.com/games/maraton/unity/addscore.php?";
    public string highscoreURL = "http://thoseguyslabs.com/games/maraton/unity/display.php?";

    void Start()
    {
        StartCoroutine(GetScores());
        //StartCoroutine(PostScores("Lucas", 0));
    }

    IEnumerator PostScores(string name, int score)
    {
        string hash = MD5Encoding.Md5Sum(name + score + secretKey);

        string post_url = addScoreURL + "name=" + WWW.EscapeURL(name) + "&score=" + score + "&hash=" + hash;

        WWW hs_post = new WWW(post_url);
        yield return hs_post;

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }

    IEnumerator GetScores()
    {
        GetComponent<Text>().text = "Loading Scores";
        WWW hs_get = new WWW(highscoreURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            GetComponent<Text>().text = hs_get.text;
        }
    }
}