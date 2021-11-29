using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    private Shooting shoot;//Cr�e la r�f�rence au script Shooting du joueur

    void Awake()
    {
        shoot = gameObject.GetComponent<Shooting>();//R�cup�re le script Shooting du joueur
    }
    void OnCollisionEnter2D(Collision2D collision)//Se d�clenche quand le joueur touche quelque chose
    {
        
        /*V�rifie si le joueur a touch� une arme
        Si oui appelle la fonction changeWeapon de son script shooting
        pour changer les caract�ristique de l'arme �quip�e du joueur puis d�truit l'arme (l'instance de pickUp)*/
        if (collision.gameObject.tag == "BasicW" )
        {
            Sprite weapSprite = collision.transform.GetComponent<Sprite>();
            shoot.changeWeapon(8f, 0.4f, 0, 15, weapSprite);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Assaut")
        {
            Sprite weapSprite = collision.transform.GetComponent<Sprite>();
            shoot.changeWeapon(15f, 0.4f, 1, 30, weapSprite);
            Destroy(collision.gameObject);
            Debug.Log(weapSprite);
        }
        else if (collision.gameObject.tag == "Shotgun")
        {
            Sprite weapSprite = collision.transform.GetComponent<Sprite>();
            shoot.changeWeapon(13f, 0.6f, 2, 24, weapSprite);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "MachineGun")
        {
            Sprite weapSprite = collision.transform.GetComponent<Sprite>();
            shoot.changeWeapon(20f, 0.1f, 3, 150, weapSprite);
            Destroy(collision.gameObject);
        }

    }
}
