using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private float spawnRadius = 7;//Rayon d'apparition des alliés,
    private float timeA; //temps entre l'apparation des alliés

    private Health vieJoueur;//Crée la référence au script Health du joueur
    private GameObject[] allies;//Déclare la liste des alliés à spawner
    public GameObject player; //Référence au joueur
    public GameObject Ally1;//Référence à l'allié 1
    public GameObject Ally2;//Référence à l'allié 2

    // Start is called before the first frame update
    void Start()
    {
        timeA = 2.5f;
        vieJoueur = player.GetComponent<Health>();
        //Crée une liste d'allié avec un répartition de base de 50% Ally1 et 50% Ally2
        allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
        StartCoroutine(SpawnAnAlly());//Lance le spawn d'allié pour la première fois
    }

    public void UpdateSpawnerA()//Pour plus d'opti au lieu de fixedUpdate créer et appeler cette fonction à chaque fois que le joueur perd/gagne un hp
    {
        if (vieJoueur.getVie() < 3)
        {
            //Modifie la liste d'allié avec un répartition de base de 50% Ally1 et 50% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
            timeA = 2f;//Change le délaire entre les spawns à 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (vieJoueur.getVie() >= 3 && vieJoueur.getVie() < 5) 
        {
            //Modifie la liste d'alliés avec un répartition de 66% Ally1 et 33% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally2, Ally2 };
            timeA = 3f;//Change le délai entre les spawns à 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (vieJoueur.getVie() >= 5 && vieJoueur.getVie() < 10)
        {
            //Modifie la liste d'alliés avec un répartition de 84% Ally1 et 16% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally2 };
            timeA = 4f;//Change le délai entre les spawns à 4s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caractéristiques du spawner
        else if (vieJoueur.getVie() > 10) 
        {
            //Modifie la liste d'alliés avec un répartition de 100% Ally1 et 0% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally1 };
            timeA = 5f;//Change le délai entre les spawns à 5s
        }
    }

    //Fonction spawnant les alliés
    IEnumerator SpawnAnAlly()
    {
        Vector2 spawnPos = player.transform.position; //Récupère la position du joueur
        /*Choisis une coordonée dans un cercle autour du joueur, multiplié par spawnRadius pour que 
         l'allié n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un allié choisis aléatoirement dans la liste,
         à la position choisie avant*/
        Instantiate(allies[Random.Range(0, allies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeA);//Attends un délai avant de rappeler la fonction
        StartCoroutine(SpawnAnAlly());//Rappel la fonction
    }
}
