using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRaycast : MonoBehaviour
{
    [SerializeField]
    private LayerMask selectableLayer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, selectableLayer))
            {
                rayHit.collider.GetComponent<OnSelect>().ShowNPCStats();
            }
        }
    }
}
