using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public PlayerSoundController playerSoundController;

    public float velocidad = 5f; //velocity variable
    public bool step1 = false; //this makes possible a step1 sound
    public bool fall = false; //this is a variable to verify the floor contact sound
    public float timeByStep = 0.5f; // this is the variable to the time of ever step sound
    public float cont = 0f;
        
    public float fuerzaSalto = 10f; //force of jump implulse variable
    public float longitudRaycast= 0.1f;
    public LayerMask capaSuelo;

    private bool enSuelo; //enSuelo variable allows verify the contact of the player with the floor
    private Rigidbody2D rb;

    public Animator animator; //animator variable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime*velocidad; // there is multiplicated to fix the velocity 
       
        if (velocidadX != 0 && enSuelo) //!recibiendoDanio && !atacando//
        {
            cont += Time.deltaTime;
            if(cont >= timeByStep)
            {
                cont =0f;
                if (step1)
                {
                    playerSoundController.playMov1(); //this plays a step1 sound
                }
                else
                {
                    playerSoundController.playMov2(); //this plays a step2 sound
                }
                step1 = !step1; 
            }
            
        }

        animator.SetFloat("movement",velocidadX*velocidad);

        if (velocidadX <0) //this conditional makes spin horizontal the character
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        if (velocidadX >0)
        {
            transform.localScale = new Vector3(1,1,1);
        }

        Vector3 posicion = transform.position;

        transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
        enSuelo = hit.collider != null;

        if (enSuelo && rb.velocity.y <0 && fall)
        {
            playerSoundController.playCaida(); //this plays a fall sound getting contact with the foor
            fall = false;
        }

        if (enSuelo && Input.GetKeyDown(KeyCode.Space))
        {
            fall = true;
            playerSoundController.playSaltar(); //this plays a jump sound
            rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse); //this makes the character jump
        }

        animator.SetBool("ensuelo",enSuelo);

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // this makes a redline to verify the floor contact with the player 
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}
