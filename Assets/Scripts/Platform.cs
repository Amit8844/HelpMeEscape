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
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, Speed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
        MovementFromOneWayPointtoAnother();

    }

    private void MovementFromOneWayPointtoAnother()
    {
        if (transform.position == waypoints[target].position)
        {
            WayPointsCount();
        }
    }

    private void WayPointsCount()
    {
        target = target == waypoints.Count - 1 ? 0 : 1;
      
    }

}