using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class languagepuzzle : MonoBehaviour
{
    [SerializeField] private Text num;
    [SerializeField] private GameObject stone;
    private string ans = "enter";

    public void Number(string inputText)
    {
        num.text += inputText;
    }
    public void Excute()
    {
        if (num.text == ans)
        {
            stone.gameObject.SetActive(false);
        }
        else
        {
            
            StartCoroutine(ResetText());
        }
    }
    IEnumerator ResetText()
    {

        yield return new WaitForSeconds(1f);

        num.text = "";
        num.color = Color.white;
        num.fontSize = 36;
    }
}
