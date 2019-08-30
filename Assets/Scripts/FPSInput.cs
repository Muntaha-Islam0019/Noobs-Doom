using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    
    /* For Translate(), X co-ordinate moves from side-to-side,
       where, Z co-ordinate moves forward and backward.
    */
    
    public float speed = 6.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        
        /* Making it frame rate independent by scaling it by deltaTime.
           Now, it'll run on same speed on every monitor. Here, deltaTime is the amount of time
           between frames. For instance, 30FPS monitors have 1/30 second as deltaTime. That's how it's
           scaled.
        */
        transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
    }
}