using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<Transform> waypoints;
    public float Speed;
    public int target;


    private void Update()
    {
        //Receiving Data
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, Speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        //Use data
        if (transform.position == waypoints[target].position)
        {
            if (target == waypoints.Count - 1)
            {
                target = 0;
            }
            else
            {
                target += 1;
            }
        }


    }


}