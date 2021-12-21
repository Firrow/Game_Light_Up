using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private float spawnRadius = 7;//Rayon d'apparition des alliés,
    private float timeW;// temps entre l'apparation des alliés

    public GameObject[] weapons;//Déclare la liste des armes
    public GameObject player; //Référence au joueur


    // Start is called before the first frame update
    void Start()
    {
        timeW = 5f;
        StartCoroutine(SpawnAWeapon());//Lance le spawn d'armes pour la première fois
    }

    //Fonction spawnant les armes
    IEnumerator SpawnAWeapon()
    {
        Vector2 spawnPos = player.transform.position; //Récupère la position du joueur
        /*Choisis une coordonée dans un cercle autour du joueur, multiplié par spawnRadius pour que 
         l'arme n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre une arme choisie aléatoirement dans la liste,
         à la position choisie avant*/
        Instantiate(weapons[Random.Range(0, weapons.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(timeW);//Attends un délai avant de rappeler la fonction
        StartCoroutine(SpawnAWeapon());//Rappel la fonction
    }
}
