using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public static int movespeed = 10;
    public Vector3 userDirection = Vector3.right;
    public Vector3 c_rot;
    public Vector3 anglesToRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Vector2 direction = new Vector3(Input.GetAxis("Horizontal"), 0);
        // float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Quaternion rotation = Quaternion.LookRotation(new Vector3(0, 0, Input.GetAxis("Horizontal")*90), Vector3.right);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, movespeed * Time.deltaTime);
        transform.position += transform.right * Time.deltaTime * movespeed;
    }

    
}
