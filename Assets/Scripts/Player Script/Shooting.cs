using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;//R�f�rence au firePoint (point de d�part de la balle)
    public GameObject bullet;//R�f�rence � l'objet balle

    public float bulletSpeed;//Cr�e la variable responsable de la vitesse de la balle
    public float fireDelay;//Cr�e la variable qui sert � calculer le d�lais entre les tirs
    
    /*Cr�e la variable qui stock le d�lai entre les tirs de l'arme,
     * 0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil � pompe, XX pour la mitrailleuse*/
    private float fireRate;
    private int weaponEquipped;//Arme actuelle du joueur( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil � pompe et 3 = mitrailleuse)
    private Transform weaponChild;

    private void Awake()
    {
        fireDelay = 0;//Initalise fireDelay
        weaponEquipped = 0;//( 0 = arme de base, 1 = fusil d'assaut, 2 = fusil � pompe et 3 = mitrailleuse)
        fireRate = 0.4f;//0.4 pour l'arme de base, XX pour le fusil d'assaut, XX pour le fusil � pompe, XX pour la mitrailleuse
    }

    // Update is called once per frame
    void Update()//R�cup�re les Inputs
    {
        Debug.Log(weaponEquipped);
        /*Si l'arme �quip�e n'est pas automatique, r�cup�re un input par clic*/
        if (weaponEquipped == 0 || weaponEquipped == 1 || weaponEquipped == 2)
        {
            /*La premi�re partie de l'expression v�rifie que l'input de tir soit donn�
             la deuxi�me partie de l'expression v�rifie que Time.time (le temps actuel) soit sup�rieur � fireDelay */
            if (Input.GetButtonDown("Fire1") && Time.time > fireDelay)
            {
                /*Time.time = temps actuel + fireRate = d�lai (en seconde) entre deux tir
                fireDelay = temps � partir duquel sera autoris� le prochain coup de feu*/
                fireDelay = Time.time + fireRate;
                if (weaponEquipped == 0) ShootWP1(); //Si arme basique �quip�e appelle la fonction de tir 1
                else if (weaponEquipped == 1) ShootWP2();//Si fusil d'assaut �quip� apelle la fonction de tir 2
                else ShootWP3();//Si fusil � pompe �quip� apelle la fonction de tir 3
            }

        }
        else/*Si l'arme �quip�e est automatique r�cup�re un input en continu*/
        {
            /*La premi�re partie de l'expression v�rifie que l'input de tir soit donn�
             la deuxi�me partie de l'expression v�rifie que Time.time (le temps actuel) soit sup�rieur � fireDelay */
            if (Input.GetButton("Fire1") && Time.time > fireDelay)
            {
                /*Time.time = temps actuel + fireRate = d�lai (en seconde) entre deux tir
                fireDelay = temps � partir duquel sera autoris� le prochain coup de feu*/
                fireDelay = Time.time + fireRate;
                ShootWP4();//Apelle la fonction de tir 4
            }
        }
        

    }

    void Shoot(GameObject bulletToFire, Transform firePoint, float speed)//Fonction appel�e lors de l'input de tir
    {
        /*Cr�e une instance de balle et la range dans une variable, afin de la modifier apr�s*/
        GameObject bulletInst = Instantiate(bullet, firePoint.position, firePoint.rotation);
        //R�cup�re le corps de la balle  et le range dans une variable afin de le modifier apr�s
        Rigidbody2D rb = bulletInst.GetComponent<Rigidbody2D>();
        //Ajouter une force de type Impulse, �gale � la vitesse de la balle et dans la direction du up vector de la balle
        //au corps de la balle
        rb.AddForce(firePoint.up * speed, ForceMode2D.Impulse);
    }

    void ShootWP1()//Fonction de tir de l'arme de base
    {
        Shoot(bullet, firePoint.transform, 8f);
    }
    void ShootWP2()//Fonction de tir du fusil d'assaut
    {
        IEnumerator TimeDelay()
        {
            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform, 12f);

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform, 12f);

            yield return new WaitForSeconds(0.1f);
            Shoot(bullet, firePoint.transform, 12f);
        }

        StartCoroutine(TimeDelay());
    }

    void ShootWP3()//Fonction de tir du fusil � pompe
    {
        Shoot(bullet, firePoint.transform, 15f);
    }

    void ShootWP4()//Fonction de tir de la mitrailleuse
    {
        Shoot(bullet, firePoint.transform, 15f);
    }
}
