using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Credibility_bar : MonoBehaviour {

    public Text itself;
    public GameObject script;

	// Use this for initialization
	void Start () {
        itself.text = "Your company is regarded well.";
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Change ()
    {
        if (script.GetComponent<game_logic>().credibilities[0]<15)
        {
            itself.text = "Your company is the Antichrist.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 25)
        {
            itself.text = "Your company kills puppies.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 33)
        {
            itself.text = "Your company kills puppies.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 50)
        {
            itself.text = "Your company is of ill repute.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 50)
        {
            itself.text = "Your company isn't well loved.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 66)
        {
            itself.text = "Your company is regarded well.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] < 75)
        {
            itself.text = "Your company is widely praised.";
        }
        else if (script.GetComponent<game_logic>().credibilities[0] <= 100)
        {
            itself.text = "Your company can do no wrong.";
        }
        else
        {
            itself.text = "BUG: We don't know how your company's doing.";
        }
    }
}
