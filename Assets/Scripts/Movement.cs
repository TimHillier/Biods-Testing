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
        Vector2 V1, V2, V3, currentVelocity = new Vector2();
        Vector3 newVector3 = Vector3.zero; 
      

        //need to assign boids
        foreach (GameObject boid in Boids)
        {
            //apply the rules to the boids
            V1 = Rule1(boid);
            V2 = Rule2(boid);
            V3 = Rule3(boid);
            currentVelocity = boid.GetComponent<Boid>().GetVelocity();  //get current Velocity of the current Boid. 

            //change velocity and position

            boid.GetComponent<Boid>().SetVelocity(Vector2Add(currentVelocity, V1, V2,V3)); //why god? 
            currentVelocity = boid.GetComponent<Boid>().GetVelocity(); //i dont like this. 
            newVector3.x = currentVelocity.x;
            newVector3.y = currentVelocity.y;
            boid.transform.position = newVector3; 


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

    //**********************************************************
    //This will add 4 vectors together and return a new vector2
    //**********************************************************
    private Vector2 Vector2Add(Vector2 vectorA, Vector2 vectorB, Vector2 vectorC, Vector2 vectorD)
    {
        Vector2 ReturnVector;
        ReturnVector.x = vectorA.x + vectorB.x + vectorC.x + vectorD.x;
        ReturnVector.y = vectorA.y + vectorB.y + vectorC.y + vectorD.y;
        return ReturnVector; 
    }

}
