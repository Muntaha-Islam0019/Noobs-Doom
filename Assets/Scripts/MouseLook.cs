using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    /*For better understanding, please read about Euler angles and quaternions.
      Though, it's not needed to work in unity, but, practical knowledge without theoretical knowledge,
      is simply garbage with sweet scent.*/

    /*Need to revise the concepts of enum for more proficiency.*/
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 9.0f;
    public float sensitivityY = 9.0f;

    public float minimumVertical = -45.0f;
    public float maximumVertical = 45.0f;

    /*It's a goof practice in unity script to put a '_' in front of private variables.*/
    private float _rotationX = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            /*The reason of adding a horizontal rotation in yAngle is, the rotation works like
              aeronautics: pitch (rotating around x), yaw (rotating around y) and roll (rotating
              around z).*/
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
            /*Rotate increments the rotation values from the current ones, and that's okay horizontally.*/
        }
        else if (axes == RotationAxes.MouseY)
        {
            /*Subtracting the input value from horizontal rotation angle.*/
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityY;
            _rotationX = Mathf.Clamp(_rotationX, minimumVertical, maximumVertical);

            /*Keeping the same y angle.*/
            float rotationY = transform.localEulerAngles.y;
            
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            
        }
    }
}
