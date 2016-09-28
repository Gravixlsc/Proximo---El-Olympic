using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginQuery : MonoBehaviour
{
    //http://wiki.unity3d.com/index.php?title=Server_Side_Highscores //WEB DONDE ESTA EL TUTO.

    private string secretKey = "mySecretKey";
    string queryURL = "http://thoseguyslabs.com/games/theolympic/login.php?";

    [TextArea(3, 10)]
    string _query = "SELECT * FROM Players WHERE DNI='12345678'";

    void Start()
    {

    }

    IEnumerator PostScores()
    {
        string hash = MD5Encoding.Md5Sum(_query + secretKey);

        string post_url = queryURL + "q=" + WWW.EscapeURL(_query) + "&hash=" + hash;

        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }else
        {
            //print(hs_post.text);
            if (hs_post.text == "YES")
            {
                Destroy(gameObject);
            }
        }
    }

    public void Post(Text txt)
    {
        if (txt.text.Length == 8)
        {
            _query = "SELECT * FROM Players WHERE DNI=\'" + txt.text + "\'";
            StartCoroutine(PostScores());
        }
    }
}