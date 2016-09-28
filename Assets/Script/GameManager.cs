using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    //private string secretKey = "mySecretKey";
    string getconfigURL = "http://thoseguyslabs.com/games/maraton/unity/gameconfig.php";

    [Header("Mapeado")]
    [Space(5)]
    public int cantPreguntas;
    public GameObject[] maps;
    public GameObject final;

    [Header("Preguntero")]
    [Space(5)]
    public int[] idPreguntas;

    GameObject gameO;

    void Start () {

        gameO = gameObject;
        StartCoroutine(GetScores());
    }

    void Update () {
	
	}

    IEnumerator GetScores()
    {
        WWW hs_get = new WWW(getconfigURL);
        yield return hs_get;

        if (hs_get.error != null)
        {
            print("There was an error getting the high score: " + hs_get.error);
        }
        else
        {
            cantPreguntas = int.Parse(hs_get.text.Split(',')[2]);
            idPreguntas = new int[cantPreguntas];

            Constructor();
        }
    }

    void Constructor()
    {
        for (int i = 0; i < cantPreguntas; i++)
        {
            gameO = (GameObject)(Instantiate(maps[Random.Range(0,maps.Length)], new Vector3(0,0,25 * (i + 1)), Quaternion.Euler(new Vector3(0, -90, 0))));
            gameO.transform.GetChild(0).name = i.ToString();

            if (i == cantPreguntas -1)
            {
                Instantiate(final, new Vector3(0, 0, 25 * (i + 2)), Quaternion.Euler(new Vector3(0, -90, 0)));
            }
        }

        //FindObjectOfType<ServerManager>().Iniciar(); /////////////////////////////////////////////////////////////////INICIAA!
    }
}
