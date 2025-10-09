using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator anim;
    private PlayerMovement2D playerMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && playerMovement.canAttack())
        {
            Attack();
            anim.SetTrigger("Attack");
        }
    }

    private void Attack()
    {

    }
}
