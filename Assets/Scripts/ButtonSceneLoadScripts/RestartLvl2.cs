using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartLvl2 : MonoBehaviour
{
    public void loadLvlAgain()
    {
        SceneManager.LoadScene(2);
    }
}
