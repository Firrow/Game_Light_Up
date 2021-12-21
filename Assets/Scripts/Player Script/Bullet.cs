using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*A impl�menter*/
    public GameObject hitEffect;//R�f�rence � l'effet � jouer quand la balle touche quelque chose

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)//Se d�clenche quand la balle touche quelque chose
    {
        /*Si la balle entre en collision avec un obstacle, un ennemi ou un alli� effectue l'action*/
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy" ||collision.gameObject.tag == "Ally"|| collision.gameObject.tag == "Ally2")
        {
            /*Joue un effet quand la balle touche quelque chose, puis d�truit l'effet et la balle*/
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);//1f = temps avant destruction de l'effet
            Destroy(gameObject);//d�truit la balle

            /*D�truit l'objet touch� si c'est un alli� (inutile de leur mettre un script point de vie puisqu'il n'en ont qu'un
             * et que leur mort n'impacte rien(si cela venait � changer il faudrait leur cr�er leur propre script de vie)*/
            if (collision.gameObject.tag == "Ally" || collision.gameObject.tag == "Ally2") Destroy(collision.gameObject);
        }
        
    } 

}
