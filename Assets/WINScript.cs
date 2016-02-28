using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WINScript : MonoBehaviour {
    private int mouton=0;
    private int moutonTotal = 0;
    private AudioSource son;
    private bool sonnorepeat = false;
    private GameObject compteur;
    // Use this for initialization
    void Start () {
        moutonTotal = GameObject.FindGameObjectsWithTag("Minimouton").Length;
        son = GetComponent<AudioSource>();
        compteur = GameObject.Find("Compteur");
        compteur.GetComponentsInChildren<Text>()[1].text = "/" + moutonTotal;
    }
	
	// Update is called once per frame
	void Update () {
        if (moutonTotal == mouton) {
            GameObject.Find("Canvas").GetComponent<Canvas>().enabled = true;
            if(!son.isPlaying && !sonnorepeat)
            {
                son.Play();
                sonnorepeat = true;
            }
               
        }
	
	}


void OnTriggerEnter(Collider collider)
{
    if (collider.gameObject.tag == "Minimouton")
    {
            mouton += 1;
            compteur.GetComponentsInChildren<Text>()[0].text = mouton.ToString();
        }
}

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Minimouton")
        {
            mouton -= 1;
            compteur.GetComponentsInChildren<Text>()[0].text = mouton.ToString();
        }
    }



}