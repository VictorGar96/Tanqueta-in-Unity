using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

    /// <summary>
    /// Daño de cada impacto de la bala
    /// </summary>
    public int damage = 25;

	// Use this for initialization
	void Start () {
        //con un invoke llamamos a la función DestroyBullet para que destruya el objeto bala, al cabo de 3 segundos
        Invoke("DestroyBullet", 3);

    }
	
	// Update is called once per frame
	void Update () {
       

    }

    /// <summary>
    /// Función que destuye el objeto
    /// </summary>
    void DestroyBullet() {

        //gameObject.SetActive(false);
        Destroy(this.gameObject);

    }

    /// <summary>
    /// Cuando colisiona con otro objeto
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //Accedemos a la variable maxHealth del script health
        Health maxhealth = collision.gameObject.GetComponent<Health>();

        //Si maxHealth es distinto de null, restamos damage a maxhealth
        if (maxhealth != null)
            maxhealth.DamageTaken(damage);
    }

}
