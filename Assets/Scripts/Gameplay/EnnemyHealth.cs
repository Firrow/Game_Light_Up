using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField]//permet d'accéder à la variable dans l'éditeur tout en là laissant privée
    private int vie;//Crée la variable de vie de l'ennemi
    private GameObject gManager;//Crée la référence au GameManager
    private SpawnEnnemyAndScore scoreGame;//Crée la référence pour modifier le score jr
   



    private void Awake()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager");
        scoreGame = gManager.GetComponent<SpawnEnnemyAndScore>();
    }
    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "bullet" )//Si la collision est une balle
        {
            scoreGame.setScore();//Augmente le score du joueur
            vie--;//Perd un de vie   
        }
    }
    private void Update()
    {
        if (vie <= 0)//Si l'ennemi n'a plus de vie
        {
            //Potentiellement une anim ?
            Destroy(gameObject);//Détruit l'ennemi
        }
    }
}
