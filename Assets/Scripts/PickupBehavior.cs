using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    [HideInInspector] public GameManager gameManager;
    [HideInInspector] public Vector3 position;

    public GameObject effect;

    private void Update()
    {
        this.transform.position = position + Vector3.up * Mathf.Sin(Time.time);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameManager.Pickup();
            GameObject newEffect = Instantiate(effect);
            newEffect.transform.position = transform.position;
        }
    }
}
