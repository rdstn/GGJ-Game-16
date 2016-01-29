using UnityEngine;
using System;
using System.Collections;

public class game_logic : MonoBehaviour {

    public string[] company_names;
    public int[] selected;
    public string[] personalities_actual;
    public string[] personality_types;
    public int[] credibilities;
    public int[] development;
    public int[] stock_share;
    public int[] attitude;
    private string[] player_actions;
    private string[] corp1_actions;
    private string[] corp2_actions;
    private string[] corp3_actions;
    //Actions as of now are, in order: slander,PR,litigation,collaborate,infiltrate,develop,lockdown)
    public static int[] action_influences;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 3; i++)
        {
            credibilities[i] = 50;
            stock_share[i] = 25;
            development[i] = 0;
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

    void Tick()
    {
        for (int i = 0; i < 3; i++)
        {
            credibilities[i] = getCred(i);
            stock_share[i] = 25;
            development[i] = 0;
        }
    }

    int getCred(int i)
    {
        if 
    }
}
