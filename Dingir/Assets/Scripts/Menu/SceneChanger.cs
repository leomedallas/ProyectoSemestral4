using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SceneChange());
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
