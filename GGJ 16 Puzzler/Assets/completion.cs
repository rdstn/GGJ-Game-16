using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class completion : MonoBehaviour {

    public GameObject script;
    private int winner;
    public Image[] conclusions;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Pressed ()
    {
        winner = script.GetComponent<game_logic>().winner;
        if (winner==0) { conclusions[0].rectTransform.SetAsLastSibling(); }
        else if (winner>=1) { conclusions[1].rectTransform.SetAsLastSibling(); }
    }
}
