using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int scoreAmount = 50; // Points to add when picked up
    public GameObject pickupEffect; // Particle effect prefab
    public AudioClip pickupSound; // Sound to play when the pickup is collected
    private AudioSource audioSource;
    private Renderer pickupRenderer;
    private Collider pickupCollider;

    void Start()
    {
        // Initialize the AudioSource component if it isn't already attached
        audioSource = GetComponent<AudioSource>();
        
        // Initialize the Renderer and Collider components
        pickupRenderer = GetComponent<Renderer>();
        pickupCollider = GetComponent<Collider>();

        // Check if pickupSound is assigned
        if (pickupSound == null)
        {
            Debug.LogError("Pickup sound is not assigned!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the current score (but don't save here)
            GameManager.Instance.currentScore += scoreAmount;

            // Update score in the CharacterMovement script
            CharacterMovement movement = other.GetComponent<CharacterMovement>();
            if (movement != null)
            {
                movement.score = GameManager.Instance.currentScore;
            }

            // Activate the pickup effect
            if (pickupEffect != null)
            {
                Instantiate(pickupEffect, transform.position, Quaternion.identity);
            }

            // Play the pickup sound if it's assigned
            if (pickupSound != null)
            {
                audioSource.PlayOneShot(pickupSound);
                Debug.Log("Played pickup sound");
            }
            else
            {
                Debug.LogWarning("No pickup sound assigned.");
            }

            // Hide the renderer and disable the collider instead of deactivating the object
            if (pickupRenderer != null) pickupRenderer.enabled = false;
            if (pickupCollider != null) pickupCollider.enabled = false;

            // Debug log to verify the score update
            Debug.Log("Score Pickup collected! +50 points. Total Score: " + GameManager.Instance.currentScore);
        }
    }
}
