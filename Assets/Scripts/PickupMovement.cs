using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float hoverSpeed = 1f;
    public float hoverHeight = 0.2f;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // rotate around y axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // hover up and down
        float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
