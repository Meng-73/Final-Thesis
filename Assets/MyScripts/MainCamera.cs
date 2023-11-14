using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//场景1、2，摄像机（鼠标拖拽、鼠标移动）

//鼠标拖拽——————————————————————————————————————————————————————————————————————

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



//鼠标移动旋转——————————————————————————————————————————————————————————


//public class ThirdPersonCamera : MonoBehaviour
//{
//    [SerializeField] private Transform m_target;                 // Reference to the player's transform
//    [SerializeField] private float m_distance = 5.0f;           // Distance from the player
//    [SerializeField] private float m_height = 2.0f;             // Height of the camera position
//    [SerializeField] private float m_smoothSpeed = 10.0f;       // Speed of camera movement

//    private float m_yaw;                // Current yaw rotation of the camera
//    private float m_pitch;              // Current pitch rotation of the camera

//    private void Start()
//    {
//        // Set initial yaw and pitch based on the camera's initial rotation
//        Vector3 angles = transform.eulerAngles;
//        m_yaw = angles.y;
//        m_pitch = angles.x;
//    }

//    private void LateUpdate()
//    {
//        // Get the mouse input for rotation
//        float mouseX = Input.GetAxis("Mouse X");
//        float mouseY = Input.GetAxis("Mouse Y");

//        // Update the yaw and pitch based on the mouse input
//        m_yaw += mouseX;
//        m_pitch -= mouseY;
//        m_pitch = Mathf.Clamp(m_pitch, -30f, 30f); // Clamp the pitch to a certain range

//        // Calculate the desired rotation of the camera
//        Quaternion rotation = Quaternion.Euler(m_pitch, m_yaw, 0f);

//        // Calculate the desired position of the camera
//        Vector3 targetPosition = m_target.position - rotation * Vector3.forward * m_distance;
//        targetPosition.y += m_height;

//        // Smoothly move the camera to the desired position and rotation
//        transform.position = Vector3.Lerp(transform.position, targetPosition, m_smoothSpeed * Time.deltaTime);
//        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, m_smoothSpeed * Time.deltaTime);
//    }
//}