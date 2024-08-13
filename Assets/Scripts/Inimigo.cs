using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inimigo : MonoBehaviour
{
    
    public Transform player; // Referência ao transform do jogador
    public float moveSpeed = 3f; // Velocidade de movimento do inimigo
    public float stopDistance = 5f; // Distância a partir da qual o inimigo para de seguir o jogador
    public SpriteRenderer spriteR;
    public Animator anim;
    private bool isFollowing = true; // Variável de controle do estado de seguir
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player != null && isFollowing)
        {
            // Calcula a direção para onde o inimigo deve se mover
            Vector2 moveDirection = (player.position - transform.position).normalized;

            // Move o inimigo na direção calculada
            rb.velocity = moveDirection * moveSpeed;

           /* // Ajusta a rotação do inimigo para olhar na direção do movimento
           if (moveDirection != Vector2.one)
            {
                float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }*/

            // Verifica se o inimigo está próximo o suficiente para parar de seguir
            if (Vector2.Distance(transform.position, player.position) <= stopDistance)
            {
                isFollowing = false;
                rb.velocity = Vector2.zero; // Para o movimento do inimigo
            }

            if (player.position.x > transform.position.x )
            {
              anim.SetLayerWeight(0,1);
              //spriteR.flipY = false;
            }
            else if(player.position.x < transform.position.x)
            {
                anim.SetLayerWeight(0,1);
                //spriteR.flipY = true;
            }
            if(this.gameObject.CompareTag("Player"))
            {
                Destroy(this.gameObject);
            }
        }
    }

   /*     private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("batalha");
        }
    }*/
}
