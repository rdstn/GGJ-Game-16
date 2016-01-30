using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class news_script : MonoBehaviour {

    public GameObject script;
    public Text itself;
    public int number;

	// Use this for initialization
	void Start () {
	
	}
	
    public void Change ()
    {
        Debug.Log("Newsfeed has been evoked!");
        if (script.GetComponent<game_logic>().actions[number] != "") { itself.text = script.GetComponent<game_logic>().actions[number]+""; }
        else
        {
            itself.text = "Nothing of interest.";
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
