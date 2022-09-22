using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip CoinPickUpSFX;
    [SerializeField] int pointsForCoinPickUp = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision is CapsuleCollider2D)
        {
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickUp);
            AudioSource.PlayClipAtPoint(CoinPickUpSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
        
    }
}
