using System.Collections;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    [SerializeField] private GameObject kouskous;
    [SerializeField] private GameObject tomatoslice;
    [SerializeField] private GameObject table;

    private void Start()
    {
        tomatoslice.gameObject.SetActive(false);
        kouskous.gameObject.SetActive(false);
    }

    public override void Connect(PlayerInteract player)
    {
        if (!HasKitchenObject())
        {
            Debug.Log("Empty counter");

            if (player.HasKitchenObject())
            {
                Debug.Log("Player does have a kitchen object.");

                // Set kitchen object from player to counter
                SetKitchenObject(player.GetKitchenObject());
                player.ClearKitchenObject();
                GetKitchenObject().SetKitchenObjectParent(this);

                Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
                kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
                kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            }
            else
            {
                Debug.Log("Player empty handed");
            }
        }
        else
        {
            Debug.Log("Counter has kitchen object");

            if (!player.HasKitchenObject())
            {
                Debug.Log("Player doesn't have object and counter does have object");

                counterTopPoint.transform.position = Vector3.zero;
                tomatoslice.gameObject.SetActive(true);
                StartCoroutine(ActivateKouskousAfterDelay());
            }
            else
            {
                Debug.Log("Player has object and counter has object");
            }
        }
    }

    private IEnumerator ActivateKouskousAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        table.gameObject.SetActive(false);// Wait for 2 seconds
        kouskous.SetActive(true);
        tomatoslice.SetActive(false);
    }
}
