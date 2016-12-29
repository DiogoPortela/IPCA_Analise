using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    public GameObject pickupTarget, carryTarget, objectoCarregado;   
    public int jumpForce, movementLimit, speed, linearDrag;
    public bool isCarring = false, isFlying;

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
        if (thisRigidbody.velocity.y == 0)
        {
            isFlying = false;
        }
        if (Mathf.Abs(horizontal) == 1 || jump == 1)
        {
            if (thisRigidbody.velocity.x < movementLimit && thisRigidbody.velocity.x > -movementLimit)
            {
                Vector2 movement = new Vector2(horizontal * speed, 0);
                thisRigidbody.AddForce(movement);
            }
            if(thisRigidbody.velocity.y < movementLimit)
            {
                Vector2 movement = new Vector2(0, jump * jumpForce);
                thisRigidbody.AddForce(movement);
            }
            if(jump == 1)
            {
                isFlying = true;;
            }
            thisRigidbody.drag = 0;
        }
        else if(!isFlying)
        {
            thisRigidbody.drag = linearDrag;
        }
        if(thisRigidbody.velocity.x < 0 && horizontal < 0)
        {
            thisSpriteRenderer.flipX = true;
            pickupTarget.transform.localPosition = new Vector3(-Mathf.Abs(pickupTarget.transform.localPosition.x), pickupTarget.transform.localPosition.y, pickupTarget.transform.localPosition.z);
            carryTarget.transform.localPosition = new Vector3(-Mathf.Abs(carryTarget.transform.localPosition.x), carryTarget.transform.localPosition.y, carryTarget.transform.localPosition.z);

        }
        if (thisRigidbody.velocity.x > 0 && horizontal > 0)
        {
            thisSpriteRenderer.flipX = false;
            pickupTarget.transform.localPosition = new Vector3(Mathf.Abs(pickupTarget.transform.localPosition.x), pickupTarget.transform.localPosition.y, pickupTarget.transform.localPosition.z);
            carryTarget.transform.localPosition = new Vector3(Mathf.Abs(carryTarget.transform.localPosition.x), carryTarget.transform.localPosition.y, carryTarget.transform.localPosition.z);

        }
        if (isCarring && objectoCarregado != null)
        {
            objectoCarregado.transform.position = carryTarget.transform.position;
            StartCoroutine(carregarObjecto());
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
    IEnumerator carregarObjecto()
    {
       // objectoCarregado.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSecondsRealtime(0.5f);
        if (Input.GetKeyUp(KeyCode.E) && objectoCarregado != null)
        {
            isCarring = false;
            objectoCarregado.GetComponent<Rigidbody2D>().isKinematic = false;
            //objectoCarregado.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
    IEnumerator movimento()
    {
        if (thisRigidbody.velocity.x < movementLimit && thisRigidbody.velocity.x > -movementLimit)
        {
            Vector2 movement = new Vector2(horizontal * speed, 0);
            thisRigidbody.AddForce(movement);
        }
        if (thisRigidbody.velocity.y < movementLimit)
        {
            Vector2 movement = new Vector2(0, jump * jumpForce);
            thisRigidbody.AddForce(movement);
        }
        yield return new WaitForSecondsRealtime(0.5f);
    }

    public void receberObjecto(GameObject obj)
    {
        objectoCarregado = obj;
        objectoCarregado.GetComponent<Rigidbody2D>().isKinematic = true;
        isCarring = true;
    }
}
