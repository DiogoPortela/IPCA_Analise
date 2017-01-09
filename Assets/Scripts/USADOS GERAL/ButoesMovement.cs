using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButoesMovement : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("isStanding", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            this.gameObject.GetComponent<Animator>().SetBool("isStanding", false);
        }
    }
}
