using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float Speed;
    private float horizontalInput;
    private float verticalInput;
    
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector2.up * Time.deltaTime * verticalInput * Speed);
        transform.Translate(Vector2.right * Time.deltaTime * horizontalInput * Speed);
    }
}
