using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour {

	public void Interact()
    {
        gameObject.SetActive(false);
        Debug.Log(gameObject.name);
    }
}
