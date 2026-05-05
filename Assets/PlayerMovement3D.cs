using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public float forwardSpeed = 5f;

    private Rigidbody rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimiento lateral
        float moveX = Input.GetAxis("Horizontal");

        Vector3 velocity = rb.linearVelocity;

        velocity.x = moveX * speed;

        // Movimiento automático hacia adelante
        velocity.z = forwardSpeed;

        rb.linearVelocity = velocity;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Sistema de score
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            GameManager gm = FindFirstObjectByType<GameManager>();

            if (gm != null)
            {
                gm.SumarPunto();
            }

            timer = 0f;
        }

        // Dificultad progresiva
        forwardSpeed += Time.deltaTime * 0.05f;
    }
}