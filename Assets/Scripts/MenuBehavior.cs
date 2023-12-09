using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public Fader fadeObject;
    public void Quit()
    {
        StartCoroutine(FadeAndQuit());
    }

    public void LoadScene(int choice)
    {
        StartCoroutine(FadeToScene(choice));
    }

    public IEnumerator FadeAndQuit()
    {
        fadeObject.inFade = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(fadeObject.speed);
        yield return new WaitForEndOfFrame();
        Application.Quit();
    }

    public IEnumerator FadeToScene(int choice)
    {
        fadeObject.inFade = true;
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(fadeObject.speed);
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(choice);
    }
}
