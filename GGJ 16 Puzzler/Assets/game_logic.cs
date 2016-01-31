//TODO: Credibilities and market share capping!

using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class game_logic : MonoBehaviour {

    //Fluff - all possible company names.
    public string[] company_names;
    //Fluff - the actual names.
    public string[] names_actual;
    //Personalities, for decision making.
    public string[] personalities_actual;
    //Personality types, from which the actual personalities ingame are chosen.
    public string[] personality_types;
    //Name-personality comboes picked.
    public int nature1;
    public int nature2;
    public int nature3;
    //Credibility, modifies stock share.
    public int[] credibilities;
    //Development, causes stocks increase or decrease.
    public int[] development;
    //Stock share, our "score".
    public int[] stock_share;
    //Attitude, for decision making.
    public int[] corp1_attitude;
    public int[] corp2_attitude;
    public int[] corp3_attitude;
    //Actions. Used to advance the game. Actions as of now are: none,slander,PR,litigation,collaborate,infiltrate,develop,lockdown, merger, joint PR.
    public string[] player_actions;
    //For lockdown action.
    public bool[] locked;
    //For turn tracking.
    public int turn;
    //For "out of the game" counter
    public bool[] merged;
    //To update between levels.
    public Button[] orders_controls;
    public Button[] home_controls;
    public Button turn_button;
    public Dropdown company_selector;
    public Text progress_bar;
    public Text credibility_bar;
    //For newsfeed reasons.
    public string[] actions;


	// Use this for initialization
	void Start () {

        string[] company_names = { "DogCo", "Bubble Brothers", "Edgesoft", "Voxel", "Digitron", "Visible Inc.", "Scroll", "Gomorah", "Sata-tech" };
        string[] personality_types = { "Saintly", "Positive", "Dev", "PR", "Slanderer", "Spy", "Sue","Negative", "Demonic" };
        nature1 = 10;
        nature2 = 10;
        nature3 = 10;

        for (int i = 0; i <= 3; i++)
        {
            credibilities[i] = 50;
            stock_share[i] = 25;
            development[i] = 0;
            corp1_attitude[i] = 3;
            corp2_attitude[i] = 3;
            corp3_attitude[i] = 3;
            merged[i] = false;
        }

        for (int i=0; i<3; i++)
        {
            int randNumber = UnityEngine.Random.Range(0, 9);
            if (i==0)
            {
                while (randNumber == nature1 || randNumber == nature2 || randNumber == nature3)
                {
                    randNumber = UnityEngine.Random.Range(0, 9);
                }
                Debug.Log(randNumber);
                nature1 = randNumber;
            }
            if (i == 1)
            {
                while (randNumber == nature1 || randNumber == nature2 || randNumber == nature3)
                {
                    randNumber = UnityEngine.Random.Range(0, 9);
                }
                Debug.Log(randNumber);
                nature2 = randNumber;
            }
            if (i == 2)
            {
                while (randNumber == nature1 || randNumber == nature2 || randNumber == nature3)
                {
                    randNumber = UnityEngine.Random.Range(0, 9);
                }
                Debug.Log(randNumber);
                nature3 = randNumber;
            }
            Debug.Log(i);
            personalities_actual[i] = personality_types[randNumber];
            names_actual[i] = company_names[randNumber];
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //The main "turn logic, for the player and the AI."
    public void Turn(int turn)
    {
        if (turn>3) { turn = 0; }
        if (turn!=0)
            {
                locked[1] = false;
                ActAI(1);
                locked[2] = false;
                ActAI(2);
                locked[3] = false;
                ActAI(3);
                progress_bar.GetComponent<progress_bar>().Change();
                credibility_bar.GetComponent<Credibility_bar>().Change();
            }
            else
            {
            locked[0] = false;
            turn_button.GetComponent<turn_button>().Reset();
            company_selector.GetComponent<company_selector>().Reset();
            for (int i=0; i<=2; i++) { home_controls[i].GetComponent<home_orders>().Reset(); home_controls[i].interactable = true; }
            for (int i=0; i<=17; i++) { orders_controls[i].GetComponent<orders_button>().Reset(); }
                if (player_actions[0]=="PR")
                {
                    PR(turn);
                }
                else if (player_actions[0]=="develop")
                {
                    Develop(turn);
                }
                else if (player_actions[0]=="lockdown")
                {
                    Lockdown(turn);
                }
                for (int j=1; j<3; j++)
                {
                    if (player_actions[j]=="slander")
                    {
                        Slander(turn, j);
                    }
                    if (player_actions[j]=="litigation")
                    {
                        Litigation(turn, j);
                    }
                    if (player_actions[j]=="collaborate")
                    {
                        Collaborate(turn, j);
                    }
                    if (player_actions[j]=="infiltrate")
                    {
                        Infiltrate(turn, j);
                    }
                    if (player_actions[j]=="merger")
                    {
                        Merger(turn, j);
                    }
                    if (player_actions[j]=="joint_PR")
                    {
                        JointPR(turn, j);
                    }
                }
            turn = 1;
        }
        for (int x = 0; x < 3; x++)
        {
            player_actions[x] = "none";
            if (credibilities[x]<0) { credibilities[x] = 0; }
            if (credibilities[x]>100) { credibilities[x] = 100; }
            if (development[x] < 0) { development[x] = 0; }
            if (development[x]>=10)
            {
               CalculateStock(x);
               development[x] = 0;
            }
            if (corp1_attitude[x] < 1) { corp1_attitude[x] = 1; }
            if (corp1_attitude[x] > 5) { corp1_attitude[x] = 5; }
            if (corp2_attitude[x] < 1) { corp2_attitude[x] = 1; }
            if (corp2_attitude[x] > 5) { corp2_attitude[x] = 5; }
            if (corp3_attitude[x] < 1) { corp3_attitude[x] = 1; }
            if (corp3_attitude[x] > 5) { corp3_attitude[x] = 5; }
        }
        progress_bar.GetComponent<progress_bar>().Change();
        credibility_bar.GetComponent<Credibility_bar>().Change();
    }

    //PR - boost credibility. Normal development pace.
    void PR(int turn)
    {
        credibilities[turn] = credibilities[turn] + 10;
        development[turn] = development[turn] + 2;
    }

    //Develop - boost development.
    void Develop (int turn)
    {
        development[turn] = development[turn] + 3;
    }

    //Lockdown - low development. Prevents slander and infiltrate until next round.
    void Lockdown (int turn)
    {
        development[turn] = development[turn] + 1;
        locked[turn] = true;
    }

    //Slander - damage your oponent's credibility if they are less credible than you to begin with.
    void Slander(int turn, int target)
    {
        if (locked[target] == true)
        {
            credibilities[turn] = credibilities[turn] - 5;
        }
        else
        {
            if (credibilities[turn] >= credibilities[target])
            {
                credibilities[target] = credibilities[target] - 10;
            }
            else
            {
                credibilities[turn] = credibilities[turn] - 5;
                credibilities[target] = credibilities[target] + 5;
            }
        }
        if (target == 0)
        {
            Debug.Log(turn + " " + target);
            actions[turn-1] = "You were slandered by " + names_actual[turn - 1] + "!";
        }
        if (target == 1)
        {
            corp1_attitude[turn] = corp1_attitude[turn] - 1;
        }
        if (target == 2)
        {
            corp2_attitude[turn] = corp2_attitude[turn] - 1;
        }
        if (target == 3)
        {
            corp3_attitude[turn] = corp3_attitude[turn] - 1;
        }
    }

    //Litigation - lower your oponent's development at the cost of your own credibility. Also boosts their credibility.
    void Litigation (int turn, int target)
    {
        if (stock_share[turn] >= stock_share[target])
        {
            credibilities[turn] = credibilities[turn] - 10;
            credibilities[target] = credibilities[target] + 5;
            development[target] = development[target] - 4;
        }
        else
        {
            credibilities[turn] = credibilities[turn] - 5;
        }
        if (target == 0)
        {
            Debug.Log(turn + " " + target);
            actions[turn-1] = "You were sued by " + names_actual[turn - 1] + "!";
        }
        if (target == 1)
        {
            corp1_attitude[turn] = corp1_attitude[turn] - 1;
        }
        if (target == 2)
        {
            corp2_attitude[turn] = corp2_attitude[turn] - 1;
        }
        if (target == 3)
        {
            corp3_attitude[turn] = corp3_attitude[turn] - 1;
        }
    }

    //Collaborate - a minor boost to credibility and development for both parties. Only way to sweeten up to other corps.
    void Collaborate (int turn, int target)
    {
        if (credibilities[turn] <= credibilities[target])
        {
            credibilities[turn] = credibilities[turn] + 5;
            credibilities[target] = credibilities[target] + 3;
            development[turn] = development[turn] + 1;
            development[target] = development[target] + 1;
        }
        else
        {
            credibilities[turn] = credibilities[turn] + 3;
            credibilities[target] = credibilities[target] + 5;
            development[turn] = development[turn] + 1;
            development[target] = development[target] + 1;
        }
        if (target == 0)
        {
            Debug.Log(turn + " " + target);
            actions[turn-1] = "You worked together with " + names_actual[turn - 1] + ".";
        }
        if (target == 1)
        {
            corp1_attitude[turn] = corp1_attitude[turn] + 1;
        }
        if (target == 2)
        {
            corp2_attitude[turn] = corp2_attitude[turn] + 1;
        }
        if (target == 3)
        {
            corp3_attitude[turn] = corp3_attitude[turn] + 1;
        }
    }

    //Infiltrate - damage an enemy's dev and credibility at a risk if they are locked down.
    void Infiltrate (int turn, int target)
    {
        if (locked[target] == true)
        {
            credibilities[turn] = credibilities[turn] - 10;
            if (target == 0)
            {
                Debug.Log(turn + " " + target);
                actions[turn-1] = "You caught a spy from " + names_actual[turn - 1] + "!";
            }
            if (target == 1)
            {
                corp1_attitude[turn] = corp1_attitude[turn] - 1;
            }
            if (target == 2)
            {
                corp2_attitude[turn] = corp2_attitude[turn] - 1;
            }
            if (target == 3)
            {
                corp3_attitude[turn] = corp3_attitude[turn] - 1;
            }
        }
        else
        {
            credibilities[target] = credibilities[target] - 5;
            development[target] = development[target] - 1;
        }
    }

    //Merger. Adds stock share, mostly to merging company and equalizes credibilty. Only tool to take others out of the game.
    void Merger (int turn, int target)
    {
        if (stock_share[target]<=10)
        {
            credibilities[turn] = (credibilities[turn] + credibilities[target]) / 2;
            stock_share[turn] = stock_share[turn] + stock_share[target] / 2;
            for (int i=0; i<=3; i++)
            {
                stock_share[i] = stock_share[i] + stock_share[target] / 2 * 3;
            }
            merged[target] = true;
        }
        else
        {
            credibilities[turn] = credibilities[turn] - 10;
        }
        if (target == 0)
        {
            Debug.Log(turn + " " + target);
            actions[turn - 1] = "You were devoured. Game over.";
        }
    }

    //Joint PR. Boosts cred.
    void JointPR (int turn, int target)
    {
        credibilities[turn] = credibilities[turn] + 10;
        credibilities[target] = credibilities[target] + 10;
        if (target == 0)
        {
            Debug.Log(turn + " " + target);
            actions[turn - 1] =  names_actual[turn - 1] + " worked with you on promotion.";
        }
        if (target == 1)
        {
            corp1_attitude[turn] = corp1_attitude[turn] + 1;
        }
        if (target == 2)
        {
            corp2_attitude[turn] = corp2_attitude[turn] + 1;
        }
        if (target == 3)
        {
            corp3_attitude[turn] = corp3_attitude[turn] + 1;
        }
    }

    void CalculateStock(int corp)
    {
        if (credibilities[corp]<15)
        {
            stock_share[corp] = stock_share[corp] - 6;
            for (int i=0; i<=3; i++)
            {
                if (i!= corp)
                {
                    stock_share[i] = stock_share[i] + 2;
                }
            }
        }
        else if (credibilities[corp] < 25)
        {
            stock_share[corp] = stock_share[corp] - 3;
            for (int i = 0; i <= 3; i++)
            {
                if (i != corp)
                {
                    stock_share[i] = stock_share[i] + 1;
                }
            }
        }
        else if (credibilities[corp] < 33)
        {
            //Nothig is changed, because we aren't credible enough to sell and aren't uncredible enough to not sell.
        }
        else if (credibilities[corp] < 50)
        {
            stock_share[corp] = stock_share[corp] + 3;
            for (int i = 0; i <= 3; i++)
            {
                if (i != corp)
                {
                    stock_share[i] = stock_share[i] - 1;
                }
            }
        }
        else if (credibilities[corp] < 66)
        {
            stock_share[corp] = stock_share[corp] + 6;
            for (int i = 0; i <= 3; i++)
            {
                if (i != corp)
                {
                    stock_share[i] = stock_share[i] - 2;
                }
            }
        }
        else if (credibilities[corp] < 75)
        {
            stock_share[corp] = stock_share[corp] + 9;
            for (int i = 0; i <= 3; i++)
            {
                if (i != corp)
                {
                    stock_share[i] = stock_share[i] - 3;
                }
            }
        }
        else if (credibilities[corp] <= 100)
        {
            stock_share[corp] = stock_share[corp] + 12;
            for (int i = 0; i <= 3; i++)
            {
                if (i != corp)
                {
                    stock_share[i] = stock_share[i] - 4;
                }
            }
        }
    }

    //AI Behavioral patterns.
    void ActAI(int turn)
    {
        //Grab the attitudes of the current AI.
        int[] attitude = new int[4] { 3, 3, 3, 3 };
        if (turn == 1) { attitude = corp1_attitude; }
        if (turn == 2) { attitude = corp2_attitude; }
        if (turn == 3) { attitude = corp3_attitude; }

        //Attitudes check for current AI.
        int[] status = new int[4] { 2, 2, 2, 2 }; //1 is for friends, 0 is for enemies, 2 is for self and companies we are neutral towards.
        for (int i=0; i<=3; i++)
        {
            if (attitude[i]<3)
            {
                status[i] = 0;
            }
            if (attitude[i]>3)
            {
                status[i] = 1;
            }
        }
        if (merged[turn] == true)
        {
            //A company can't do anything if it is merged.
        }
        else
        {
            //Saintly AI - will boost cred, then develop and colab constantly. Never goes for anything bad.
            if (personalities_actual[turn-1] == "Saintly")
            {
                if (credibilities[turn] < 75)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber==turn || merged[randNumber]==true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    JointPR(turn, randNumber);
                }
                else
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    Collaborate(turn, randNumber);
                }
            }
            else if(personalities_actual[turn-1]=="Positive")
            {
                if (credibilities[turn] < 75)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { JointPR(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { Collaborate(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
            }
            else if(personalities_actual[turn-1]=="PR")
            {
                if (credibilities[turn] < 90)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { JointPR(turn, randNumber); }
                    else { Slander(turn, randNumber); }
                }
                else if (stock_share[turn] < 15)
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber]<stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0 & stock_share[randNumber]<12) { Merger(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else
                {
                    Lockdown(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { Collaborate(turn, randNumber); }
                    else { Slander(turn, randNumber); }
                }
            }
            else if(personalities_actual[turn-1]=="Dev")
            {
                if (credibilities[turn]<50)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { Collaborate(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { Collaborate(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
            }
            else if(personalities_actual[turn-1]=="Slanderer")
            {
                if (credibilities[turn] < 50)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { JointPR(turn, randNumber); }
                    else { Slander(turn, randNumber); }
                }
                else if (stock_share[turn] < 15)
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0 & stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (status[randNumber]!=0) { Infiltrate(turn, randNumber); }
                    else { Slander(turn, randNumber); }
                }
                else
                {
                    int randNumber2 = UnityEngine.Random.Range(0,2);
                    if (randNumber2==0) { Lockdown(turn); }
                    else { PR(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { Collaborate(turn, randNumber); }
                    else { Slander(turn, randNumber); }
                }
            }
            else if(personalities_actual[turn-1]=="Spy")
            {
                if (credibilities[turn] < 50)
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 2);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else { PR(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0) { JointPR(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else if (stock_share[turn] < 20)
                {
                    Develop(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0 & stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 2);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    Infiltrate(turn, randNumber);
                }
            }
            else if(personalities_actual[turn-1]=="Sue")
            {
                if (credibilities[turn] < 33)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    JointPR(turn, randNumber);
                }
                else if (stock_share[turn] < 25)
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 2);
                    if (randNumber2 == 0) { PR(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (status[randNumber] != 0 & stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (stock_share[randNumber]<stock_share[turn]+3) { Litigation(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
                else
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 3);
                    if (randNumber2 == 0) { PR(turn); }
                    else if (randNumber2 == 1) { Lockdown(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (stock_share[turn]+3>stock_share[randNumber]) { Litigation(turn, randNumber); }
                    else { Infiltrate(turn, randNumber); }
                }
            }
            else if(personalities_actual[turn-1]=="Negative")
            {
                if (credibilities[turn] < 33)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    JointPR(turn, randNumber);
                }
                else if (stock_share[turn] < 25)
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 3);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else if (randNumber2 == 1) { PR(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (stock_share[randNumber] < stock_share[turn] + 3) { Litigation(turn, randNumber); }
                    else
                    {
                        if (randNumber2 == 0) { Infiltrate(turn, randNumber); }
                        else { Slander(turn, randNumber); }
                    }
                }
                else
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 3);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else if (randNumber2 == 1) { PR(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (stock_share[randNumber] < stock_share[turn] + 3) { Litigation(turn, randNumber); }
                    else
                    {
                        if (randNumber2 == 0) { Infiltrate(turn, randNumber); }
                        else if (randNumber2 == 1) { JointPR(turn, randNumber); }
                        else { Slander(turn, randNumber); }
                    }
                }
            }
            else if (personalities_actual[turn-1]=="Demonic")
            {
                if (credibilities[turn] < 25)
                {
                    PR(turn);
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    JointPR(turn, randNumber);
                }
                else if (stock_share[turn] < 50)
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 3);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else if (randNumber2 == 1) { PR(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true || stock_share[randNumber] < stock_share[turn])
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (stock_share[randNumber] < stock_share[turn] + 3) { Litigation(turn, randNumber); }
                    else
                    {
                        if (randNumber2 == 0) { Slander(turn, randNumber); }
                        else { Infiltrate(turn, randNumber); }
                    }
                }
                else
                {
                    int randNumber2 = UnityEngine.Random.Range(0, 3);
                    if (randNumber2 == 0) { Lockdown(turn); }
                    else if (randNumber2 == 1) { PR(turn); }
                    else { Develop(turn); }
                    int randNumber = UnityEngine.Random.Range(0, 4);
                    while (randNumber == turn || merged[randNumber] == true)
                    {
                        randNumber = UnityEngine.Random.Range(0, 4);
                    }
                    if (stock_share[randNumber] < 12) { Merger(turn, randNumber); }
                    else if (stock_share[randNumber] < stock_share[turn] + 3) { Litigation(turn, randNumber); }
                    else
                    {
                        if (randNumber2 == 0) { Infiltrate(turn, randNumber); }
                        else { Slander(turn, randNumber); }
                    }
                }
            }
            else { Debug.Log("We have no proper personality type for this company. Company number: " + turn +". Personalities: " + personalities_actual); }
        }
    }
}
