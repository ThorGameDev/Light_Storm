using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void GameStart()
    {
        SceneManager.LoadScene("TheGame");
    }
    public void LoadScene(int choice)
    {
        SceneManager.LoadScene(choice);
    }
    public IEnumerator FadeOutToQuit()
    {
        yield return null;
    }
}
