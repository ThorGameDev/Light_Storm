using UnityEngine.UI;
using UnityEngine;

public class Fader : MonoBehaviour
{
    public bool inFade;
    public float speed;
    public float point;
    public Image self;

    void Update()
    {
        if (inFade)
        {
            point += Time.deltaTime * speed;
        }
        else
        {
            point -= Time.deltaTime * speed;
        }
        point = Mathf.Clamp(point, 0, 1);
        Color newColor = new Color(0, 0, 0, point);
        self.color = newColor;
    }
}
