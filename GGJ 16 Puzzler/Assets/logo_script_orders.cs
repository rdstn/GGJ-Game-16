using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class logo_script_orders : MonoBehaviour {

    public GameObject script;
    public Image itself;
    public Sprite[] logos2;
    public int number;

	// Use this for initialization
	void Start () {
        itself = GetComponent<Image>();
        if (script.GetComponent<game_logic>().names_actual[number] == "DogCo") { itself.sprite = logos2[0]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Bubble Brothers") { itself.sprite = logos2[1]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Edgesoft") { itself.sprite = logos2[2]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Voxel") { itself.sprite = logos2[3]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Digitron") { itself.sprite = logos2[4]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Visible Inc.") { itself.sprite = logos2[5]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Scroll") { itself.sprite = logos2[6]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Gomorah") { itself.sprite = logos2[7]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Sata-tech") { itself.sprite = logos2[8]; }
    }
        
	
	
	// Update is called once per frame
	void Update () {
        itself = GetComponent<Image>();
        if (script.GetComponent<game_logic>().names_actual[number] == "DogCo") { itself.sprite = logos2[0]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Bubble Brothers") { itself.sprite = logos2[1]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Edgesoft") { itself.sprite = logos2[2]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Voxel") { itself.sprite = logos2[3]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Digitron") { itself.sprite = logos2[4]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Visible Inc.") { itself.sprite = logos2[5]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Scroll") { itself.sprite = logos2[6]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Gomorah") { itself.sprite = logos2[7]; }
        if (script.GetComponent<game_logic>().names_actual[number] == "Sata-tech") { itself.sprite = logos2[8]; }
    }
}
