using UnityEngine;
using System.Collections;

public class load_game : MonoBehaviour
{

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
