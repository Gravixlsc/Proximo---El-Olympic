using UnityEngine;
using System.Collections;

public class Publico : MonoBehaviour {

	void Start () {
        GetComponent<Animator>().SetInteger("Animation_int", Random.Range(0,3));
	}
	
}
