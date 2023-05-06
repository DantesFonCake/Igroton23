using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScaneChange : MonoBehaviour
{
    public void MoveToDieScene()
    {
        SceneManager.LoadScene("DieGame");
    }
    public void Exit()
    {
        Application.Quit ();
    }
}
