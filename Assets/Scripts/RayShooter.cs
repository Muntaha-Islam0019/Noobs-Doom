using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class RayShooter : MonoBehaviour
{
    // Creating a camera object to hold the main camera.
    private Camera _camera;

    // private int _counter_of_hit = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        // Getting the main camera.
        _camera = GetComponent<Camera>();

        // Making the mouse cursor invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the first mouse button(LMB) is tapped down:
        if (Input.GetMouseButtonDown(0))
        {
            // Getting the mid point of the screen whats basically the width/2 and height/2. 
            Vector3 point = new Vector3(_camera.pixelWidth/2,  _camera.pixelHeight/2, 0);
            
            // Method of Unity Script to configure raycasting.
            Ray ray = _camera.ScreenPointToRay(point);

            // Datatype what deals with intersections of the ray.
            RaycastHit hit;

            /*
                'out' ensures that the data structure manipulated within the command is the same
                object that exists outside the command. 
            */
            if (Physics.Raycast(ray, out hit))
            {
                // Checking if the ray hits at which point.
                // Debug.Log("Hit: " + hit.point);

                // Coroutines does a job after with pauses indicated by the developer. 
                // Create an object and deletes it afterwards.
                
                // The object that was hit.
                GameObject hitGameObject = hit.transform.gameObject;
                
                // For checking if the target has ReactiveTarget component.
                ReactiveTarget target = hitGameObject.GetComponent<ReactiveTarget>();

                if (target != null)
                {
                    // Debug.Log("Hit! " + ++_counter_of_hit);
                    target.react_to_hit();
                }
                else
                {
                    StartCoroutine(HitIndicator(hit.point));
                }
            }
        }
    }

    // Creating an aiming cursor.
    private void OnGUI()
    {
        int size = 12;
        
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        
        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private IEnumerator HitIndicator(Vector3 position)
    {
        // Creates a sphere to indicate where the user have shot.
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;
        
        // Tells the coroutine to wait of 1 secs and then destroy the object.
        yield return new WaitForSeconds(1);
        
        /*
         * Destroy tells the game engine that remove this object from the scene graph. Though, it
         * still remains in the memory. sphere would still be null.
         */
        Destroy(sphere);
    }
}
