using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody2D rb;  
    private Animator anim;
    private bool Grounded; // untuk mengecek apakah pemain berada di tanah
    private Vector2 movement;

    private void Start()
    {
        // Mendapatkan komponen Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
        // Mendapatkan komponen Animator
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        movement.x = horizontalInput;
        movement.y = rb.velocity.y; // biarkan vertikal diatur oleh fisika

        rb.velocity = new Vector2(movement.x * moveSpeed, movement.y);

        // Mengatur arah pemain berdasarkan input horizontal
        if(horizontalInput > 0.01f){
            transform.localScale = new Vector3(1, 1, 1); // menghadap kanan
        }
        else if(horizontalInput < -0.01f){
            transform.localScale = new Vector3(-1, 1, 1); // menghadap kiri
        }

        // Cek apakah pemain menekan tombol lompat
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", Grounded);
    }

    void Jump()
    {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Grounded = false; // set Grounded ke false saat melompat
            anim.SetTrigger("Jump"); // trigger animasi loncat jika pakai trigger   
                 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Grounded = false;
        }
    }

    public bool canAttack()
    {
        return movement.x == 0 && Grounded;
    }
   
}