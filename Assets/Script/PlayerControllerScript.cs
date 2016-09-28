using UnityEngine;
using UnityEngine.Networking;

public class PlayerControllerScript : NetworkBehaviour {

    public Animator anim;
    public ParticleSystem part;
    float speed = 0;

    void Start () {
        gameObject.transform.GetChild(Random.Range(1,transform.childCount - 1)).gameObject.SetActive(true);
        part = Instantiate(part);
        part.transform.SetParent(transform);
        part.transform.localPosition = new Vector3(0, 0, -0.34f);
        part.Stop();
    }

    void Update() {

        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && transform.localPosition.z < 180)
        {
            if (!isLocalPlayer)
            {
                
                return;
            }
            else
            {
                if (speed < 0.5)
                {
                    speed += Time.deltaTime * 9;
                }
                else
                {
                    speed += Time.deltaTime * 4;
                }
                transform.position.Set(0, 0, 0);

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    anim.SetBool("Jump_b", true);
                }
                else
                {
                    anim.SetBool("Jump_b", false);
                }
            }
        }

        if (speed > 0)
        {
            speed -= Time.deltaTime;
        }
        else
        {
            speed = 0;
            part.Stop();
        }

        if (isLocalPlayer)
        {
            anim.SetFloat("Speed_f", speed);

            if (speed > 0.2 && anim.GetFloat("Multiply") > 1 && part.isStopped == true)
            {
                part.Play();
                print("Putas harry putas!");
            }
        }
    }

    public override void OnStartLocalPlayer()
    {
        print("LocalPlayer");

        gameObject.name = "LocalPlayer";

        FindObjectOfType<Camera>().transform.SetParent(gameObject.transform);

        Renderer[] rens = GetComponentsInChildren<Renderer>();
        foreach (Renderer ren in rens)
        {
            ren.enabled = false;
        }
        GetComponent<NetworkAnimator>().GetParameterAutoSend(0);
    }
    public override void PreStartClient()
    {
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        print("PeerPlayer");
        FindObjectOfType<Instrucciones>().NewPlayerConected(Network.player);
        print(Network.player.ipAddress);
    }

    void OnFailedToConnect(NetworkConnectionError error)
    {
        Debug.Log("Could not connect to server: " + error);
    }

    public void PowerUpSpeed(float maxspeed)
    {
        if (isLocalPlayer)
        {
            anim.SetFloat("Multiply", maxspeed);
            print("Multiiiii");
        }
    }
}

