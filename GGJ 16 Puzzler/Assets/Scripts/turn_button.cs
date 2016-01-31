using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class turn_button : MonoBehaviour {

    public GameObject script;
    public int actions;
    public Button itself;
    public Text day;
    public Text[] newsfeed;

    // Use this for initialization
    void Start () {
        actions = 0;
        itself.interactable = false;
	}

    public void Reset()
    {
        actions = 0;
        itself.interactable = false;
    }
	
	// Update is called once per frame
	void Update () {
	    if (actions == 2)
        {
            itself.image.color = Color.yellow;
        }
        else
        {
            itself.image.color = Color.white;
        }
	}

    public void Increment()
    {
        actions++;
        if (actions==2)
        {
            itself.interactable = true;
        }
    }

    public void Decrement()
    {
        actions--;
        itself.interactable = false;
    }

    public void Press()
    {
        script.GetComponent<game_logic>().Turn(0);
        script.GetComponent<game_logic>().Turn(1);
        string[] temp_actions = new string[4] { "", "", "", "" };
        script.GetComponent<game_logic>().player_actions = temp_actions;
        day.GetComponent<DayMarker>().Increment();
        for (int i=0; i<3; i++) { newsfeed[i].GetComponent<news_script>().Change(); }
        Start();
    }
}
