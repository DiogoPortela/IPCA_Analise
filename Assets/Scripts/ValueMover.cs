using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueMover : MonoBehaviour {
    Vector2 posicaoDestino;
    bool startMoving = false;
    Transform thisTransform;

	void Start () {
        thisTransform = GetComponent<Transform>();
	}
	
	void Update () {
		if(startMoving)
        {
            thisTransform.position = Vector2.MoveTowards(thisTransform.position, posicaoDestino, 10 * Time.deltaTime);
        }
	}
}
