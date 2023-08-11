using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 100f, _thrust = 500f;
    public GameObject respawn;
    private bool isLanded = false;
    public bool isRightSide = true; //Если true, персонаж смотрит направо, а иначе — налево
    public bool isRun = false;
    public Animator animator;
    private Rigidbody2D _rb;
    private BoxCollider2D mainCollider;
    
    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isLanded to true
        isLanded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isLanded = true;
                    break;
                }
            }
        } 
        animator.SetBool("IsLanded", isLanded);       
    }

    private void Spin()
    {
        isRightSide = !isRightSide;
        transform.localScale = new Vector3(transform.localScale.x * -1, 1f, 1f);
    }

    private void Update() {
        float moveX = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveX)); //Будет передано только положительное значение

        if(Input.GetButtonDown("Jump") && isLanded){
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftShift) && isLanded){
            speed = 200f;
            isRun = true;
            animator.SetBool("IsRun", isRun);
        }else{
            if(isRun){
                speed = 100f;
                isRun = false;
                animator.SetBool("IsRun", isRun);
            }
        }
        
        _rb.velocity = transform.TransformDirection(new Vector2(moveX  * speed * Time.fixedDeltaTime, _rb.velocity.y));

        if((moveX > 0f && !isRightSide) || (moveX < 0f && isRightSide)) {
            if (moveX != 0f) //Если он не стоит
            {
                Spin (); //Вызов метода Spin()
            }
        }

        
    }

    private void Jump(){
        isLanded = false;
        animator.SetBool("IsLanded", isLanded);
        _rb.velocity = transform.TransformDirection(new Vector2(_rb.velocity.x, Mathf.Sqrt(2 * _thrust)));
    }
    
    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "DeadSpace"){
            transform.position = respawn.GetComponent<Transform>().position;
        }
    
        if(other.gameObject.name == "NextLvl"){
            SceneManager.LoadScene("Second");
        }

        if(other.gameObject.name == "FirstLvl"){
            SceneManager.LoadScene("First");
        }
    }
}
