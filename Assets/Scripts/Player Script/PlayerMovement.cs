using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;//Vitesse du joueur

    private Rigidbody2D rb;//Crée uen variable pour stocker le corps du joueur
    private Camera cam;//Crée une variable pour stocker la camera

    Vector2 movement;//Vecteur contenant le mouvement du joueur
    Vector2 mousePosition;//Vecteur contenant la position de la souris

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Récupère le rigidBody du joueur et le stock dans la variable créée préalablement
        cam = Camera.main;//Récupère la camera et la stock dans la variable créée préalablement
    }

    // Update is called once per frame
    void Update()//Récupère les inputs 
    {
        /*Récupère les Inputs de mouvement*/
        movement.x = Input.GetAxisRaw("Horizontal");//Récupère l'input sur l'axe X et le stock dans une variable
        movement.y = Input.GetAxisRaw("Vertical");//Récupère l'input sur l'axe Y et le stock dans une variable

        /*Récupère la position de la souris, la transforme en coordonées et la stock dans une variable*/
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        /*Limite du terrain, empeche le joueur de dépasse les coordonées spécifiées*/
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -9f, 9f));
    }

    void FixedUpdate()//Exécute les inputs
    {
        /*Déplace le joueur (position actuelle + direction (normalized élimine l'accélération lors de mouvement en diagonale) * vitesse
         * deltaTime */
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        //Création du vecteur d'orientation du joueur (position de la souris - position actuelle)
        Vector2 lookDir = mousePosition - rb.position;
        /*Transforme le vecteur d'orientation en angle, puis le converti de radiant en degré et compense l'offset*/
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        rb.rotation = angle;//Applique la rotation au joueur
    }
}
