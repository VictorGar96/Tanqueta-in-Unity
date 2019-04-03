using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour {
    #region Inicialización de terminos

    /// <summary>
    /// Velocidad de rotación en el eje X
    /// </summary>
    public float rotationSpeed = 10;
    
    /// <summary>
    /// Velocidad de rotación en el eje y
    /// </summary>
    public float elevationSpeed = 5;

    /// <summary>
    /// Transform para acceder al hijo
    /// </summary>
    Transform tran;

    #endregion

    // Use this for initialization
    void Start () {

        //Al empezar accedemos al hijo para coger la rotacíón en el eje Y
        tran = transform.GetChild(0).transform;
             
    }
	
	// Update is called once per frame
	void Update () {

        //Comprueba el eje en el que estás moviendo la torreta y solo te permite mover en un eje.
        if (Mathf.Abs(Input.GetAxis("Mouse X")) > Mathf.Abs(Input.GetAxis("Mouse Y")))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);
        }
        else
            tran.Rotate(Input.GetAxis("Mouse Y") * elevationSpeed, 0, 0);
	}
}
