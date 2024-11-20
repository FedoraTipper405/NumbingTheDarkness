using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessMovement : MonoBehaviour
{
    public float DarknessSpeed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 DarkPos = new Vector2(DarknessSpeed,0);
        transform.position += (Vector3) DarkPos;
    }
}
