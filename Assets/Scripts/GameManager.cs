using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PickupBehavior pickup;
    public Transform[] positions;
    public int count;
    public TMP_Text count_display;
    public GameObject gameOver;

    public void Start()
    {
        SetPos();
        count = 0;
        count_display.text = count.ToString();
        pickup.gameManager = this;
    }

    public void SetPos()
    {
        pickup.position = positions[Random.Range(0, positions.Length)].position;
    }

    public void Pickup()
    {
        count += 1;
        count_display.text = count.ToString();
        SetPos();
    }

    public void Loss()
    {
        FindObjectOfType<Fader>().inFade = true;
        gameOver.SetActive(true);
        FindObjectOfType<PlayerBehavior>().Detonate();
        Destroy(this);
    }
}
