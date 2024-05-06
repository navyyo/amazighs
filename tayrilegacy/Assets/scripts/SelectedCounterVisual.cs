using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject visualGameObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInteract.Instance.OnSelectedCounterChanged += PlayerInteract_OnSelectedCounterChanged;
    }

    private void PlayerInteract_OnSelectedCounterChanged(object sender, PlayerInteract.OnSelectedCounterChangedEventArgs e)
    {
       if(e.selectedCounter ==  baseCounter)
        { Show(); }
       else {  Hide(); }
    }
    private void Show()
    {
        visualGameObject.SetActive(true);
    }
    private void Hide()
    {
        visualGameObject?.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
