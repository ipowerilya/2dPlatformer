using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMove : MonoBehaviour
{
    public bool forward;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(forward)
        {
            PositionForward(); 
        }
    }
    public void makeForward()
    {
        if(forward)
        {
            forward = false;
        }
        else
        {
            forward = true;
        }
    }
    public void PositionForward()
    {
        transform.Translate(0f, 0f, 1 * Time.deltaTime);
    }
}
