using System.Collections;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private float rotateSpeed = 50f;
    public float height = 2.5f;
    private Vector3 startPos;
    public float powerUpDuration = 30f;
    public GameObject pickupEffect; // Reference to the pickup effect

    void Start()
    {
        startPos = transform.position;

        // Ensure the pickup effect is inactive when the game starts
        if (pickupEffect != null)
        {
            pickupEffect.SetActive(false); // Hide the particle effect initially
        }
    }

    void Update()
    {
        // Rotate and hover effect
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        float newY = Mathf.Sin(Time.time * 5) * height;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
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
        gameObject.SetActive(false);

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
