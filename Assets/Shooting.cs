using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;//R�f�rence au firePoint (point de d�part de la balle)
    public GameObject bullet;//R�f�rence � l'objet balle

    public float bulletSpeed;//Cr�e la variable responsable de la vitesse de la balle

    // Update is called once per frame
    void Update()//R�cup�re les Inputs
    {

        if (Input.GetButtonDown("Fire1"))//R�cup�re l'input de Tir
        {
            Shoot();
        }
    }

    void Shoot()//Fonction appel�e lors de l'input de tir
    {
        /*Cr�e une instance de balle et la range dans une variable, afin de la modifier apr�s*/
        GameObject bulletInst = Instantiate(bullet, firePoint.position, firePoint.rotation);
        //R�cup�re le corps de la balle  et le range dans une variable afin de le modifier apr�s
        Rigidbody2D rb = bulletInst.GetComponent<Rigidbody2D>();
        //Ajouter une force de type Impulse, �gale � la vitesse de la balle et dans la direction du up vector de la balle
        //au corps de la balle
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

}
