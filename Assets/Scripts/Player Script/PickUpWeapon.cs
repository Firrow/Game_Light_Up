using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private Shooting shoot;//Crée la référence au script Shooting du joueur

    void Awake()
    {
        shoot = gameObject.GetComponent<Shooting>();//Récupère le script Shooting du joueur
    }
    void OnCollisionEnter2D(Collision2D collision)//Se déclenche quand le joueur touche quelque chose
    {
        
        /*Vérifie si le joueur a touché une arme
        Si oui appelle la fonction changeWeapon de son script shooting
        pour changer les caractéristique de l'arme équipée du joueur puis détruit l'arme (l'instance de pickUp)*/
        if (collision.gameObject.tag == "BasicW" )
        {
            shoot.changeWeapon(8f, 0.4f, 0, 15);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Assaut")
        {
            shoot.changeWeapon(15f, 0.4f, 1, 30);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Shotgun")
        {
            shoot.changeWeapon(13f, 0.6f, 2, 24);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MachineGun")
        {
            shoot.changeWeapon(20f, 0.1f, 3, 150);
            Destroy(collision.gameObject);
        }

    }
}
