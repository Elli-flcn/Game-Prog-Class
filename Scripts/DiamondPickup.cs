using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickup : MonoBehaviour
{
    [SerializeField] int diamondValue = 100;
    [SerializeField] AudioClip diamondPickupSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Ensure collision is with the Player
        if (collision.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(diamondPickupSFX, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddToScore(diamondValue);
            Destroy(gameObject);
        }
    }
}
