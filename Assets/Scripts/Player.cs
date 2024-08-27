

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    private float moveH;
    public float moveV;
    public int velocidade;
    public int  attack;
    public int vidas = 3;
    public bool comVida = true;
    public int dano = 30;
    public int danoSlime = 10;
    public int vidaPlayer = 100;
    private Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sprite;
    public string nomePorta;
    public bool entrada;
    public bool Dano = false;

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
       

        if(Input.GetKeyDown(KeyCode.W)  )
        {
            anim.SetLayerWeight(2,1);
            anim.SetLayerWeight(3,0);
        }
        if(Input.GetKeyDown(KeyCode.S)  )
        {   
            anim.SetLayerWeight(1,1);
            anim.SetLayerWeight(3,0);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            sprite.flipX = false;
            anim.SetLayerWeight(3,1);
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(2,0);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            sprite.flipX = true;
            anim.SetLayerWeight(3,1);
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(2,0);
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetLayerWeight(1,1);
        }
        if(moveH == 0 && moveV == 0)
        {
            anim.SetLayerWeight(0,1);
            anim.SetLayerWeight(1,0);
            anim.SetLayerWeight(2,0);
            anim.SetLayerWeight(3,0);
        }
        if (this.CompareTag("Player")) // Verifica se o objeto que colidiu Ã© o jogador
        {
            this.CompareTag("slime");
            CompareTag("buton1");
        }
        //
    }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("portal"))
            {
                nomePorta = other.gameObject.GetComponent<porta>().NomePortal();
                entrada = other.gameObject.GetComponent<porta>().EntradaOuSaida();
            }
             if (other.CompareTag("Player")) // Verifica se o objeto que colidiu Ã© o jogador
        {
                other.CompareTag("Player");
                Destroy(other.gameObject);
                SceneManager.LoadScene("morte"); // Carrega a cena especificada
        }
        }
        
        private void OnTriggerStay2D(Collider2D other) 
        {
            if(other.gameObject.CompareTag("portal"))
            {
                SceneManager.LoadScene(other.gameObject.GetComponent<porta>().NomeCena());
                Destroy(this.gameObject);
            }
            
        }

        public void tomarDano(int danoSlime)
        {
            vidaPlayer -= danoSlime;
            if (vidaPlayer > 0)
            {
              

            }
        }
    
}



 

