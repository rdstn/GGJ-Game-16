using UnityEngine;
using System.Collections;

public class audio_script : MonoBehaviour {

    public AudioSource[] soundtrack;
    private int previous;

	// Use this for initialization
	void Start () {
        int choose = UnityEngine.Random.Range(0, 4);
        soundtrack[choose].Play();
        previous = choose;
	}
	
	// Update is called once per frame
	void Update () {
        if (soundtrack[0].isPlaying == false & soundtrack[1].isPlaying == false & soundtrack[2].isPlaying==false & soundtrack[3].isPlaying==false)
        {
            int choose = UnityEngine.Random.Range(0, 4);
            while (choose==previous) { choose = UnityEngine.Random.Range(0, 4); }
            soundtrack[choose].Play();
            previous = choose;
        }
    }
}
