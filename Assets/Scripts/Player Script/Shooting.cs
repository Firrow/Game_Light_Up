using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;//Référence au firePoint (point de départ de la balle)
    public GameObject bullet;//Référence à l'objet balle

    /*Crée la variable qui stock le délai entre les tirs de l'arme,
     * 0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil à pompe, XX pour la mitrailleuse*/
    private float fireRate;
    private int weaponEquipped;//Arme actuelle du joueur( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil à pompe et 3 = mitrailleuse)
    private float bulletSpeed;//Crée la variable responsable de la vitesse de la balle
    private float fireDelay;//Crée la variable qui sert à calculer le délais entre les tirs
    private int amunitions;//Crée la variable qui stock les munitions du joueurs
    private Transform weaponChild;

    void Awake()
    {
        fireDelay = 0;//Initalise fireDelay
        weaponEquipped = 0;//( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil à pompe et 3 = mitrailleuse)
        fireRate = 0.4f;//0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil à pompe, XX pour la mitrailleuse
        bulletSpeed = 8f;//Initialise bulletSpeed
        amunitions = 100;//Initialise le nb de balles du joueur
    }

    // Update is called once per frame
    void Update()//Récupère les Inputs
    {
        /*Enregistre l'input de tir seulement si le joueur possède au moins une balle*/
        if (amunitions > 0)
        {
            /*Si l'arme équipée n'est pas automatique, récupère un input par clic*/
            if (weaponEquipped == 0 || weaponEquipped == 1 || weaponEquipped == 2)
            {
                /*La première partie de l'expression vérifie que l'input de tir soit donné
                 la deuxième partie de l'expression vérifie que Time.time (le temps actuel) soit supérieur à fireDelay */
                if (Input.GetButtonDown("Fire1") && Time.time > fireDelay)
                {
                    /*Time.time = temps actuel + fireRate = délai (en seconde) entre deux tir
                    fireDelay = temps à partir duquel sera autorisé le prochain coup de feu*/
                    fireDelay = Time.time + fireRate;
                    if (weaponEquipped == 0) ShootWP1(); //Si arme basique équipée appelle la fonction de tir 1
                    else if (weaponEquipped == 1) ShootWP2();//Si fusil d'assaut équipé apelle la fonction de tir 2
                    else ShootWP3();//Si fusil à pompe équipé apelle la fonction de tir 3
                }

            }
            else/*Si l'arme équipée est automatique récupère un input en continu*/
            {
                /*La première partie de l'expression vérifie que l'input de tir soit donné
                 la deuxième partie de l'expression vérifie que Time.time (le temps actuel) soit supérieur à fireDelay */
                if (Input.GetButton("Fire1") && Time.time > fireDelay)
                {
                    /*Time.time = temps actuel + fireRate = délai (en seconde) entre deux tir
                    fireDelay = temps à partir duquel sera autorisé le prochain coup de feu*/
                    fireDelay = Time.time + fireRate;
                    ShootWP4();//Apelle la fonction de tir 4
                }
            }
        }
    }

    void Shoot(GameObject bulletToFire, Transform firePoint, Vector3 offsetp)//Fonction appelée lors de l'input de tir
    {  
        /*Crée une instance de balle et la range dans une variable, afin de la modifier après*/
        GameObject bulletInst = Instantiate(bullet, firePoint.position + offsetp, firePoint.rotation);
        //Récupère le corps de la balle  et le range dans une variable afin de le modifier après
        Rigidbody2D rb = bulletInst.GetComponent<Rigidbody2D>();
        //Ajouter une force de type Impulse, égale à la vitesse de la balle et dans la direction du up vector de la balle
        //au corps de la balle
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }

    void ShootWP1()//Fonction de tir de l'arme de base
    {
        //tire une balle
        Shoot(bullet, firePoint.transform, new Vector3(0,0,0));
        amunitions -= 1;//décremente les munitions de l'arme
    }
    void ShootWP2()//Fonction de tir du fusil d'assaut
    {
        /*Tire une rafale de trois balles avec un délai de 0.1 entre chaque balles
         Les deux dernières balles sont légerement désaxées*/
        IEnumerator TimeDelay()
        {
            //yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform,new Vector3(0, 0, 0));

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform, new Vector3(.2f, 0, 0));

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform,new Vector3(-.2f, 0, 0));
        }

        StartCoroutine(TimeDelay());
        amunitions -= 3;//décrémente les munitions de l'arme
    }

    void ShootWP3()//Fonction de tir du fusil à pompe
    {
        //Tire quatre balle simultanément
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));
        Shoot(bullet, firePoint.transform, new Vector3(0, 0, 0));

        amunitions -= 4;//décrémente les munitions de l'arme
    }

    void ShootWP4()//Fonction de tir de la mitrailleuse
    {
        //Tire une balle avec un spread random (entre -.2f et .2f)
        Shoot(bullet, firePoint.transform, new Vector3(Random.Range(-.2f, .2f), 0, 0));
        amunitions -= 1;//décrémente les munitions de l'arme
    }

    //Changement de couleur TEMPORAIRE pour TEST
    public void changeWeapon(float bSpd, float fRate, int weapon, int amun, Sprite weaponSprite, Color weaponColor)
    {
        bulletSpeed = bSpd;
        fireRate = fRate;
        weaponEquipped = weapon;
        amunitions = amun;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = weaponSprite;
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().color = weaponColor;//Changement de couleur TEMPORAIRE pour TEST
    }
}
