using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{


    private Vector3 initialPosition;
    private float movementDistance = 0.2f;

    private bool isPressed = false;




    // Start is called before the first frame update
    void Start()
    {
        // Store the initial position of the button
        initialPosition = transform.position;



    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Apply movement only if the button is not already pressed
            if (!isPressed)
            {
                isPressed = true;
                transform.Translate(Vector3.down * movementDistance);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the colliding object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset the button position only if the button was previously pressed
            if (isPressed)
            {
                isPressed = false;
                transform.position = initialPosition;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
