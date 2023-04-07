using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLvl1 : MonoBehaviour
{
    public void loadLvlAgain()
    {
        SceneManager.LoadScene(1);
    }
}
