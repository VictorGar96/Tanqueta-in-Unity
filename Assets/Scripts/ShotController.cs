using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    #region

    /// <summary>
    /// curva de animación que controla el retroceso del disparo
    /// </summary>
    public AnimationCurve shotAnim;

    /// <summary>
    /// Posición donde se instancia la bala
    /// </summary>
    public Transform balaSpawn;

    /// <summary>
    /// Cámara del jugador
    /// </summary>
    public Transform playerCamera;

    /// <summary>
    /// GameObject de la bala
    /// </summary>
    public GameObject bulletPrefab;

    /// <summary>
    /// Dirección de disparo
    /// </summary>
    Vector3 shotDirection = Vector3.zero;

    /// <summary>
    /// Tiempo de la animación
    /// </summary>
    public float animTime = 0.5f;

    /// <summary>
    /// Cantidad de retroceso
    /// </summary>
    public float recoil = 2;

    /// <summary>
    /// Firing Rate
    /// </summary>
    [Range(0.1f, 1)]
    public float firingRate = 0.5f;

    /// <summary>
    /// Velocidad de la bala
    /// </summary>
    public float shootSpeed = 25;

    /// <summary>
    /// Bool, indica si se puede disparar
    /// </summary>
    bool canShot = true;
       
    #endregion

    // Use this for initialization
    void Start () {

        if (firingRate < animTime)
            animTime = firingRate;

	}
	
	// Update is called once per frame
	void Update () {

        if (canShot && Input.GetButtonDown("Fire1")) {

            canShot = false;

            //Instancia el objeto que vamos a disparar, en este caso la bala, una vez instaciado el objeto se le añade una fuerza de impulso
            GameObject bullet = (GameObject)Instantiate(bulletPrefab, balaSpawn.position, Quaternion.identity);
            shotDirection = balaSpawn.position - playerCamera.position;
            bullet.GetComponent<Rigidbody>().AddForce(shotDirection * shootSpeed, ForceMode.Impulse);

            //Llamamos a las corrutinas que controlan la animación de la cámara y la cadencia de disparo
            StartCoroutine(RecoilAnim());
            StartCoroutine(FiringRateTime());           

        }
        
	}
    /// <summary>
    /// Animación de retroceso al disparar 
    /// </summary>
    /// <returns></returns>
    IEnumerator RecoilAnim()
    {
        float time = 0;
        Vector3 PositionCamera = playerCamera.localPosition;

        while (time < animTime) {

            playerCamera.localPosition = PositionCamera - (transform.InverseTransformDirection(shotDirection) * shotAnim.Evaluate(time));
            time += Time.deltaTime;
            yield return 0;
        }

        playerCamera.localPosition = PositionCamera;
        
    }

    /// <summary>
    /// Cadencia de disparo
    /// </summary>
    /// <returns></returns>
    IEnumerator FiringRateTime() {

        float rateTiempo = firingRate;
            
        while (rateTiempo > 0) {

            rateTiempo -= Time.deltaTime;
            yield return 0;
        }

        canShot = true;


    }


}








