using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject pickupTarget, objectoCarregado;   
    public int jumpForce, movementLimit, speed;
    public bool isCarring = false;

    Rigidbody2D thisRigidbody;
    SpriteRenderer thisSpriteRenderer;
    MeshRenderer thisRender;
    float horizontal, jump;


    void Start () {
        thisRigidbody = GetComponent<Rigidbody2D>();
        thisSpriteRenderer = GetComponent<SpriteRenderer>();
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
        if(thisRigidbody.velocity.x < 0 && horizontal < 0)
        {
            thisSpriteRenderer.flipX = true;
            pickupTarget.transform.localPosition = new Vector3(-Mathf.Abs(pickupTarget.transform.localPosition.x), pickupTarget.transform.localPosition.y, pickupTarget.transform.localPosition.z);
        }
        if (thisRigidbody.velocity.x > 0 && horizontal > 0)
        {
            thisSpriteRenderer.flipX = false;
            pickupTarget.transform.localPosition = new Vector3(Mathf.Abs(pickupTarget.transform.localPosition.x), pickupTarget.transform.localPosition.y, pickupTarget.transform.localPosition.z);
        }
        if(isCarring)
        {
            objectoCarregado.transform.position = pickupTarget.transform.position;
            objectoCarregado.GetComponent<CircleCollider2D>().enabled = false;
            if(Input.GetKeyDown(KeyCode.F))
            {
                isCarring = false;
                objectoCarregado.GetComponent<CircleCollider2D>().enabled = true;
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

    public void receberObjecto(GameObject obj)
    {
        objectoCarregado = obj;
        isCarring = true;
    }
}
