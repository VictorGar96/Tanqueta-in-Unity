using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController02 : MonoBehaviour {
    #region Inicialización de terminos

    /// <summary>
    /// Rigidbody
    /// </summary>
    Rigidbody rb;

    /// <summary>
    /// Center of Gravity
    /// </summary>
    public float cog = 0;

    /// <summary>
    /// Propiedad privado 
    /// </summary>
    float speed;

    /// <summary>
    /// Giro sobre su propio eje
    /// </summary>
    float steer;

    /// <summary>
    /// Lista de ruedas
    /// </summary>
    public List<GrupoMotor> ruedas;

    /// <summary>
    /// Center of Gravity
    /// </summary>
    public Transform COG;

    /// <summary>
    /// Velocidad máxima
    /// </summary>
    public float maxSpeed = 3000;

    /// <summary>
    /// Ángulo máximo
    /// </summary>
    const float maxAngle = 35;
    
    /// <summary>
    /// Velocidad
    /// </summary>
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

    #endregion

    void Start () {

        rb = GetComponent<Rigidbody>();

        COG.position = rb.centerOfMass = new Vector3(rb.centerOfMass.x, cog, rb.centerOfMass.z);
     
	}

    private void Update()
    {
        //Obtiene la velocidad del mando del usuario
        speed = Input.GetAxis("Vertical") * maxSpeed;

        //Obtiene la dirección del mando del usuario
        steer = Input.GetAxis("Horizontal") * maxAngle;
    }

    // Update is called once per frame
    void FixedUpdate () {

        foreach(GrupoMotor rueda in ruedas)
        {
            Vector3 position;
            Quaternion rotation;

            //Obtiene la posición y la rotación de la rueda física 
            rueda.ruedaFisica.GetWorldPose(out position, out rotation);

            //Establece la posición y la rotación de la rueda visual 
            rueda.ruedaVisual.position = position;
            rueda.ruedaVisual.rotation = rotation;

            //Establece la fuerza rotacional si procede
            if (rueda.esMotriz)
                rueda.ruedaFisica.motorTorque = speed;

            //Establece la dirección si procede
            if (rueda.esDirectriz)
                rueda.ruedaFisica.steerAngle = steer;
        }




    }
}

[System.Serializable]
/// <summary>
/// Agrupa una rueda físical y una visual
/// </summary>
public class GrupoMotor { 

    /// <summary>
    /// Referencia a la rueda física 
    /// </summary>
    public WheelCollider ruedaFisica;

    /// <summary>
    /// Referencia a la rueda visual 
    /// </summary>
    public Transform ruedaVisual;

    /// <summary>
    /// Indica si es una rueda motriz
    /// </summary>
    public bool esMotriz;

    /// <summary>
    /// Indica si es una rueda directriz
    /// </summary>
    public bool esDirectriz;
}
