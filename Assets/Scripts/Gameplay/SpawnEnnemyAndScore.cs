using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnnemyAndScore : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private float spawnRadius = 7;//Rayon d'apparition des ennemis

    private float timeE; //temps entre l'apparation des ennemis

    private GameObject[] enemies;//Déclare la liste des ennemis à spawner
    public GameObject player; //Référence au joueur
    public GameObject Enemy1;//Référence à l'ennemi 1
    public GameObject Enemy2;//Référence à l'ennemi 2
    private int score;//Déclare le score (mettre à jour dans le on destroy de l'ennemi) Tuer un allié baisse score ??

    // Start is called before the first frame update
    void Awake()
    {
        timeE = 2.5f;
        Debug.Log(score);
        //Crée une liste d'ennemi avec un répartition de base de 90% Enemy1 et 10% Enemy2
        enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2 };
        StartCoroutine(SpawnAnEnemy());//Lance le spawn d'ennemi pour la première fois
    }

    private void UpdateSpawnerE()
    {
        if (score > 100 && score < 250) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 70% Enemy1 et 30% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2 };
            timeE = 2f;//Change le délai entre les spawns à 2s
        }
        else if (score > 250 && score < 500) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 50% Enemy1 et 50% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy1, Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            timeE = 1.5f;//Change le délai entre les spawns à 1.5s
        }
        else if (score > 500) //Valeur de score arbitraire, si le score atteint XX change les caractéristiques du spawner
        {
            //Modifie la liste d'ennemi avec un répartition de 20% Enemy1 et 80% Enemy2
            enemies = new GameObject[] { Enemy1, Enemy1, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2, Enemy2 };
            timeE = 1f;//Change le délai entre les spawns à 1s
        }
    }

    //Fonction spawnant les ennemis
    IEnumerator SpawnAnEnemy()
    {
        Vector2 spawnPos = player.transform.position; //Récupère la position du joueur
        /*Choisis une coordonée dans un cercle autour du joueur, multiplié par spawnRadius pour que 
         l'ennemi n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeE);//Attends un délai avant de rappeler la fonction
        Debug.Log(Time.time);//A enlever quand on aura vérifier que tout fonctionne parfaitement
        StartCoroutine(SpawnAnEnemy());//Rappel la fonction
    }


 
    public void setScore()
    {
        score += 10;//Ajoute 10 au score à chaque fois la fonction est appelée
        Debug.Log(score);
        /*C'est un peu brut mais de toute façon le score a pas besoin d'être hyper développé*/
        UpdateSpawnerE();//Apelle l'update Spawner quand le score est mis à jour plutôt que à charque frame NE FONCTIONNE PAS
        
    }
}
