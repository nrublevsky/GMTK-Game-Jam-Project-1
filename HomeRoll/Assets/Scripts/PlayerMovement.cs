using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;

    public float rotationAngle;
    public float rotationSpeed;
    public float moveSpeed;

    public bool gameStarted;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        rotationAngle = 100f;
        rotationSpeed = 3f;
        moveSpeed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCube();
    }

    public void MoveCube()
    {
        
        gameStarted = true;
        if (gameStarted)
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerRb.transform.Rotate(Vector3.right * rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                playerRb.transform.Translate(Vector3.back * -moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerRb.transform.Rotate(Vector3.right * -rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                playerRb.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.W))
            {
                playerRb.transform.Rotate(Vector3.forward * rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                playerRb.transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRb.transform.Rotate(Vector3.forward * -rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                playerRb.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
            }
        }
    }
}
