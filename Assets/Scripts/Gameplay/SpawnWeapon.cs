using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 10f;//Rayon d'apparition des alli�s, temps entre l'apparation des alli�s

    public GameObject[] weapons;//D�clare la liste des armes
    public GameObject player; //R�f�rence au joueur


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAWeapon());//Lance le spawn d'armes pour la premi�re fois
    }

    //Fonction spawnant les armes
    IEnumerator SpawnAWeapon()
    {
        Vector2 spawnPos = player.transform.position; //R�cup�re la position du joueur
        /*Choisis une coordon�e dans un cercle autour du joueur, multipli� par spawnRadius pour que 
         l'arme n'apparaisse pas au contact du joueur*/
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        /*Fait apparaitre une arme choisie al�atoirement dans la liste,
         � la position choisie avant*/
        Instantiate(weapons[Random.Range(0, weapons.Length)], spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(time);//Attends un d�lai avant de rappeler la fonction
        StartCoroutine(SpawnAWeapon());//Rappel la fonction
    }
}
