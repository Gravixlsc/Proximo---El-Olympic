using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Query : MonoBehaviour
{
    //http://wiki.unity3d.com/index.php?title=Server_Side_Highscores //WEB DONDE ESTA EL TUTO.

    private string secretKey = "mySecretKey";
    public string queryURL = "http://thoseguyslabs.com/games/theolympic/test.php?";

    public string _db = "TheOlympic";
    public string _ORDER = "SELECT *";
    public string _FROM_or_SET = "FROM";
    public string _TABLA = "";
    public string _WHERE = "id";
    public string _WHERE_value = "";

    [TextArea(3, 10)]
    public string _query = "SELECT * FROM Players WHERE DNI='12345678'";

    public string urlFinal;

    [Header("Array")]
    //public string[] arrayRows;
    //public string[] arrayFields;

    public string[][] array;

    void Start()
    {
        
    }

    IEnumerator PostScores()
    {
        string hash = MD5Encoding.Md5Sum(_db + _query + secretKey);

        string post_url = queryURL + "db=" + WWW.EscapeURL(_db) + "&q=" + WWW.EscapeURL(_query) + "&hash=" + hash;

        urlFinal = post_url;

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

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    GetComponent<Text>().text += array[i][j];
                    GetComponent<Text>().text += " ";
                }

                GetComponent<Text>().text += "\n";
            }

        }
    }

    public void Post(string txt)
    {
        _query = txt;
        StartCoroutine(PostScores());
    }

    public void Post()
    {
        if (_TABLA != "")
        {
            _query = _ORDER + " " + _FROM_or_SET + " " + _TABLA;
            if (_WHERE_value != "")
            {
                _query += " WHERE " + _WHERE + "=\'" + _WHERE_value + "\'";
            }
        }
        StartCoroutine(PostScores());
    }

    public string[][] preguntasLista()
    {

        return array;
    }
}