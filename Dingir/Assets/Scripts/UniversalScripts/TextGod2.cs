using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextGod2 : MonoBehaviour
{
    string frase = "Es hora de que pruebes tu arma elegida";
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        yield return new WaitForSeconds(8f);
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        Text.Destroy(texto);
    }
}