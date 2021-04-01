using UnityEngine;

public class NPCDataGenerator : MonoBehaviour
{
    private static NPCLocationsSO _npcLocationsSo;
    public NPCNames _npcNames;

    public float employedRatio;
    public float homelessRatio;
    public float lastNameRatio;

    public AnimationCurve ageCurve;
    public AnimationCurve healthCurve;
    public AnimationCurve mentalHealthCurve;

    private void Awake()
    {
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        if (_npcNames == null) _npcNames = this.gameObject.GetComponent<NPCNames>();
    }

    public NPCData AssignCharacterData(NPCData data)
    {
        AssignGender(data);
        AssignFirstName(data);
        AssignAge(data);
        AssignJob(data);
        //AssignHome(data);
        AssignCurrentHealth(data);
        AssignCurrentMentalHealth(data);
        AssignCurrentHunger(data);
        AssignCurrentFatigue(data);
        AssignCurrentMoney(data);

        return data;
    }






    private void AssignGender(NPCData data)
    {
        data.isMale = (Random.value > 0.5f);
    }

    private void AssignFirstName(NPCData data)
    {
        if (data.isMale) data.firstName = _npcNames.maleNames[Random.Range(0, _npcNames.maleNames.Count)];
            else data.firstName = _npcNames.femaleNames[Random.Range(0, _npcNames.femaleNames.Count)];
    }

    private void AssignAge(NPCData data)
    {
        data.age = Mathf.FloorToInt(ageCurve.Evaluate(Random.value));
        data.birthday = Random.Range(1, 365);
    }

    private void AssignJob(NPCData data)
    {
        data.isEmployed = (Random.value < employedRatio);
        if (data.isEmployed)
        {
            data.workplace = "test";
            data.workplaceIdentifier = Random.Range(0, _npcLocationsSo.jobList.Count);
        }
    }


    private void AssignHome(NPCData data)
    {
        data.hasHome = (Random.value > homelessRatio);

        if (data.hasHome)
        {
            data.homeType = Random.Range(0, 2);
            data.homeIdentifier = Random.Range(0, _npcLocationsSo.homeList.Count);
        }
    }
    
    
    //Assign Stats
    private void AssignCurrentHealth(NPCData data)
    {
        data.currentHealth = Random.Range(50, 100);
    }
    
    private void AssignCurrentMentalHealth(NPCData data)
    {
        data.currentMentalHealth = Random.Range(25, 100);
    }
    
    private void AssignCurrentHunger(NPCData data)
    {
        data.currentHunger = Random.Range(50, 100);
    }
    
    private void AssignCurrentFatigue(NPCData data)
    {
        data.currentEnergy = Random.Range(50, 100);
    }
    
    private void AssignCurrentMoney(NPCData data)
    {
        data.currentMoney = Random.Range(5, 1000);
    }

}

