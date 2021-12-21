using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int vie;//Cr�e la variable de vie du joueur
    public GameObject gManager;//Cr�e la r�f�rence au GameManager NE FONCTIONNE PAS
    private SpawnAllies allySpawner;//Cr�e la r�f�rence au spawner alli� NE FONCTIONNE PAS

    private void Awake()
    {
        allySpawner = gManager.GetComponent<SpawnAllies>();// NE FONCTIONNE PAS
    }


    void OnCollisionEnter2D(Collision2D collision)//Quand le joueur entre en collision
    {
        if (collision.gameObject.tag == "Enemy" )//Si la collision est un ennemi
        {
            vie--;//Perd un point de vie
            Destroy(collision.gameObject);//D�truit l'ennemi (� remplacer par une anime puis d�truire, comme pour les balles)
            //Important de d�truire l'objet tout de suite ou le joueur perd plusieurs hp avec le m�me ennemi
            //Pour l'animation on pourra donc juste instantiate un objet qui est une animation , qui se d�truit elle m�me une fois finis
            //(mettre un Destroy(gameObject, XXf) dans le Start/Awake)
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur perd de la vie plut�t qu� chaque frame PAS FONCTIONNER
        }
        else if (collision.gameObject.tag == "Ally")//Si la collision est un alli� simple
        {
            vie++;//Gagne un point de vie
            Destroy(collision.gameObject);//d�truit l'alli�
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur gagne de la vie plut�t qu� chaque frame PAS FONCTIONNER
        }
        else if (collision.gameObject.tag == "Ally2")//Si la collision est un alli� "double"
        { 
            vie = vie + 2;//Gagne deux points de vie
            Destroy(collision.gameObject);//d�truit l'alli�
            allySpawner.UpdateSpawnerA();////Apelle l'update Spawner quand le joueur gagne de la vie plut�t qu� chaque frame PAS FONCTIONNER
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

    public int getVie()//M�thode pour r�cuperer la vie du joueur dans le script SpawnAllies
    {
        return vie;
    }
}
