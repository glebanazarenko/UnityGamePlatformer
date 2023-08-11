using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Derevo : MonoBehaviour
{
  
public float speed = 100f, _thrust = 500f;

    private Rigidbody2D _rb;
    public GameObject respawn;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {

        float h = Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        if(Input.GetKeyDown(KeyCode.Space)){
            _rb.AddForce(transform.up * _thrust);
        }
        _rb.velocity = transform.TransformDirection(new Vector2(h, _rb.velocity.y));
    }
    
    void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.name == "DeadSpace"){
            transform.position = respawn.GetComponent<Transform>().position;
        }
    
        if(other.gameObject.name == "NextLvl"){
            SceneManager.LoadScene("Second");
        }

        if(other.gameObject.name == "FirstLvl"){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
