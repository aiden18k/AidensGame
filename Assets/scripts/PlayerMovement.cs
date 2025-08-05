using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
private Rigidbody2D rb;
private int jumpForce = 20;
private Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    
    void Update()
    {
        // Get input
        movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

   if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("jump!");
             rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D Other){
        if(Other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        }
}

