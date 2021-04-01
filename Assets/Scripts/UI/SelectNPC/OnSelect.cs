using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class OnSelect : MonoBehaviour
{
    public SelectNPC selectNPC;

    //public CameraRigController _cameraRigController;
    public NavMeshAgent agent;
    public NPCData npcData;
    public NPCStats npcStats;
    
    public bool currentlySelected = false;
    

    private void Start()
    {
        //_cameraRigController = GameObject.FindGameObjectWithTag("CameraTarget").GetComponent<CameraRigController>();
        selectNPC = (SelectNPC) FindObjectOfType(typeof(SelectNPC));
        agent = GetComponent<NavMeshAgent>();
        npcData = GetComponent<NPCData>();
        npcStats = GetComponent<NPCStats>();
    }

    public void OnMouseUpAsButton()
    {
        //_cameraRigController.SetFollowTarget(transform);
        UpdateNPCStatsText.instance.UpdateText(npcData);
        UpdateNPCStatBars.instance.SetSelectedNPC(npcData);

        selectNPC.SetTarget(npcData, npcStats);
    }

    private void SelectThisNPC()
    {
        
    }

    private void DeselectThisNPC()
    {
        
    }

    public void ShowNPCStats()
    {
        if (!currentlySelected)
        {
            currentlySelected = true;
            //nameTMP = _npcGenerator.npcDataList.IndexOf(this.gameObject);
        }

        else if (currentlySelected)
        {
            currentlySelected = false;
        }
    }
}
