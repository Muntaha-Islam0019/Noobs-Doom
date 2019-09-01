using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSInput : MonoBehaviour
{
    
    /* For Translate(), X co-ordinate moves from side-to-side,
       where, Z co-ordinate moves forward and backward.
    */
    
    public float speed = 6.0f;
    
    // Initializing the CharacterController component.
    private CharacterController _charController;
    
    // Start is called before the first frame update
    void Start()
    {
        _charController = GetComponent<CharacterController>();
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
        // transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        
        /* As, directly changing the objects transform does not apply collision detection,
           we're gonna use _charController. 
        */
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        
        /* Limiting diagonal movement same as axis movement, or, diagonal movement would have
           greater magnitude.
        */
        movement = Vector3.ClampMagnitude(movement, speed);
        
        // Scaling by deltaTime.
        movement *= Time.deltaTime;
        
        // Making local movement, global.
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}