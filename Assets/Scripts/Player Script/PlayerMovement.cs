using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;//Vitesse du joueur
    public Animator animator;//Animation
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;//Créé une variable pour stocker le corps du joueur
    private Camera cam;//Crée une variable pour stocker la camera

    Vector2 movement;//Vecteur contenant le mouvement du joueur
    Vector2 mousePosition;//Vecteur contenant la position de la souris




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//Récupère le rigidBody du joueur et le stock dans la variable créée préalablement
        cam = Camera.main;//Récupère la camera et la stock dans la variable créée préalablement
    }

    void Flip(float _velocity)
    {
        SpriteRenderer sp1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();

        Debug.Log(movement.x);
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = true;

            //sp1.flipX = true;
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = false;

            //sp1.flipX = false;
        }
    }


    // Update is called once per frame
    void Update()//Récupère les inputs 
    {
        /*Récupère les Inputs de mouvement*/
        movement.x = Input.GetAxisRaw("Horizontal");//Récupère l'input sur l'axe X et le stock dans une variable
        movement.y = Input.GetAxisRaw("Vertical");//Récupère l'input sur l'axe Y et le stock dans une variable

        //Gestion des animations
        animator.SetFloat("SpeedH", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedV", Mathf.Abs(movement.y));

        /*Récupère la position de la souris, la transforme en coordonées et la stock dans une variable*/
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); //A MODIFIER

        /*Limite du terrain, empeche le joueur de dépasse les coordonées spécifiées*/
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -9f, 9f));
    }

    void FixedUpdate()//Exécute les inputs
    {
        /*Déplace le joueur (position actuelle + direction (normalized élimine l'accélération lors de mouvement en diagonale) * vitesse
         * deltaTime */

        
        Flip(movement.x);

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        




        //ANCIEN SYSTEME D'ORIENTATION
        //Création du vecteur d'orientation du joueur (position de la souris - position actuelle)
        //Vector2 lookDir = mousePosition - rb.position;


        /*Transforme le vecteur d'orientation en angle, puis le converti de radiant en degré et compense l'offset*/
        ///float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        //rb.rotation = angle;//Applique la rotation au joueur
    }
}
