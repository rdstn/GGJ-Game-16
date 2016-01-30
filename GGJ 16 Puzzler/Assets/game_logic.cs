using UnityEngine;
using System;
using System.Collections;

public class game_logic : MonoBehaviour {

    //Fluff.
    public string[] company_names;
    //Personalities, for decision making.
    public string[] personalities_actual;
    //Personality types, from which the actual personalities ingame are chosen.
    public string[] personality_types;
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
    //Actions. Used to advance the game.
    public string[] player_actions;
    public string[] corp1_actions;
    public string[] corp2_actions;
    public string[] corp3_actions;
    //Actions as of now are: none,slander,PR,litigation,collaborate,infiltrate,develop,lockdown
    public int[] action_influences;
    //For lockdown action.
    public bool[] locked;
    //For turn tracking.
    public int turn;

	// Use this for initialization
	void Start () {

        string[] personality_types = { "Saintly", "Good", "PR", "Balanced", "Sue", "Spy", "Slanderer", "Evil" };

        for (int i = 0; i < 3; i++)
        {
            credibilities[i] = 50;
            stock_share[i] = 25;
            development[i] = 0;
            corp1_attitude[i] = 3;
            corp2_attitude[i] = 3;
            corp3_attitude[i] = 3;
        }

        for (int i=0; i<2; i++)
        {
            int randNumber = UnityEngine.Random.Range(0, personality_types.GetLength(0));
            personalities_actual[i] = personality_types[randNumber];
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //The main "turn logic, for the player and the AI."
    void Turn(int turn)
    {
        if (turn!=0)
            {
                ActAI(turn);
            }
            else
            {
                //If someone goes for PR, give them dev and credibility.
                if (player_actions[0]=="PR")
                {
                    PR(turn);
                }
                //If someone goes for dev, give them more dev.
                else if (player_actions[0]=="develop")
                {
                    Develop(turn);
                }
                //If someone goes for lockdown, prevent slander for next turn.
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
                }
        }
        for (int x = 0; x < 3; x++)
        {
            player_actions[x] = "none";
            corp1_actions[x] = "none";
            corp2_actions[x] = "none";
            corp3_actions[x] = "none";
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
            locked[turn] = false;
        }
    }

    //PR - boost credibility. Normal development pace.
    void PR(int turn)
    {
        credibilities[turn] = credibilities[turn] + 20;
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
            credibilities[turn] = credibilities[turn] + 10;
            credibilities[target] = credibilities[target] + 5;
            development[turn] = development[turn] + 1;
            development[target] = development[target] + 1;
        }
        else
        {
            credibilities[turn] = credibilities[turn] + 5;
            credibilities[target] = credibilities[target] + 10;
            development[turn] = development[turn] + 1;
            development[target] = development[target] + 1;
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

    void CalculateStock(int corp)
    {
        //TODO
    }

    //AI Behavioral patterns.
    void ActAI(int turn)
    {
        //Saintly AI - will boost cred, then develop and colab constantly. Never goes for anything bad.
        if (personalities_actual[turn] == "Saintly")
        {
            if (credibilities[turn] < 100)
            {

            }
        }
    }
}
