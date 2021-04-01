using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateNPCStatsText : MonoBehaviour
{
    public static UpdateNPCStatsText instance;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcAge;
    public TextMeshProUGUI npcHome;
    public TextMeshProUGUI npcWorkplace;

    private void Awake()
    {
        instance = this;
    }

    public void UpdateText(NPCData data)
    {
        npcName.SetText(data.firstName + " " + data.lastName);
        npcAge.SetText("Age: " + data.age.ToString());
        npcHome.SetText("HomeID: " + data.homeIdentifier.ToString());
        npcWorkplace.SetText("Workplace: " + data.workplace);

    }
}
