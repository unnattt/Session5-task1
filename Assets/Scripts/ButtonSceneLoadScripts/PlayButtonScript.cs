using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButtonScript: MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
}
