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
            int randNumber = UnityEngine.Random.Range(0, 40);
            if (randNumber == 0)
            {
                itself.text = "Cheeky Seagull Steals Chips";
            }
            else if (randNumber == 1)
            {
                itself.text = "OAP Driver Hits Lampost";
            }
            else if (randNumber == 2)
            {
                itself.text = "Early Customers Find Store Closed";
            }
            else if (randNumber == 3)
            {
                itself.text = "Fury as Bus Fails to Appear";
            }
            else if (randNumber == 4)
            {
                itself.text = "Kitchen Ovens Removed From Local School";
            }
            else if (randNumber == 5)
            {
                itself.text = "Woman finds Hat in Tree";
            }
            else if (randNumber == 6)
            {
                itself.text = "Police Storm Pub in Morris Dancer Row";
            }
            else if (randNumber == 7)
            {
                itself.text = "Shock as Pope steps down two years after Birmingham visit";
            }
            else if (randNumber == 8)
            {
                itself.text = "Bugs in this Game Made My Cat Cry";
            }
            else if (randNumber == 9)
            {
                itself.text = "Toy Shop Owner Throws A Tantrum";
            }
            else if (randNumber == 10)
            {
                itself.text = "Cafe Ejects Noise Girl, 2";
            }
            else if (randNumber == 11)
            {
                itself.text = "Castle Under Attace From Pidgeons";
            }
            else if (randNumber == 12)
            {
                itself.text = "Rotten Tree Falls in Garden";
            }
            else if (randNumber == 13)
            {
                itself.text = "Local Man in Custard Shortage";
            }
            else if (randNumber == 14)
            {
                itself.text = "Firefighters Recue Duck From Lake";
            }
            else if (randNumber == 15)
            {
                itself.text = "Man's Legs Stolen, Wedding Dreams Shattered";
            }
            else if (randNumber == 16)
            {
                itself.text = "Kitten Chokes on Mouse";
            }
            else if (randNumber == 17)
            {
                itself.text = "John Lennon's Tooth to Visit Preston";
            }
            else if (randNumber == 18)
            {
                itself.text = "I'm Stuck In A Printing Press, Please Send for Help";
            }
            else if (randNumber == 19)
            {
                itself.text = "I'm Not Dead, Says Grandma";
            }
            else if (randNumber == 20)
            {
                itself.text = "Yawning Almost Killed Local Man";
            }
            else if (randNumber == 21)
            {
                itself.text = "Man Stole Tortoise To Pay For Alcohol";
            }
            else if (randNumber == 22)
            {
                itself.text = "Yellow Lines Will Be Repainted Before Christmas";
            }
            else if (randNumber == 23)
            {
                itself.text = "OAP Baffles Experts With His 2 Foot Courgettes";
            }
            else if (randNumber == 24)
            {
                itself.text = "Toilet Curse Strikes Again";
            }
            else if (randNumber == 25)
            {
                itself.text = "Police Hunt Chorley Bum Pincher";
            }
            else if (randNumber == 26)
            {
                itself.text = "Kitten That Looks Like Gandhi - Pictures";
            }
            else if (randNumber == 27)
            {
                itself.text = "Drunk Falls on Face";
            }
            else if (randNumber == 28)
            {
                itself.text = "Hunt For Missing Pet Owl Continues";
            }
            else if (randNumber == 29)
            {
                itself.text = "Grass Growing Fast After Rain";
            }
            else if (randNumber == 30)
            {
                itself.text = "Dead Man Found in Graveyard";
            }
            else if (randNumber == 31)
            {
                itself.text = "Dog Poo Squal Results Squashed";
            }
            else if (randNumber == 32)
            {
                itself.text = "Dirty Protest At Bridge Club";
            }
            else if (randNumber == 33)
            {
                itself.text = "\"Girl Scout Cookies Promote Lesbians\"";
            }
            else if (randNumber == 34)
            {
                itself.text = "Chicken Stolen from Local Woman's Slow Cooker";
            }
            else if (randNumber == 35)
            {
                itself.text = "Bridal Couple Exchange Cows";
            }
            else if (randNumber == 36)
            {
                itself.text = "20,000 Pound Pavement To Help Homeless";
            }
            else if (randNumber == 37)
            {
                itself.text = "A Headline from Yesterdays Paper That Said \"Stolen Groceries\" Should Have Read \"Homocide\"";
            }
            else if (randNumber == 38)
            {
                itself.text = "Woman's Stomach Bug Actually Baby";
            }
            else if (randNumber == 39)
            {
                itself.text = "Stolem Prosthetic Arm Found in Second Hand Shop";
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
