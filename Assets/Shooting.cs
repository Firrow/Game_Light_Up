using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;//Référence au firePoint (point de départ de la balle)
    public GameObject bullet;//Référence à l'objet balle

    public float bulletSpeed;//Crée la variable responsable de la vitesse de la balle

    // Update is called once per frame
    void Update()//Récupère les Inputs
    {

        if (Input.GetButtonDown("Fire1"))//Récupère l'input de Tir
        {
            Shoot();
        }
    }

    void Shoot()//Fonction appelée lors de l'input de tir
    {
        /*Crée une instance de balle et la range dans une variable, afin de la modifier après*/
        GameObject bulletInst = Instantiate(bullet, firePoint.position, firePoint.rotation);
        //Récupère le corps de la balle  et le range dans une variable afin de le modifier après
        Rigidbody2D rb = bulletInst.GetComponent<Rigidbody2D>();
        //Ajouter une force de type Impulse, égale à la vitesse de la balle et dans la direction du up vector de la balle
        //au corps de la balle
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

}
