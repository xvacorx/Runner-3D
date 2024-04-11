using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] rowPositions = new Transform[3]; // Positions in the row (X-axis)
    public Transform[] columnPositions = new Transform[3]; // Positions in the column (Y-axis)

    float movementSpeed = 50f;

    private int currentRow = 1;
    private int currentColumn = 1;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (!isMoving)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0)
            {
                if (horizontalInput > 0) { MoveRight(); }
                else { MoveLeft(); }
            }
            else if (verticalInput != 0)
            {
                if (verticalInput > 0) { MoveUp(); }
                else { MoveDown(); }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    void MoveToPosition(Vector3 position)
    {
        targetPosition = position;
        isMoving = true;
    }

    void MoveLeft()
    {
        if (currentRow > 0)
        {
            currentRow--;
            MoveToPosition(new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z));
        }
    }

    void MoveRight()
    {
        if (currentRow < 2)
        {
            currentRow++;
            MoveToPosition(new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z));
        }
    }

    void MoveUp()
    {
        if (currentColumn < 2)
        {
            currentColumn++;
            MoveToPosition(new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z));
        }
    }

    void MoveDown()
    {
        if (currentColumn > 0)
        {
            currentColumn--;
            MoveToPosition(new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z));
        }
    }
}