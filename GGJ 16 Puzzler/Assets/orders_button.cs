using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class orders_button : MonoBehaviour {

    public Button itself;
    public Button[] other_buttons;
    public Dropdown other_corps;
    public bool set;
    public GameObject script;
    public int setting;
    public GameObject turn;

    // Use this for initialization
    void Start () {
        set = false;
        turn = GameObject.Find("Turn");
        itself.interactable = true;
	}

    public void Reset()
    {
        set = false;
        turn = GameObject.Find("Turn");
        itself.interactable = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (set==true)
        {
            itself.image.color = Color.white;
        }
        else if (set== false)
        {
            if (setting<3)
            {
              //  itself.image.color = Color.red;
            }
            else
            {
               // itself.image.color = Color.green;
            }
        }
	}

    public void Press()
    {
        if (set == true)
        {
            set = false;
            other_corps.interactable = true;
            for (int j=0; j < 5; j++)
            {
                other_buttons[j].interactable = true;
            }
            script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "none";
            other_corps.image.color = Color.white;
            turn.GetComponent<turn_button>().Decrement();
        }
        else if (set == false)
        {
            set = true;
            other_corps.interactable = false;
            turn.GetComponent<turn_button>().Increment();
            for (int j = 0; j < 5; j++)
            {
                other_buttons[j].interactable = false;
            }
            if (setting == 0)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "infiltrate";
                other_corps.image.color = Color.red;
            }
            if (setting == 1)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "slander";
                other_corps.image.color = Color.red;
            }
            if (setting == 2)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "litigation";
                other_corps.image.color = Color.red;
            }
            if (setting == 3)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "joint_PR";
                other_corps.image.color = Color.green;
            }
            if (setting == 4)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "collaborate";
                other_corps.image.color = Color.green;
            }
            if (setting == 5)
            {
                script.GetComponent<game_logic>().player_actions[other_corps.value + 1] = "merger";
                other_corps.image.color = Color.green;
            }
        }
    }
}
