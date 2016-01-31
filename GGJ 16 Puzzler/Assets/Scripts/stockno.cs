using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class stockno : MonoBehaviour {

    public Text itself;
    public GameObject script;
    public int number;

	// Use this for initialization
	void Start () {
        itself.text = script.GetComponent<game_logic>().stock_share[number] + "%";
    }
	

	// Update is called once per frame
	void Update () {
        itself.text = script.GetComponent<game_logic>().stock_share[number] + "%";
    }
}
