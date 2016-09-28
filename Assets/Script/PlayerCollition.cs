using UnityEngine;
using System.Collections;

public class PlayerCollition : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (GetComponent<PlayerControllerScript>().isLocalPlayer)
        {
            FindObjectOfType<SpawnPregunta>().GenerarPregunta(col.gameObject.name);
            Destroy(col.gameObject);
        }
    }
}
