using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementAI : MonoBehaviour
{
    public float speed;//Crée la variable où stocker la vitesse de l'entité

    private Transform playerPos;//Crée la variable ou stocker la position du joueur

    // Start is called before the first frame update
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si l'IA n'est pas a proximité du joueur
        if (Vector2.Distance(transform.position, playerPos.position)>1f)
            //L'IA se déplace en direction du joueur
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
}
