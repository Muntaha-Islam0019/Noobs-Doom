using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    
    // Checking if the object is alive or not.
    private bool _alive;
    
    // How far the object will stay from an object.
    public float obstacleRange = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update, only if the object is alive.
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        
            // Generating a ray to forward of the object.
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hit;
        
            /*
             * Casting a ray consisting an area of sphere, as, this will help the object to find out if there
             * is an object in front of it. ScreenPointToRay could be used, though, then it'd cause problem
             * for certain objects.
             */
            
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                { 
                    /*
                     * If the object finds another object in front of it, it'd move towards
                     * a random angle.
                     */
                    
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void setLife (bool life)
    {
        _alive = life;
    }
}