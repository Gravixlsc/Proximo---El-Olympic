using UnityEngine;
using System.Collections;

public class PostQuery : MonoBehaviour
{
    //http://wiki.unity3d.com/index.php?title=Server_Side_Highscores //WEB DONDE ESTA EL TUTO.

    private string secretKey = "mySecretKey";
    public string queryURL = "http://thoseguyslabs.com/games/maraton/unity/query.php?";

    public enum injectionType { INSERT, UPDATE, SELECT, REMOVE }
    public injectionType _injectionType;

    public string _tabla = "scores";
    public string _id = "1";
    public string _param = "score";
    public string _value1 = "VALUE1";
    public string _value2 = "VALUE2";
    public string _value3 = "VALUE3";

    [TextArea(3, 10)]
    public string _query = "UPDATE scores SET score='0' WHERE id=1";

    void Start()
    {
        if (_injectionType == injectionType.UPDATE)
        {
            _query = "UPDATE " + _tabla + " SET " + _param + "='" + _value1 + "' WHERE id=" + _id + "";
        }

        if (_injectionType == injectionType.INSERT)
        {
            _query = "INSERT INTO " + _tabla + " (id, name, score) " + "\n" + "VALUES ('" + _value1 + "', '" + _value2 + "', '" + _value3 + "')";
        }

        if (_injectionType == injectionType.REMOVE)
        {
            _query = "DELETE FROM " + _tabla + " WHERE " + _param + "='" + _value2 + "'";
        }
    }

    IEnumerator PostScores()
    {
        if (_injectionType == injectionType.UPDATE)
        {
            _query = "UPDATE " + _tabla + " SET " + _param + "='" + _value1 + "' WHERE id=" + _id + "";
        }

        if (_injectionType == injectionType.INSERT)
        {
            _query = "INSERT INTO " + _tabla + " (id, name, score) " + "\n" + "VALUES ('" + _value1 + "', '" + _value2 + "', '" + _value3 + "')";
        }

        if (_injectionType == injectionType.REMOVE)
        {
            _query = "DELETE FROM " + _tabla + " WHERE " + _param + "='" + _value2 + "'";
        }

        string hash = MD5Encoding.Md5Sum(_query + secretKey);

        string post_url = queryURL + "q=" + WWW.EscapeURL(_query) + "&hash=" + hash;

        print(post_url);

        WWW hs_post = new WWW(post_url);
        yield return hs_post;
        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
        else
        {
            print(hs_post.text);
        }
    }

    public void Post()
    {
        StartCoroutine(PostScores());
    }
    //IEnumerator GetScores()
    //{
    //    GetComponent<Text>().text = "Loading Scores";
    //    WWW hs_get = new WWW(highscoreURL);
    //    yield return hs_get;

    //    if (hs_get.error != null)
    //    {
    //        print("There was an error getting the high score: " + hs_get.error);
    //    }
    //    else
    //    {
    //        GetComponent<Text>().text = hs_get.text;
    //    }
    //}
}