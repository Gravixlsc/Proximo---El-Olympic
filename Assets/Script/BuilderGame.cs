using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuilderGame : MonoBehaviour {

    const string glyphs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private string secretKey = "mySecretKey";
    string queryURL = "http://thoseguyslabs.com/games/theolympic/query.php?";
    string consultURL = "http://thoseguyslabs.com/games/theolympic/consult.php?";

    public Text IdGame;
    public Text NameGame;
    public Text Players;
    public Text CantPreguntas;
    public Text IdP1;
    public Text IdP2;
    public Text IdP3;
    public Text IdP4;
    public Text IdP5;
    public Text IdP6;
    public Text IdP7;
    public Text IdP8;
    public Text IdP9;

    public GameObject SelectordePreguntas;
    Text IdaAsignar;

    string _Id = "NULL";
    string _idGame = "00000";
    string _NameGame = "Name Game";
    string _Players = "4";
    string _CantPreguntas = "4";
    string _IdP1 = "NULL";
    string _IdP2 = "NULL";
    string _IdP3 = "NULL";
    string _IdP4 = "NULL";
    string _IdP5 = "NULL";
    string _IdP6 = "NULL";
    string _IdP7 = "NULL";
    string _IdP8 = "NULL";
    string _IdP9 = "NULL"; 

    [TextArea(3, 10)]
    public string _query;

    //INSERT INTO `Games`(`Id`, `idGame`, `NameGame`, `Players`, `CantPreguntas`, `IdP1`, `IdP2`, `IdP3`, `IdP4`, `IdP5`, `IdP6`, `IdP7`, `IdP8`, `IdP9`) VALUES ([value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7],[value-8],[value-9],[value-10],[value-11],[value-12],[value-13],[value-14])

    void Start()
    {
        StartCoroutine(PostScores(consultURL));
    }

    public void PostInsert()
    {
        _Id = "NULL";
        IdGame.text = _idGame = CreateId();
        _NameGame = NameGame.text;
        _Players = Players.text;
        _CantPreguntas = CantPreguntas.text;
        _IdP1 = IdP1.text;
        _IdP2 = IdP2.text;
        _IdP3 = IdP3.text;
        _IdP4 = IdP4.text;
        _IdP5 = IdP5.text;
        _IdP6 = IdP6.text;
        _IdP7 = IdP7.text;
        _IdP8 = IdP8.text;
        _IdP9 = IdP9.text;
        _query = "INSERT INTO Games (Id, idGame, NameGame, Players, CantPreguntas, IdP1, IdP2, IdP3, IdP4, IdP5, IdP6, IdP7, IdP8, IdP9) " + "\n" + "VALUES ('" + _Id + "', '" + _idGame + "', '" + _NameGame + "', '" + _Players + "', '" + _CantPreguntas + "', '" + _IdP1 + "', '" + _IdP2 + "', '" + _IdP3 + "', '" + _IdP4 + "', '" + _IdP5 + "', '" + _IdP6 + "', '" + _IdP7 + "', '" + _IdP8 + "', '" + _IdP9 + "')";
        StartCoroutine(PostScores(queryURL));
    }

    string CreateId()
    {
        _idGame = "";
        for (int i = 0; i < 5; i++)
        {
            _idGame += glyphs[Random.Range(0, glyphs.Length)];
        }
        return _idGame;
    }

    public void SeleccionarPregunta(Text txtID)
    {
        IdaAsignar = txtID;
        SelectordePreguntas.SetActive(true);
    }

    public void AsignarIDPregunta(Text txtID)
    {
        IdaAsignar.text = txtID.text;
        SelectordePreguntas.SetActive(false);
    }

    IEnumerator PostScores(string url)
    {
        string hash = MD5Encoding.Md5Sum(_query + secretKey);

        string post_url = url + "q=" + WWW.EscapeURL(_query) + "&hash=" + hash;

        print(post_url);

        WWW hs_post = new WWW(post_url);
        yield return hs_post;

        print(hs_post.text);

        if (hs_post.error != null)
        {
            print("There was an error posting the high score: " + hs_post.error);
        }
    }
}
