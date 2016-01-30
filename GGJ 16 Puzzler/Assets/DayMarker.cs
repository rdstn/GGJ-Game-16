using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayMarker : MonoBehaviour {

    public int counter;
    public Text display;

	// Use this for initialization
	void Start () {
        counter = 0;
        display.text = "Day: " + counter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Increment()
    {
        counter++;
        display.text = "Day: " + counter;
    }

    public int Give_Day()
    {
        return counter;
    }
}
