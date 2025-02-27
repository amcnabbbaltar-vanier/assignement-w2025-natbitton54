using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float hoverSpeed = 1f;
    public float hoverHeight = 0.2f;
    private Vector3 startPosition;
    private bool isHovering = true; // Flag to control hover behavior

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Hover up and down only if isHovering is true
        if (isHovering)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    // Method to disable the hover effect
    public void StopHovering()
    {
        isHovering = false;
    }

    // Method to resume hovering
    public void StartHovering()
    {
        isHovering = true;
    }
}
