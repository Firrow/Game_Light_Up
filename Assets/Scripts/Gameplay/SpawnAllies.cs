using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField]//permet d'acc�der � la variable dans l'�diteur tout en l� laissant priv�e
    private float spawnRadius = 7;//Rayon d'apparition des alli�s,
    private float timeA; //temps entre l'apparation des alli�s

    private Health vieJoueur;//Cr�e la r�f�rence au script Health du joueur
    private GameObject[] allies;//D�clare la liste des alli�s � spawner
    public GameObject player; //R�f�rence au joueur
    public GameObject Ally1;//R�f�rence � l'alli� 1
    public GameObject Ally2;//R�f�rence � l'alli� 2

    // Start is called before the first frame update
    void Start()
    {
        timeA = 2.5f;
        vieJoueur = player.GetComponent<Health>();
        //Cr�e une liste d'alli� avec un r�partition de base de 50% Ally1 et 50% Ally2
        allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
        StartCoroutine(SpawnAnAlly());//Lance le spawn d'alli� pour la premi�re fois
    }

    public void UpdateSpawnerA()//Pour plus d'opti au lieu de fixedUpdate cr�er et appeler cette fonction � chaque fois que le joueur perd/gagne un hp
    {
        if (vieJoueur.getVie() < 3)
        {
            //Modifie la liste d'alli� avec un r�partition de base de 50% Ally1 et 50% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
            timeA = 2f;//Change le d�laire entre les spawns � 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract�ristiques du spawner
        else if (vieJoueur.getVie() >= 3 && vieJoueur.getVie() < 5) 
        {
            //Modifie la liste d'alli�s avec un r�partition de 66% Ally1 et 33% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally2, Ally2 };
            timeA = 3f;//Change le d�lai entre les spawns � 3s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract�ristiques du spawner
        else if (vieJoueur.getVie() >= 5 && vieJoueur.getVie() < 10)
        {
            //Modifie la liste d'alli�s avec un r�partition de 84% Ally1 et 16% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally2 };
            timeA = 4f;//Change le d�lai entre les spawns � 4s
        }
        //Valeur de vie arbitraire, si le score atteint XX change les caract�ristiques du spawner
        else if (vieJoueur.getVie() > 10) 
        {
            //Modifie la liste d'alli�s avec un r�partition de 100% Ally1 et 0% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally1 };
            timeA = 5f;//Change le d�lai entre les spawns � 5s
        }
    }

    //Fonction spawnant les alli�s
    IEnumerator SpawnAnAlly()
    {
        Vector2 spawnPos = player.transform.position; //R�cup�re la position du joueur
        /*Choisis une coordon�e dans un cercle autour du joueur, multipli� par spawnRadius pour que 
         l'alli� n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre un alli� choisis al�atoirement dans la liste,
         � la position choisie avant*/
        Instantiate(allies[Random.Range(0, allies.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeA);//Attends un d�lai avant de rappeler la fonction
        StartCoroutine(SpawnAnAlly());//Rappel la fonction
    }
}
