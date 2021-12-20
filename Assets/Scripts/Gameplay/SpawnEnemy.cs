using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 2.5f;//Rayon d'apparition des ennemis, temps entre l'apparation des ennemis

    private GameObject[] enemies;//D�clare la liste des ennemis � spawner
    public GameObject player; //R�f�rence au joueur
    public GameObject Enemy1;//R�f�rence � l'ennemi 1
    public GameObject Enemy2;//R�f�rence � l'ennemi 2
    public int score;//D�clare le score (mettre � jour dans le on destroy de l'ennemi) Tuer un alli� baisse score ??

    // Start is called before the first frame update
    void Start()
    {
        //Cr�e une liste d'ennemi avec un r�partition de base de 90% Enemy1 et 10% Enemy2
        enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2 };
        StartCoroutine(SpawnAnEnemy());//Lance le spawn d'ennemi pour la premi�re fois
    }

    private void FixedUpdate()
    {
        if (score > 100 && score < 250) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'ennemi avec un r�partition de 70% Enemy1 et 30% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2 };
            time = 2f;//Change le d�lai entre les spawns � 2s
        }
        else if (score > 250 && score < 500) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'ennemi avec un r�partition de 50% Enemy1 et 50% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            time = 1.5f;//Change le d�lai entre les spawns � 1.5s
        }
        else if (score > 500) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'ennemi avec un r�partition de 20% Enemy1 et 80% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            time = 1f;//Change le d�lai entre les spawns � 1s
        }
    }

    //Fonction spawnant les ennemis
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = player.transform.position; //R�cup�re la position du joueur
        /*Choisis une coordon�e dans un cercle autour du joueur, multipli� par spawnRadius pour que 
         l'ennemi n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un ennemi choisis al�atoirement dans la liste,
         � la position choisie avant*/
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(time);//Attends un d�lai avant de rappeler la fonction
        StartCoroutine(SpawnAnEnemy());//Rappel la fonction
    }
}
