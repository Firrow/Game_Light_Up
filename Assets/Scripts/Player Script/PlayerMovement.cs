using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;//Vitesse du joueur
    public Animator animator;//Animation
    public SpriteRenderer spriteRenderer;//image
    public Transform firePoint;

    private Rigidbody2D rb;//Cr?? une variable pour stocker le corps du joueur
    private Camera cam;//Cr?e une variable pour stocker la camera

    Vector2 movement;//Vecteur contenant le mouvement du joueur
    Vector2 mousePosition;//Vecteur contenant la position de la souris




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();//R?cup?re le rigidBody du joueur et le stock dans la variable cr??e pr?alablement
        cam = Camera.main;//R?cup?re la camera et la stock dans la variable cr??e pr?alablement
    }

    //Permet de changer la direction du sprite du joueur, de l'arme et du firePoint
    void Flip(float _velocity)
    {
        SpriteRenderer sp1 = gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>();
        Transform sp2 = gameObject.transform.GetChild(0);

        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = true; //joueur
            sp1.flipX = true; //arme
            sp2.transform.localPosition = new Vector3(Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
        else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = false; //joueur
            sp1.flipX = false; //arme
            sp2.transform.localPosition = new Vector3(-Mathf.Abs(sp2.transform.localPosition.x), sp2.transform.localPosition.y, sp2.transform.localPosition.z);//firePoint
        }
    }


    // Update is called once per frame
    void Update()//R?cup?re les inputs 
    {
        /*R?cup?re les Inputs de mouvement*/
        movement.x = Input.GetAxisRaw("Horizontal");//R?cup?re l'input sur l'axe X et le stock dans une variable
        movement.y = Input.GetAxisRaw("Vertical");//R?cup?re l'input sur l'axe Y et le stock dans une variable

        //Gestion des animations
        animator.SetFloat("SpeedH", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedV", Mathf.Abs(movement.y));

        /*R?cup?re la position de la souris, la transforme en coordon?es et la stock dans une variable*/
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition); //A MODIFIER

        /*Limite du terrain, empeche le joueur de d?passe les coordon?es sp?cifi?es*/
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9f, 9f), Mathf.Clamp(transform.position.y, -9f, 9f));
    }

    void FixedUpdate()//Ex?cute les inputs
    {
        /*D?place le joueur (position actuelle + direction (normalized ?limine l'acc?l?ration lors de mouvement en diagonale) * vitesse
         * deltaTime */

        
        Flip(movement.x);

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);

        




        //ANCIEN SYSTEME D'ORIENTATION
        //Cr?ation du vecteur d'orientation du joueur (position de la souris - position actuelle)
        //Vector2 lookDir = mousePosition - rb.position;


        /*Transforme le vecteur d'orientation en angle, puis le converti de radiant en degr? et compense l'offset*/
        ///float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90f;
        //rb.rotation = angle;//Applique la rotation au joueur
    }
}
