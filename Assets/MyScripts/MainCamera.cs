using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//scene 1 2 camera movement


public class MainCamera : MonoBehaviour
{



    [SerializeField] private Transform m_target;                 // Reference to the player's transform
    [SerializeField] private float m_distance = 5.0f;           // Distance from the player
    [SerializeField] private float m_height = 2.0f;             // Height of the camera position
    [SerializeField] private float m_rotationSpeed = 1.5f;       // Speed of camera rotation

    private float m_yaw;                // Current yaw rotation of the camera
    private float m_pitch;              // Current pitch rotation of the camera





    // Start is called before the first frame update
    void Start()
    {



        // Set initial yaw and pitch based on the camera's initial rotation
        Vector3 angles = transform.eulerAngles;
        m_yaw = angles.y;
        m_pitch = angles.x;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Get the mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Update the yaw and pitch based on the mouse movement
            m_yaw += mouseX * m_rotationSpeed;
            m_pitch -= mouseY * m_rotationSpeed;
            m_pitch = Mathf.Clamp(m_pitch, -90f, 90f); // Clamp the pitch to a certain range
        }

        // Calculate the desired rotation of the camera
        Quaternion rotation = Quaternion.Euler(m_pitch, m_yaw, 0f);

        // Calculate the desired position of the camera
        Vector3 targetPosition = m_target.position - rotation * Vector3.forward * m_distance;
        targetPosition.y += m_height;

        // Set the position and rotation of the camera
        transform.position = targetPosition;
        transform.rotation = rotation;
    }
}


