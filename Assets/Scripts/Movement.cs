using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameObject[] Boids; //Array of all the boidss

    // Use this for initialization
    void Start()
    {
        //find all boids
        Boids = GameObject.FindGameObjectsWithTag("Boid");

    }

    // Update is called once per frame
    void Update()
    {
        MoveAllBoids(); 
    }


    //moves all the boids to new positions. 
    void MoveAllBoids()
    {
        Vector2 V1, V2, V3 = new Vector2();
      

        //need to assign boids
        foreach (GameObject boid in Boids)
        {
            //apply the rules to the boids
            V1 = Rule1(boid);
            V2 = Rule2(boid);
            V3 = Rule3(boid);

            //change velocity and position
            boid.GetComponent<Boid>().SetVelocity(boid.GetComponent<Boid>().GetVelocity + V1 + V2 + V3); 
            boid.transform.position = boid.transform.position + boid.GetComponent<Boid>().GetVelocity;
        }
    }

    //Rule 1 Boids fly towards the center of mass of neighbouring boids. 
    Vector2 Rule1(GameObject boid)
    {

        Vector3 ProjectedCenter = Vector3.zero;  

        foreach(GameObject b in Boids )
        {
            if(boid != b)
            {
                ProjectedCenter += boid.transform.position; 
            }
        }
        //set projected center 
        ProjectedCenter /= (Boids.Length - 1);
        ProjectedCenter.z = 0;
        return ProjectedCenter; 
    }

    //Boids try to keep a small distance away from other objects.
    Vector2 Rule2(GameObject boid)
    {
        Vector3 C = Vector3.zero; 

        foreach(GameObject b in Boids)
        {
            if(b != boid)
            {
                if(Vector2.Distance(b.transform.position,boid.transform.position) > 100)
                {
                    C = C - (b.transform.position - boid.transform.position); 
                }
            }
        }
        C.z = 0;
        return C; 
    }

    //Boids try to match velocity with near boids
    Vector2 Rule3(GameObject boid)
    {
        Vector2 ProjectedVelocity = Vector2.zero;

        foreach(GameObject b in Boids)
        {
            if(b != boid)
            {
                //    ProjectedVelocity += b.velocity; 
            }
        }
        ProjectedVelocity /= Boids.Length - 1; 


        return ProjectedVelocity; 
    }
}
