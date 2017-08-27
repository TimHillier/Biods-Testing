using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    private int speed; //how fast the boid is moving. 
    private Vector2 velocity;



    //set Velocity to the rigid body velocity
    void Start()
    {
        velocity = GetComponent<Rigidbody2D>().velocity; 
    }



    //**********************************
    //Get and set Speed of the Boid
    //**********************************

    public void SetSpeed(int s)
    {
        speed = s;
    }
    public int GetSpeed()
    {
        return speed; 
    }
    //**********************************
    //Get and set Velocity of the Boid
    //**********************************

    public void SetVelocity(Vector2 Vel)
    {
        velocity = Vel;
    }
    public Vector2 GetVelocity()
    {
        return velocity; 
    }
}
