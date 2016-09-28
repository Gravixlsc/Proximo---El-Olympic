using UnityEngine;
using UnityEngine.UI;

public class SpawnPregunta : MonoBehaviour {

    public string[][] PreguntasList;

    public GameObject Preguntero;
    public Text _Pregunta;
    public Transform _Respuesta1;
    public Transform _Respuesta2;
    public Transform _Respuesta3;

    int random;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    public void Listdownload(string[][] strings)
    {
        PreguntasList = strings;
        print(PreguntasList[Random.Range(0, 1)][2]);
    }

    void Start()
    {
        pos1 = _Respuesta1.localPosition;
        pos2 = _Respuesta2.localPosition;
        pos3 = _Respuesta3.localPosition;
        Preguntero.SetActive(false);
    }

    public void Iniciar()
    {

    }

    public void GenerarPregunta(string name)
    {
        GameObject.Find("LocalPlayer").GetComponent<PlayerControllerScript>().PowerUpSpeed(1f);
        if (name != "meta")
        {
            random = Random.Range(0, PreguntasList.Length);
            _Pregunta.text = PreguntasList[random][1];
            _Respuesta1.GetChild(0).GetComponent<Text>().text = PreguntasList[random][2];
            _Respuesta2.GetChild(0).GetComponent<Text>().text = PreguntasList[random][3];
            _Respuesta3.GetChild(0).GetComponent<Text>().text = PreguntasList[random][4];

            switch (Random.Range(0,2))
            {
                case 0:
                    _Respuesta1.localPosition = pos1; _Respuesta2.localPosition = pos2; _Respuesta3.localPosition = pos3;
                    break;
                case 1:
                    _Respuesta1.localPosition = pos2; _Respuesta2.localPosition = pos3; _Respuesta3.localPosition = pos1;
                    break;
                case 2:
                    _Respuesta1.localPosition = pos3; _Respuesta2.localPosition = pos1; _Respuesta3.localPosition = pos2;
                    break;
            }
            Preguntero.SetActive(true);
        }
        
    }

    public void Correcta()
    {
        GameObject.Find("LocalPlayer").GetComponent<PlayerControllerScript>().PowerUpSpeed(1.5f);
    }

    public void InCorrecta()
    {
        
    }
}
