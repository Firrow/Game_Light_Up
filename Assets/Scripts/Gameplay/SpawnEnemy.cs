using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 2.5f;//Rayon d'apparition des ennemis, temps entre l'apparation des ennemis

    private GameObject[] enemies;//Déclare la liste des ennemis à spawner
    public GameObject player; //Référence au joueur
    public GameObject Enemy1;//Référence à l'ennemi 1
    public GameObject Enemy2;//Référence à l'ennemi 2
    public int score;//Déclare le score (mettre à jour dans le on destroy de l'ennemi) Tuer un allié baisse score ??

    // Start is called before the first frame update
    void Start()
    {
        //Crée une liste d'ennemi avec un répartition de base de 90% Enemy1 et 10% Enemy2
        enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2 };
        StartCoroutine(SpawnAnEnemy());//Lance le spawn d'ennemi pour la première fois
    }

    private void FixedUpdate()
    {
        if (score > 100 && score < 250) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 70% Enemy1 et 30% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2 };
            time = 2f;//Change le délai entre les spawns à 2s
        }
        else if (score > 250 && score < 500) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 50% Enemy1 et 50% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            time = 1.5f;//Change le délai entre les spawns à 1.5s
        }
        else if (score > 500) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 20% Enemy1 et 80% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            time = 1f;//Change le délai entre les spawns à 1s
        }
    }

    //Fonction spawnant les ennemis
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = player.transform.position; //Récupère la position du joueur
        /*Choisis une coordonée dans un cercle autour du joueur, multiplié par spawnRadius pour que 
         l'ennemi n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un ennemi choisis aléatoirement dans la liste,
         à la position choisie avant*/
        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(time);//Attends un délai avant de rappeler la fonction
        StartCoroutine(SpawnAnEnemy());//Rappel la fonction
    }
}
