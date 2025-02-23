using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffPickup : MonoBehaviour
{
    public float powerUpDuration = 15f;
    public float speedMultiplier = 2.2f;
    public GameObject pickUpEffect;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player){
        Debug.Log("Speed Boost power-up picked up.");

        CharacterMovement movement = player.GetComponent<CharacterMovement>();
        if(movement != null){
            movement.speedMultiplier *= speedMultiplier;
        }

        if(pickUpEffect != null)
            Instantiate(pickUpEffect, transform.position, Quaternion.identity);
        
        gameObject.SetActive(false);

        yield return new WaitForSeconds(powerUpDuration);

        if(movement != null){
            movement.speedMultiplier /= speedMultiplier;
        }

        Debug.Log("Speed Boost power-up expired.");
    }
}
