using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class Fader : MonoBehaviour
{
    [HideInInspector] public bool inFade = false;
    public float speed;
    private float point = 1;
    private Image self;

    private void Start()
    {
        self = this.GetComponent<Image>();
    }

    private void Update()
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
