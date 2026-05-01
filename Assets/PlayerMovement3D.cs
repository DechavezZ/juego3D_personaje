using UnityEngine;

public class PlayerMovement3D : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private float timer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ);

        rb.linearVelocity = new Vector3(
            movement.x * speed,
            rb.linearVelocity.y,
            movement.z * speed
        );

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Score
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

        // Se agrega dificultad progresiva
        speed += Time.deltaTime * 1f;
    }
}