using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;//Vitesse du joueur

    public Rigidbody2D rb;//R�f�rence au corps du joueur
    public Camera cam;//R�f�rence � la cam�ra de la scene de jeu

    Vector2 movement;//Vecteur contenant le mouvement du joueur
    Vector2 mousePosition;//Vecteur contenant la position de la souris

    // Update is called once per frame
    void Update()//R�cup�re les inputs 
    {
        movement.x = Input.GetAxisRaw("Horizontal");//R�cup�re l'input sur l'axe X et le stock dans une variable
        movement.y = Input.GetAxisRaw("Vertical");//R�cup�re l'input sur l'axe Y et le stock dans une variable

        /*R�cup�re la position de la souris, la transforme en coordon�es et la stock dans une variable*/
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()//Ex�cute les inputs
    {
        /*D�place le joueur (position actuelle + direction (normalized �limine l'acc�l�ration lors de mouvement en diagonale) * vitesse
         * deltaTime */
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        //Cr�ation du vecteur d'orientation du joueur (position de la souris - position actuelle)
        Vector2 lookDir = mousePosition - rb.position;
        /*Transforme le vecteur d'orientation en angle, puis le converti de radiant en degr� et compense l'offset*/
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;//Applique la rotation au joueur
    }
}
