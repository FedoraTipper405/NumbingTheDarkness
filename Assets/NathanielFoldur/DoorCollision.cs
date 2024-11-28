using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorCollision : MonoBehaviour
{
    public UnityEvent DoorCollided;
    private bool CanBeOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetOpenState(bool newOpen)
    {
        CanBeOpened = newOpen;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && CanBeOpened)
        {
            DoorCollided.Invoke();
        }
    }
}
