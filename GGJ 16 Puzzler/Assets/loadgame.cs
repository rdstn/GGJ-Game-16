using UnityEngine;
using System.Collections;

public class loadgame : MonoBehaviour
{

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
