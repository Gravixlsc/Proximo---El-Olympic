using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PreguntasDownload : MonoBehaviour
{
    //http://wiki.unity3d.com/index.php?title=Server_Side_Highscores //WEB DONDE ESTA EL TUTO.

    private string secretKey = "mySecretKey";
    public string queryURL = "http://thoseguyslabs.com/games/theolympic/test.php?";

    public string _db = "TheOlympic";

    public string _query;

    public string[][] array;

    void Start()
    {
        StartCoroutine(PostScores());
    }

    IEnumerator PostScores()
    {
        string hash = MD5Encoding.Md5Sum(_db + _query + secretKey);

        string post_url = queryURL + "db=" + WWW.EscapeURL(_db) + "&q=" + WWW.EscapeURL(_query) + "&hash=" + hash;

        WWW hs_post = new WWW(post_url);

        yield return hs_post;
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }else
        {
            array = new string[hs_post.text.Split('-').Length - 1][];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new string[hs_post.text.Split('-')[i].Split('+').Length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = hs_post.text.Split('-')[i].Split('+')[j];
                }
            }

            GetComponent<SpawnPregunta>().Listdownload(array);

        }
    }
}