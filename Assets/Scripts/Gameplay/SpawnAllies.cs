using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAllies : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 2.5f;//Rayon d'apparition des alli�s, temps entre l'apparation des alli�s

    private Health vieJoueur;//Cr�e la r�f�rence au script Health du joueur
    private GameObject[] allies;//D�clare la liste des alli�s � spawner
    public GameObject player; //R�f�rence au joueur
    public GameObject Ally1;//R�f�rence � l'alli� 1
    public GameObject Ally2;//R�f�rence � l'alli� 2

    // Start is called before the first frame update
    void Start()
    {
        vieJoueur = player.GetComponent<Health>();
        //Cr�e une liste d'alli� avec un r�partition de base de 50% Ally1 et 50% Ally2
        allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
        StartCoroutine(SpawnAnAlly());//Lance le spawn d'alli� pour la premi�re fois
    }

    private void FixedUpdate()//Pour plus d'opti au lieu de fixedUpdate cr�er et appeler cette fonction � chaque fois que le joueur perd/gagne un hp
    {
        if (vieJoueur.vie < 3)
        {
            //Modifie la liste d'alli� avec un r�partition de base de 50% Ally1 et 50% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally2, Ally2, Ally2 };
            time = 2f;//Change le d�laire entre les spawns � 3s
        }
        else if (vieJoueur.vie >= 3 && vieJoueur.vie < 5) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'alli�s avec un r�partition de 66% Ally1 et 33% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally2, Ally2 };
            time = 3f;//Change le d�lai entre les spawns � 3s
        }
        else if (vieJoueur.vie >= 5 && vieJoueur.vie < 10) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'alli�s avec un r�partition de 84% Ally1 et 16% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally2 };
            time = 4f;//Change le d�lai entre les spawns � 4s
        }
        else if (vieJoueur.vie > 10) //Valeur de score arbitraire, si le score atteint XX change les caract�ristiques du spawner
        {
            //Modifie la liste d'alli�s avec un r�partition de 100% Ally1 et 0% Ally2
            allies = new GameObject[] { Ally1, Ally1, Ally1, Ally1, Ally1, Ally1 };
            time = 5f;//Change le d�lai entre les spawns � 5s
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

        yield return new WaitForSeconds(time);//Attends un d�lai avant de rappeler la fonction
        StartCoroutine(SpawnAnAlly());//Rappel la fonction
    }
}
