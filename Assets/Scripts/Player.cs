using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Player: MonoBehaviour
{
    private float moveH;
    public float moveV;
    public int velocidade;
    public int  attack;
    public int vidas = 3;
    public bool comVida = true;
    public int dano = 30;
    public int vida = 100;
    private Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public string nomePorta;
    public bool entrada;

    public global::System.Single MoveH { get => moveH; set => moveH = value; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(this.gameObject);
    }

    private void FixedUpdate() {
         MoveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        transform.position += new Vector3(MoveH * velocidade * Time.deltaTime,moveV * velocidade * Time.deltaTime,0);
    }

    // Update is called once per frame
    void Update()
    {
       

        if(Input.GetKeyDown(KeyCode.W) )
        {
            anim.SetLayerWeight(2,1);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {   
            anim.SetLayerWeight(1,1);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = false;
            anim.SetLayerWeight(1,0);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = true;
            anim.SetLayerWeight(1,0);
        }
        if(moveH == 0 && moveV == 0 )
        {
            anim.SetLayerWeight(2,0);
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(0,1);
        }
        
    }
        public int VidasdoPlayer()
        {
            return vidas;
        }
        private void PerdeVida()
        {
            if(vida > 0)
            {
                vidas --;
                vida = 100;
            }
            else if (vida == 0)
            {
                comVida = false;
            }
        }
        public bool VerificaSeplayerVivo()
        {
            return comVida;
        }
        
        private void PerdVida()
        {
            if(vida > 0)
            {
                vidas --;
                vida = 100;
            }
            else if (vida == 0)
            {
                comVida = false;
            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("portal"))
            {
                nomePorta = other.gameObject.GetComponent<porta>().NomePortal();
                entrada = other.gameObject.GetComponent<porta>().EntradaOuSaida();
            }
        }
        
        private void OnTriggerStay2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("portal"))
            {
                SceneManager.LoadScene(other.gameObject.GetComponent<porta>().NomeCena());
            }
        }
            
    }

 

