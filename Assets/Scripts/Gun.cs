using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject Bullet ;
    public float launchForce;
    public Transform shotPoint;
    [SerializeField] private AudioSource _Shoot;

    //points
    public GameObject point;
    GameObject[] points;
    public int numOfpoints;
    public float spaceBetweenPoints;

    Vector2 direction;

    private void Start()
    {
        

        points = new GameObject[numOfpoints];
        for (int i = 0; i < numOfpoints; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity);
        }

       
    }



    // Update is called once per frame
    void Update()
    {

        


        Vector2 gunPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition);
        direction = mousePosition - gunPosition;
        transform.up = direction;

        if(Input.GetMouseButtonDown(0) && BulletText.bulletAmount > 0)
        {
            _Shoot.Play();
            Shoot();
        }

        for (int i = 0; i < numOfpoints; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints);
        }
    }

    void Shoot()
    {
        

        GameObject newBullet =  Instantiate(Bullet, shotPoint.position, shotPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.up * launchForce;
        BulletText.bulletAmount -= 1;
        
    }

   

    Vector2 PointPosition(float t)
    {
        //Formulae :- Position = StartingPos + StartingVelocity * t + 0.5 * Acceleration * (t * t)

        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t*t);
        return position;
    }

}
