using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButtonScript : MonoBehaviour
{
    public void loadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
