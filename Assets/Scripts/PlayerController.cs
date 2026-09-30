using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance!=null && GameManager.Instance.isGameOver)
        {
            input = Vector2.zero;
            return;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        Vector2 newPosition = rb.position + input.normalized * moveSpeed * Time.fixedDeltaTime;

        rb.MovePosition(newPosition);
    }
}
