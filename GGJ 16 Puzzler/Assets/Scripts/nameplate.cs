using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class nameplate : MonoBehaviour {

    public Text itself;
    public GameObject script;
    public int number;

	// Use this for initialization
	void Start () {
        if (number != 0) { itself.text = script.GetComponent<game_logic>().names_actual[number-1]; }
        else { itself.text = "Player"; }
	}
	
	// Update is called once per frame
	void Update () {

        if (number != 0) { itself.text = script.GetComponent<game_logic>().names_actual[number - 1]; }
    }
}
