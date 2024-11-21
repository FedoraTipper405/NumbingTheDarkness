using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<IObjectTouched>() != null)
        {
            collision.gameObject.GetComponent<IObjectTouched>().ObjectTouched();
        }
    }
}
