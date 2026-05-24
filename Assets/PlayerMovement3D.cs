using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float forwardSpeed = 8f;

    public float sideSpeed = 5f;

    public float jumpForce = 5f;

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

        // Movimiento automático hacia adelante
        Vector3 velocity = rb.linearVelocity;

        velocity.x = moveX * sideSpeed;

        velocity.z = forwardSpeed;

        rb.linearVelocity = new Vector3(
            velocity.x,
            rb.linearVelocity.y,
            velocity.z
        );

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(
                Vector3.up * jumpForce,
                ForceMode.Impulse
            );
        }

        // Score automático
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            GameManager gm =
                FindFirstObjectByType<GameManager>();

            if (gm != null)
            {
                gm.SumarPunto();
            }

            timer = 0f;
        }
    }
}