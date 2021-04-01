using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNPC : MonoBehaviour
{
    [SerializeField]
    private SetSelectionIndicator setSelectionIndicator;
    [SerializeField]
    private CameraRigController cameraRigController;
    [SerializeField]
    private UpdateNPCStatBars updateNPCStatBars;
    [SerializeField]
    private UpdateNPCStatsText updateNPCText;

    [SerializeField]
    private LayerMask selectableLayer;

    private NPCData npcData;
    private NPCStats npcStats;

    private bool isFollowing;

    public void SetTarget(NPCData data, NPCStats stats)
    {
        npcData = data;
        npcStats = stats;

        SetCameraTarget();
        SetSelectionIndicatorTarget();

        isFollowing = true;
    }

    public void ClearTarget()
    {
        if (isFollowing)
        {
            ClearSelectionIndicatorTarget();
            ClearUITarget();
        }

        isFollowing = false;
    }

    private void SetCameraTarget()
    {
        cameraRigController.SetFollowTarget(npcData.transform);
    }


    private void SetSelectionIndicatorTarget()
    {
        setSelectionIndicator.SetTarget(npcData, npcStats);
    }
    
    private void ClearSelectionIndicatorTarget()
    {
        setSelectionIndicator.ClearTarget();
    }

    private void SetUITarget()
    {
        UpdateNPCStatsText.instance.UpdateText(npcData);
        UpdateNPCStatBars.instance.SetSelectedNPC(npcData);
    }

    private void ClearUITarget()
    {
        UpdateNPCStatBars.instance.ClearSelectedNPC();
    }
}
