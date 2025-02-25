using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupManager : MonoBehaviour
{
   public IEnumerator DoubleJumpPickup(Collider player,GameObject pickupEffect, float powerUpDuration )
    {
        Debug.Log("Double Jump power-up picked up.");

        // Enable double jump
        CharacterMovement movement = player.GetComponent<CharacterMovement>();
        if (movement != null)
        {
            movement.canDoubleJump = true;
        }

        // Trigger effect (instantiate the effect only when the power-up is picked up)
        if (pickupEffect != null)
        {
            pickupEffect.SetActive(true); // Activate the particle effect on pickup
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }

        // Disable pickup object
        

        Debug.Log(powerUpDuration);
        // Wait for power-up duration
        yield return new WaitForSeconds(powerUpDuration);

        // Disable double jump after time
        if (movement != null)
        {
            Debug.Log("Double Jump power-up expired.");
            movement.canDoubleJump = false;
        }
    }
}
