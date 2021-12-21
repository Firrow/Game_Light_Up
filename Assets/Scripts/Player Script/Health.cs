using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int vie;//Crée la variable de vie du joueur
    public GameObject gManager;//Crée la référence au GameManager NE FONCTIONNE PAS
    private SpawnAllies allySpawner;//Crée la référence au spawner allié NE FONCTIONNE PAS

    private void Awake()
    {
        allySpawner = gManager.GetComponent<SpawnAllies>();// NE FONCTIONNE PAS
    }


    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "Enemy" )//Si la collision est un ennemi
        {
            vie--;//Perd un point de vie
            Destroy(collision.gameObject);//Détruit l'ennemi (à remplacer par une anime puis détruire, comme pour les balles)
            //Important de détruire l'objet tout de suite ou le joueur perd plusieurs hp avec le même ennemi
            //Pour l'animation on pourra donc juste instantiate un objet qui est une animation , qui se détruit elle même une fois finis
            //(mettre un Destroy(gameObject, XXf) dans le Start/Awake)
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur perd de la vie plutôt quà chaque frame PAS FONCTIONNER
        }
        else if (collision.gameObject.tag == "Ally")//Si la collision est un allié simple
        {
            vie++;//Gagne un point de vie
            Destroy(collision.gameObject);//détruit l'allié
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur gagne de la vie plutôt quà chaque frame PAS FONCTIONNER
        }
        else if (collision.gameObject.tag == "Ally2")//Si la collision est un allié "double"
        { 
            vie = vie + 2;//Gagne deux points de vie
            Destroy(collision.gameObject);//détruit l'allié
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur gagne de la vie plutôt quà chaque frame PAS FONCTIONNER
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (vie <= 0)
        {
            //DO SOMETHING
            //fin du jeu
        }
    }

    public int getVie()//Méthode pour récuperer la vie du joueur dans le script SpawnAllies
    {
        return vie;
    }
}
