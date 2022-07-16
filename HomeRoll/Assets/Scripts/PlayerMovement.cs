using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;

    public float rotationAngle;
    public float rotationSpeed;
    public float moveSpeed;

    public bool isMoving;

    public bool gameStarted;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        rotationAngle = 100f;
        rotationSpeed = 3f;
        moveSpeed = 8f;
        isMoving = false;
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
            if (!isMoving)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    StartCoroutine(Move(Vector3.right,-Vector3.back));
                    //playerRb.transform.Rotate(Vector3.right * rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                    //playerRb.transform.Translate(Vector3.back * -moveSpeed * Time.deltaTime, Space.World);

                }
                if (Input.GetKey(KeyCode.A))
                {
                    StartCoroutine(Move(-Vector3.right, Vector3.back));
                    //playerRb.transform.Rotate(Vector3.right * -rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                    //playerRb.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime, Space.World);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    StartCoroutine(Move(Vector3.forward, -Vector3.right));
                    //playerRb.transform.Rotate(Vector3.forward * rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                    //playerRb.transform.Translate(Vector3.right * -moveSpeed * Time.deltaTime, Space.World);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    StartCoroutine(Move(-Vector3.forward, Vector3.right));
                    //playerRb.transform.Rotate(Vector3.forward * -rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
                    //playerRb.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime, Space.World);
                }
            }
        }
    }

    public void MoveInDirection(Vector3 rotationDirection, Vector3 movementDirection)
    {
        playerRb.transform.Rotate(rotationDirection * rotationAngle * rotationSpeed * Time.deltaTime, Space.World);
        playerRb.transform.Translate(movementDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    public IEnumerator Move(Vector3 rotationDirection, Vector3 movementDirection)
    {
        isMoving = true;
    
        while (isMoving)
        {
            MoveInDirection(rotationDirection,movementDirection);
            yield return null;
        }
        isMoving = false;

    }
}
