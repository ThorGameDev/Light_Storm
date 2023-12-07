using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBehavior : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject effect;

    public Vector3 position;
    void Update()
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