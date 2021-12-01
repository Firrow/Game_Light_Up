using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Shooting))]//Ajoute automatiquement le script Shooting quand on ajoute ce script
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
        pour changer les caractéristique de l'arme équipée du joueur puis détruit l'arme (l'instance de pickUp)
        (vitesse de la balle, fireRate, numéro de l'arme, muntions, sprite, couleur (temp)*/
        if (collision.gameObject.tag == "BasicW" )
        {
            //Récupère la sprite du pick-up pour changer la sprite de l'arme joueur
            SpriteRenderer weapSpriteRend = collision.transform.GetComponent<SpriteRenderer>();
            shoot.changeWeapon(8f, 0.4f, 0, 15, weapSpriteRend.sprite, weapSpriteRend.color);//Changement de couleur TEMPORAIRE pour TEST
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Assaut")
        {
            //Récupère la sprite du pick-up pour changer la sprite de l'arme joueur
            SpriteRenderer weapSpriteRend = collision.transform.GetComponent<SpriteRenderer>();
            shoot.changeWeapon(15f, 0.4f, 1, 30, weapSpriteRend.sprite, weapSpriteRend.color);//Changement de couleur TEMPORAIRE pour TEST
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Shotgun")
        {
            //Récupère la sprite du pick-up pour changer la sprite de l'arme joueur
            SpriteRenderer weapSpriteRend = collision.transform.GetComponent<SpriteRenderer>();
            shoot.changeWeapon(10f, 0.6f, 2, 24, weapSpriteRend.sprite, weapSpriteRend.color);//Changement de couleur TEMPORAIRE pour TEST
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MachineGun")
        {
            //Récupère la sprite du pick-up pour changer la sprite de l'arme joueur
            SpriteRenderer weapSpriteRend = collision.transform.GetComponent<SpriteRenderer>();
            shoot.changeWeapon(20f, 0.1f, 3, 150, weapSpriteRend.sprite, weapSpriteRend.color);//Changement de couleur TEMPORAIRE pour TEST
            Destroy(collision.gameObject);
        }

    }
}
