using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] rowPositions = new Transform[3]; // Positions in the row (X-axis)
    public Transform[] columnPositions = new Transform[3]; // Positions in the column (Y-axis)

    public float movementSpeed = 50f;
    public float rotationSpeed = 10f; // Velocidad de rotación para la animación de giro
    public float floatAmplitude = 0.1f; // Amplitud del movimiento de flotar (general)
    public float floatFrequency = 1f; // Frecuencia del movimiento de flotar

    private int currentRow = 1;
    private int currentColumn = 1;
    private bool isMoving = false;
    private Vector3 targetPosition;
    private Quaternion targetRotation; // Para almacenar la rotación objetivo al moverse
    private Vector3 initialLocalPosition; // Para el efecto de flotar

    void Start()
    {
        // Guardamos la posición local inicial para el efecto de flotar
        initialLocalPosition = transform.localPosition;
        targetRotation = transform.rotation; // Inicializamos la rotación objetivo con la actual
    }

    void Update()
    {
        if (!isMoving)
        {
            // Movimiento de flotar cuando no se está moviendo (ahora con offset diagonal)
            float offsetX = Mathf.Sin(Time.time * floatFrequency * 1.2f) * floatAmplitude * 0.5f; // Multiplicador para variar la frecuencia y amplitud
            float offsetY = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            float offsetZ = Mathf.Sin(Time.time * floatFrequency * 0.8f) * floatAmplitude * 0.3f; // Otro multiplicador para variar

            transform.localPosition = initialLocalPosition + new Vector3(offsetX, offsetY, offsetZ);

            // Resetea la rotación a la original cuando no se mueve
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * rotationSpeed);


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
            // Mueve y rota el jugador hacia la posición y rotación objetivo
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * movementSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            if (transform.position == targetPosition)
            {
                isMoving = false;
                // Una vez que llega a la posición, guarda la nueva posición local inicial para el flotar
                initialLocalPosition = transform.localPosition;
            }
        }
    }

    void MoveToPosition(Vector3 position, Vector3 direction)
    {
        targetPosition = position;
        isMoving = true;
        // Calcula la rotación objetivo basada en la dirección del movimiento
        if (direction != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(direction);
        }
    }

    void MoveLeft()
    {
        if (currentRow > 0)
        {
            currentRow--;
            Vector3 newPosition = new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z);
            MoveToPosition(newPosition, Vector3.left);
        }
    }

    void MoveRight()
    {
        if (currentRow < 2)
        {
            currentRow++;
            Vector3 newPosition = new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z);
            MoveToPosition(newPosition, Vector3.right);
        }
    }

    void MoveUp()
    {
        if (currentColumn < 2)
        {
            currentColumn++;
            Vector3 newPosition = new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z);
            MoveToPosition(newPosition, Vector3.up);
        }
    }

    void MoveDown()
    {
        if (currentColumn > 0)
        {
            currentColumn--;
            Vector3 newPosition = new Vector3(rowPositions[currentRow].position.x, columnPositions[currentColumn].position.y, transform.position.z);
            MoveToPosition(newPosition, Vector3.down);
        }
    }
}