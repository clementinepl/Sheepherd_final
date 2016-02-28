using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {

    public float vSpeed = 10;
    public float rSpeed = 10;

    private bool onTheGround = false;
    private Rigidbody body;
    private AudioSource son;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        son = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    void FixedUpdate()
    {
        float vx = Input.GetAxis("Horizontal")*rSpeed;
        float vz = Input.GetAxis("Vertical")*vSpeed;

        var v = body.transform.right;
        v.y = 0.0f;
        v.Normalize();
        v *= vz;
        v.y = body.velocity.y;
        body.velocity = v;
        //body.velocity = body.transform.forward * vz;
        body.transform.localEulerAngles = new Vector3(body.transform.localEulerAngles.x, body.transform.localEulerAngles.y + vx, body.transform.localEulerAngles.z);
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Minimouton" && son.isPlaying == false)
        {
            son.Play();
        }
    }
}
