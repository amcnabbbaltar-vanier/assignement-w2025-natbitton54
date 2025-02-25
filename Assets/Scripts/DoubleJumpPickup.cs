using System.Collections;
using UnityEngine;

public class DoubleJumpPickup : MonoBehaviour
{
    private float rotateSpeed = 50f;
    public float height = 2f;
    private Vector3 startPos;
    public float powerUpDuration = 30f;
    public GameObject pickupEffect; 

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
            StartCoroutine(other.gameObject.GetComponent<PlayerPickupManager>().DoubleJumpPickup(other,pickupEffect,powerUpDuration));
            // gameObject.SetActive(false);
        }
    }

    
}
