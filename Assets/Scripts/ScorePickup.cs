using UnityEngine;

public class ScorePickup : MonoBehaviour
{
    public int scoreAmount = 50; // Points to add when picked up
    public GameObject pickupEffect; // Particle effect prefab

    void Start()
    {
        // Ensure the pickup effect is inactive when the game starts
        if (pickupEffect != null)
        {
            pickupEffect.SetActive(false);
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

            // Disable the pickup object
            gameObject.SetActive(false);

            // Debug log to verify the score update
            Debug.Log("Score Pickup collected! +50 points. Total Score: " + GameManager.Instance.currentScore);
        }
    }
}
