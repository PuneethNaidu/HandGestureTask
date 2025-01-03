using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndChangeColor : MonoBehaviour
{
    [SerializeField]
    private Material redMaterial; // Red color material

    [SerializeField]
    private Material greenMaterial; // Green color material

    [SerializeField]
    private float rotationAngle = 45f; // Rotation angle for each function call

    private Renderer objectRenderer; // Renderer of the GameObject

    private void Start()
    {
        // Get the Renderer component of the GameObject
        objectRenderer = GetComponent<Renderer>();
    }

    public void LeftRotateAndSetRed()
    {
        // Change material to red if it is assigned
        if (redMaterial != null)
        {
            objectRenderer.material = redMaterial;
        }
        // Rotate the GameObject
        transform.Rotate(0, rotationAngle, 0);
    }

    public void RightRotateAndSetGreen()
    {
        // Change material to green if it is assigned
        if (greenMaterial != null)
        {
            objectRenderer.material = greenMaterial;
        }
        // Rotate the GameObject
        transform.Rotate(0, -rotationAngle, 0);
    }
}
