using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    private Transform playerPos;//Variable qui va servir � stocker la pos du joueur

    private void Awake()
    {
        //Trouve l'objet joueur et r�cup�re son composant Transform
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        /*Fait suivre le mouvement du joueur � la cam�ra, 
         le -10 en z sert � garder la cam�ra � la bonne hauteur pour voir le joueur*/
        transform.position = new Vector3(playerPos.transform.position.x, playerPos.transform.position.y, -10) ;

        /*Limite du terrain, permet de d�centrer la camera du joueur quand il arrive au bord du terrain
         evitant que la camera filme du vide qui ne fait pas partie de l'espace de jeu*/
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.41f, 4.45f), Mathf.Clamp(transform.position.y, -4.98f, 5.06f), -10);
    }
}
