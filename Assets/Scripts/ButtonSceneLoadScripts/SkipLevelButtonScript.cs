using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipLevelButtonScript : MonoBehaviour
{
    public void loadNextLvl()
    {
        SceneManager.LoadScene(2);
    }
}
