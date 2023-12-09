using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFade : MonoBehaviour
{
    private Light mine;
    public float speed;
    private void Start()
    {
        mine = this.GetComponent<Light>();
    }
    private void Update()
    {

        mine.intensity -= Time.deltaTime * speed;
    }
}
