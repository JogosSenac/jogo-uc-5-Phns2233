using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    public string cena;
    public string nome;
    public bool entrada;

    public string NomePortal()
    {
        return nome;
    }
    public bool EntradaOuSaida()
    {
        return entrada;
    }

    public string NomeCena()
    {
        return cena;
    }
}
//em nome coloca o nome da Cena e em cena para onde ele vai