using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class progress_bar : MonoBehaviour {

    public Text itself;
    public GameObject script;

    // Use this for initialization
    void Start () {
        itself.text = "0% to new product";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Change()
    {
        itself.text = script.GetComponent<game_logic>().development[0] * 10 + "% to new product";
    }
}
