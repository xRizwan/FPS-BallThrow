using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100.0f;
    public Transform playerBody;
    private GameManager gameManager;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -45, 45);

            transform.localRotation = Quaternion.Euler(xRotation, transform.rotation.y, transform.rotation.z);
            playerBody.Rotate(Vector3.up * mouseX);
        } 
    }
}
