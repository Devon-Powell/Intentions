using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSelectionIndicator : MonoBehaviour
{
    public Gradient happinessGradient;

    [SerializeField] private Renderer rend;
    [SerializeField] private Transform followTarget;

    private NPCData npcData;
    private NPCStats npcStats;

    [SerializeField]
    private float dampening = 7;
    [SerializeField]
    private float rotationSpeed = 20;

    private bool isFollowing;
    private float waitTime;
    
    private void Awake()
    {
        isFollowing = false;
    }

    private void LateUpdate()
    {
        if (isFollowing && npcStats != null)
        {
            //position = Vector3.Lerp(position, npcData.transform.position, dampening * Time.deltaTime);
            //transform.position = npcStats.transform.position;
            Vector3 followPosition = new Vector3(npcData.transform.position.x, npcData.transform.position.y, npcData.transform.position.z);
            transform.position = Vector3.Lerp(transform.position, followPosition, dampening * Time.deltaTime);
            
        }
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }

    public void SetTarget(NPCData data, NPCStats stats)
    {
        isFollowing = true;
        //Vector3 followPosition = new Vector3(followTarget.position.x, 0, followTarget.position.z);
        Vector3 followPosition = new Vector3(data.transform.position.x, data.transform.position.y, data.transform.position.z);
        transform.position = followPosition;

        npcData = data;
        npcStats = stats;

        StartCoroutine(UpdateColor());
    }

    public void ClearTarget()
    {
        isFollowing = false;
        transform.position = new Vector3(-10000, -10000, -10000);
        StopCoroutine(nameof(UpdateColor));
    }

    public void SetColor()
    {
        float happinessNormalized = Utility.ConvertRange(npcStats.currentHappiness, 0, 100, 0, 1);
        rend.material.SetColor("_BaseColor", happinessGradient.Evaluate(happinessNormalized));
    }

    private IEnumerator UpdateColor()
    {
        SetColor();
        yield return new WaitForSeconds(waitTime);
    }
}
