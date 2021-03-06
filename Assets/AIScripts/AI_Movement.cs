﻿using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    //Variables
    public Rigidbody2D AIBody;
    private SpriteRenderer AISprite;
    private GameObject cameraChk;
    public float AISpeed;

    // Use this for initialization
    void Start ()
    {
        AIBody = this.GetComponent<Rigidbody2D>();
        AIBody.velocity = new Vector2(AIBody.velocity.x, AIBody.velocity.y - 0.2f);
        cameraChk = GameObject.Find("Main Camera");
        AISprite = GetComponent<SpriteRenderer>();
        AISpeed = -3.0f;
        Physics2D.IgnoreLayerCollision(11, 10, true);
    }//end Start()

    private void OnCollisionEnter2D(Collision2D collisionOther)
    {
        if (collisionOther.gameObject.name != "Player")
        {
            AISpeed = -AISpeed;
        }//end if
    }//end OnCollisionEnter()

    // Update is called once per frame
    void Update ()
    {
        AIBody.velocity = new Vector2(AISpeed, AIBody.velocity.y);

        transform.eulerAngles = new Vector3(0, 0, 0);
        
        if (AISpeed > 0)
        {
            AISprite.flipX = true;
        }//end if
        else if (AISpeed < 0)
        {
            AISprite.flipX = false;
        }//end else if

        if((this.transform.position.x <= cameraChk.transform.position.x - 11 || this.transform.position.x > cameraChk.transform.position.x + 17.5f) && this.gameObject.name.Contains("Clone"))
        {
            Destroy(this.gameObject);
        }//end if
    }//end Update()
}//end class AI_Movement
