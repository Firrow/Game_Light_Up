using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAI : MonoBehaviour
{
    public float speed;//Cr�e la variable o� stocker la vitesse de l'entit�
    public SpriteRenderer spriteRenderer;//image de l'ennemi

    private Transform playerPos;//Cr�e la variable ou stocker la position du joueur

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Change direction du sprite de l'ennemi
    void FlipEnnemy()
    {
        if (playerPos.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (playerPos.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si l'IA n'est pas a proximit� du joueur
        if (Vector2.Distance(transform.position, playerPos.position)>1f)
            //L'IA se d�place en direction du joueur
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);

        FlipEnnemy();
    }
}
