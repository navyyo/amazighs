using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour
{
    public GameObject[] pages;
    private int currentPageIndex = 0;

    void Start()
    {
        UpdatePageVisibility();
    }

    // Call this method when the page is flipped
    public void OnFlip()
    {
        // Increment the page index and wrap around if necessary
        currentPageIndex = (currentPageIndex + 1) % pages.Length;
        UpdatePageVisibility();
    }

    // Update the visibility of pages
    private void UpdatePageVisibility()
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(i == currentPageIndex);
        }
    }
}

