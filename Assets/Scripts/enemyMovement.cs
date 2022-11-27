using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    Rigidbody2D myRigd;
    // Start is called before the first frame update
    void Start()
    {
        myRigd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigd.velocity = new Vector2(moveSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D other)


    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }
    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigd.velocity.x)), 1);
    }

}
