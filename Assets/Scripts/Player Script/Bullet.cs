using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*A implémenter*/
    public GameObject hitEffect;//Référence à l'effet à jouer quand la balle touche quelque chose

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    void OnCollisionEnter2D(Collision2D collision)//Se déclenche quand la balle touche quelque chose
    {
        /*Si la balle entre en collision avec un obstacle, un ennemi ou un allié effectue l'action*/
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Enemy" ||collision.gameObject.tag == "Ally"|| collision.gameObject.tag == "Ally2")
        {
            /*Joue un effet quand la balle touche quelque chose, puis détruit l'effet et la balle*/
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 1f);//1f = temps avant destruction de l'effet
            Destroy(gameObject);//détruit la balle

            /*Détruit l'objet touché si c'est un allié (inutile de leur mettre un script point de vie puisqu'il n'en ont qu'un
             * et que leur mort n'impacte rien(si cela venait à changer il faudrait leur créer leur propre script de vie)*/
            if (collision.gameObject.tag == "Ally" || collision.gameObject.tag == "Ally2") Destroy(collision.gameObject);
        }
        
    } 

}
