using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX;
    public float speed = 3f;
    public float delta = 4f;

    bool moveInRight = true;

    private void Awake() {
        dirX = transform.position.x;
    }

    private void Update() {
        if(transform.position.x > dirX + delta){
            moveInRight = false;
        }else if (transform.position.x < dirX -delta){
            moveInRight = true;
        }

        if (moveInRight){
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }else{
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
