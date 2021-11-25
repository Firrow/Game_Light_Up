using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    /*A implémenter*/
    public GameObject hitEffect;//Référence à l'effet à jouer quand la balle touche quelque chose

    void OnCollisionEnter2D(Collision2D collision)//Se déclenche quand la balle touche quelque chose
    {
        /*Joue un effet quand la balle touche quelque chose, puis détruit l'effet et la balle*/
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);//5f = temps avant destruction
        Destroy(gameObject);
        
    }

}
