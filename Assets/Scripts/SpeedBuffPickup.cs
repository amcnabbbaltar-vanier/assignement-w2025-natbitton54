using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuffPickup : MonoBehaviour
{
    public float powerUpDuration = 15f;
    public float speedMultiplier = 2.2f;
    public GameObject pickupEffect;
    private Renderer pickupRenderer;
    private Collider pickupCollider;

    void Start()
    {
        pickupRenderer = GetComponent<Renderer>();
        pickupCollider = GetComponent<Collider>();

    }
    void OnTriggerEnter(Collider other)
    {
          PlayerPickupManager pickupManager = other.gameObject.GetComponent<PlayerPickupManager>();
            if (pickupManager != null)
            {
                // Start the power-up effect but do NOT tie the pickup object's state to it
                StartCoroutine(pickupManager.SpeedPickup(other, pickupEffect, powerUpDuration, speedMultiplier));

                if(pickupRenderer != null) pickupRenderer.enabled = false;
                if(pickupCollider != null) pickupCollider.enabled = false;
            }
    }
}
