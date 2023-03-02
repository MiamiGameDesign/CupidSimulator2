using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject textBox;
    float timer;
    void Start()
    {
        StartCoroutine(Sequence());
    }
    IEnumerator Sequence()
    {
        while (true)
        {
            timer += Time.deltaTime;
            textBox.GetComponent<Text>().text = "Time: " + (Mathf.Round(timer * 10) / 10);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
