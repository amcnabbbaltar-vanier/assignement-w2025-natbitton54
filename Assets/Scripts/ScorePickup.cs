using UnityEngine;
using System.Collections;

public class ScorePickup : MonoBehaviour
{
    public int scoreAmount = 50; // Points to add when picked up
    public GameObject pickupEffect; // Particle effect prefab
    public AudioClip pickupSound; // Sound to play when the pickup is collected
    private Renderer pickupRenderer;
    private Collider pickupCollider;
    private PickupMovement pickupMovement; // Reference to the PickupMovement script

    void Start()
    {
        pickupRenderer = GetComponent<Renderer>();
        pickupCollider = GetComponent<Collider>();
        pickupMovement = GetComponent<PickupMovement>();

        if (pickupSound == null)
        {
            Debug.LogError("Pickup sound is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the current score
            GameManager.Instance.currentScore += scoreAmount;

            // Update score in the CharacterMovement script
            CharacterMovement movement = other.GetComponent<CharacterMovement>();
            if (movement != null)
            {
                movement.score = GameManager.Instance.currentScore;
            }

            // Play the pickup sound through AudioManager, but only if no sound is currently playing
            if (pickupSound != null && AudioManager.Instance != null && AudioManager.Instance.CanPlayPickupSound())
            {
                AudioManager.Instance.PlayPickupSound(pickupSound);
                Debug.Log("Requested pickup sound");
            }
            else if (pickupSound != null && AudioManager.Instance == null)
            {
                Debug.LogError("AudioManager.Instance is null! Cannot play pickup sound.");
            }
            else
            {
                Debug.Log("Pickup sound skipped because another sound is playing.");
            }

            // Activate the pickup effect
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            // Disable the hover effect if present
            if (pickupMovement != null)
            {
                pickupMovement.StopHovering();
            }

            // Immediately hide the renderer and disable the collider
            if (pickupRenderer != null) pickupRenderer.enabled = false;
            if (pickupCollider != null) pickupCollider.enabled = false;

            // Move the object to an off-screen position
            transform.position = new Vector3(0, -1000, 0);

            // Start a coroutine to destroy the object after a small delay
            StartCoroutine(DestroyAfterEffect());

            // Debug log to verify the score update
            Debug.Log("Score Pickup collected! +50 points. Total Score: " + GameManager.Instance.currentScore);
        }
    }

    private IEnumerator DestroyAfterEffect()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}