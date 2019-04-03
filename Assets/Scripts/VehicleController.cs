using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour {

    public WheelCollider wheel;

    Rigidbody rb;

    public float cog = 0;

    /// <summary>
    /// Propiedad privado 
    /// </summary>
    public float speed = 5;

    public Transform COG;

    public Transform visualWheel;

    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }

        }

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();

        COG.position = rb.centerOfMass = new Vector3(rb.centerOfMass.x, cog, rb.centerOfMass.z);

        wheel.motorTorque = speed;        
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 position;
        Quaternion rotation;

        //Obtiene la posición y la rotación de la rueda física 
        wheel.GetWorldPose(out position, out rotation);

        //Establece la posición y la rotación de la rueda visual 
        visualWheel.position = position;
        visualWheel.rotation = rotation; 

	}
}
