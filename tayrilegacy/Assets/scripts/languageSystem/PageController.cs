using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageController : MonoBehaviour
{
    public GameObject[] elementsToShowOnFlip;
    public GameObject[] elementsToHideOnFlip;

    // This method will be called whenever the page is flipped
    public void OnFlip()
    {
        // Hide elements when the page is flipped
        foreach (GameObject obj in elementsToHideOnFlip)
        {
            obj.SetActive(false);
        }

        // Show elements when the page is flipped
        foreach (GameObject obj in elementsToShowOnFlip)
        {
            obj.SetActive(true);
        }
    }
}

