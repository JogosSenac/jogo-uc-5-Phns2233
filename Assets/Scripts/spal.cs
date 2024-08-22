
using UnityEngine;
using UnityEngine.UIElements;

public class spal : MonoBehaviour
{
    public GameObject player;
    public float px;
    public float py;
    public Vector3 pontoDeRentrada;
    public float posicaoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        pontoDeRentrada = transform.position;
        player = GameObject.FindWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Position == pontoDeRentrada)
        {
            this.gameObject.Position = pontoDeRentrada;
                
        }*/
    }
    
}

