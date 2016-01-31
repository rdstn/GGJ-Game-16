using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class home_orders : MonoBehaviour {

    public Button itself;
    public Button turn;
    public bool set;
    public Button[] other_buttons;
    public GameObject script;
    public int setting;

	// Use this for initialization
	void Start () {
        set = false;
        itself.interactable = true;
	}

    public void Reset()
    {
        set = false;
        itself.interactable = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Press()
    {
        if (set == true)
        {
            set = false;
            for (int j = 0; j <= 1; j++)
            {
                other_buttons[j].interactable = true;
            }
            script.GetComponent<game_logic>().player_actions[0] = "none";
            turn.GetComponent<turn_button>().Decrement();
        }
        else if (set == false)
        {
            set = true;
            for (int j = 0; j <= 1; j++)
            {
                other_buttons[j].interactable = false;
            }
            if (setting == 0)
            {
                script.GetComponent<game_logic>().player_actions[0] = "develop";
            }
            if (setting == 1)
            {
                script.GetComponent<game_logic>().player_actions[0] = "PR";
            }
            if (setting == 2)
            {
                script.GetComponent<game_logic>().player_actions[0] = "lockdown";
            }
            turn.GetComponent<turn_button>().Increment();
        }
    }
}
