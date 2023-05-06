using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
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
