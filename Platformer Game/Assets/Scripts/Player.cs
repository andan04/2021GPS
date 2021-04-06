using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float jumpPower = 8;
    private Rigidbody2D rig;
    private Animator anim;
    public Transform groundCheker;
    public float groundRadius = 0.25f;
    public LayerMask groundLayer;
    public bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetBool("IsAttack", true);
            SoundManager.instance.AttackSound();

            Collider2D col = Physics2D.OverlapCircle(transform.position, 2, (1 << LayerMask.NameToLayer("Enemy")));

            if(col != null)
            {
                col.GetComponent<Enemy>().Die();
                print(col.gameObject.name);
            }
            
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            anim.SetBool("IsAttack", false);
        }

        isGround = Physics2D.OverlapCircle(groundCheker.position, groundRadius, groundLayer);
    }

    void Jump()
    {
        if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && isGround)
        {
            rig.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isGround = false;
        }
    }
    void Move()
    {
        float posX = Input.GetAxis("Horizontal");
        if(posX != 0)
        {
            if(posX > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
        transform.Translate(Mathf.Abs(posX) * Vector3.right * moveSpeed * Time.deltaTime);
    }
}
