using UnityEngine;
using UnityEngine.SceneManagement;

public class UiEvents : MonoBehaviour
{
    public void ChangeScene(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
