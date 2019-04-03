using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    /// <summary>
    /// Vida del objeto
    /// </summary>
    public int maxhealth = 100;  

    // Use this for initialization
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// Función, resta damage, a su vida, si maxhealth es menor o igual que cero, destruirá el objeto
    /// </summary>
    /// <param name="damage"></param>
    public void DamageTaken(int damage)
    {

        maxhealth -= damage;

        if (maxhealth <= 0)
            Destroy(gameObject);

    }
}