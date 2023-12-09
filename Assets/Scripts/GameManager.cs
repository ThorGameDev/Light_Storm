using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PickupBehavior pickup;
    public Transform[] positions;
    public GameObject gameOver;

    private int count;
    public TMP_Text countDisplay;

    private void Start()
    {
        SetPos();
        count = 0;
        countDisplay.text = count.ToString();
        pickup.gameManager = this;
    }

    public void SetPos()
    {
        pickup.position = positions[Random.Range(0, positions.Length)].position;
    }

    public void Pickup()
    {
        count += 1;
        countDisplay.text = count.ToString();
        SetPos();
    }

    public void Loss()
    {
        gameOver.SetActive(true);
        FindObjectOfType<PlayerBehavior>().Detonate();
        Destroy(this);
    }
}
