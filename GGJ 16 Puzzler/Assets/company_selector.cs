using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class company_selector : MonoBehaviour {

    public Dropdown itself;
    public GameObject[] panels;
    public GameObject script;

	// Use this for initialization
	void Start () {
        itself.options[0].text = script.GetComponent<game_logic>().names_actual[0];
        itself.options[1].text = script.GetComponent<game_logic>().names_actual[1];
        itself.options[2].text = script.GetComponent<game_logic>().names_actual[2];
        itself.GetComponentInChildren<Text>().text = itself.options[0].text;
        itself.interactable = true;
    }

    public void Reset()
    {
        itself.options[0].text = script.GetComponent<game_logic>().names_actual[0];
        itself.options[1].text = script.GetComponent<game_logic>().names_actual[1];
        itself.options[2].text = script.GetComponent<game_logic>().names_actual[2];
        itself.GetComponentInChildren<Text>().text = itself.options[0].text;
        itself.interactable = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeCompany()
    {
        panels[itself.value].transform.SetAsLastSibling();
        panels[itself.value].transform.SetSiblingIndex(panels[itself.value].transform.GetSiblingIndex() - 2);
    }
}
