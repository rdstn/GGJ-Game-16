using UnityEngine;
using System.Collections;

public class audio_script_home_orders : MonoBehaviour {

    public AudioSource[] sounds;


	// Use this for initialization
	void Start () {
        
	}

    public void Beep ()
    {
        int choose = UnityEngine.Random.Range(0, 6);
        sounds[choose].Play();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
