using UnityEngine;
using System.Collections;

public class audio_script : MonoBehaviour {

    public AudioSource[] soundtrack;

	// Use this for initialization
	void Start () {
        int choose = UnityEngine.Random.Range(0, 2);
        soundtrack[choose].Play();
	}
	
	// Update is called once per frame
	void Update () {
        if (soundtrack[0].isPlaying == false & soundtrack[1].isPlaying == false)
        {
            int choose = UnityEngine.Random.Range(0, 2);
            soundtrack[choose].Play();
        }
    }
}
