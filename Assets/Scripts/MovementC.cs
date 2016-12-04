using UnityEngine;
using System.Collections;

public class MovementC : MonoBehaviour {
    Rigidbody2D thisRigidbody;
    //Transform child;
    MeshRenderer thisRender;
    float horizontal, jump;
    public int jumpForce, movementLimit, speed;
    


	void Start () {
        thisRigidbody = GetComponent<Rigidbody2D>();

    }
	
	void Update () {
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Jump");
        if (horizontal != 0 || jump != 0)
        {
            if (thisRigidbody.velocity.x < movementLimit && thisRigidbody.velocity.x > -movementLimit)
            {
                Vector2 movement = new Vector2(horizontal * speed, 0);
                thisRigidbody.AddForce(movement);
                //thisRigidbody.position = new Vector2(thisRigidbody.position.x + horizontal * speed * Time.deltaTime, thisRigidbody.position.y);
                //thisRigidbody.AddForce(new Vector2(horizontal * speed * Time.deltaTime, 0));
                //thisRigidbody.AddForce(new Vector2(0, jump * jumpForce));
            }
            if(thisRigidbody.velocity.y < movementLimit)
            {
                Vector2 movement = new Vector2(0, jump * jumpForce);
                thisRigidbody.AddForce(movement);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform")
        {
            thisRender = other.gameObject.GetComponent<MeshRenderer>();
            thisRender.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Platform" && !other.gameObject.GetComponent<NumberReceptor>().isOn )
        {
            thisRender = other.gameObject.GetComponent<MeshRenderer>();
            thisRender.enabled = false;
        }
    }

}
