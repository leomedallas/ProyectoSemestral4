using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextGod1 : MonoBehaviour
{
    string frase = "Felicidades, has sido elegido para un trabajo digno de Dioses";
    public TextMeshProUGUI texto;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1f);
        Text.Destroy(texto);
    }
}
