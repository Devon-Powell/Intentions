using UnityEngine;

public class NPCDataGenerator : MonoBehaviour
{
    private NPCGenerationDataSO _npcGenerationDataSO;

    public void Awake()
    {
        _npcGenerationDataSO = Resources.Load<NPCGenerationDataSO>("ScriptableObjects/GameData/NPCGenerationDataSO");
    }

    public void AssignCharacterData(NPCData data)
    {
        //Debug.Log(_npcGenerationDataSO.femaleNames[1].ToString());
        AssignGender(data);
        AssignFirstName(data);
        AssignLastName(data);
        AssignAge(data);
        AssignJob(data);
        //AssignHome(data);
        AssignCurrentHealth(data);
        AssignCurrentMentalHealth(data);
        AssignCurrentHunger(data);
        AssignCurrentFatigue(data);
        AssignCurrentMoney(data);
    }






    private void AssignGender(NPCData data)
    {
        data.isMale = Random.value > 0.5f;
    }

    private void AssignFirstName(NPCData data)
    {
        if (data.isMale) 
            data.firstName = _npcGenerationDataSO.maleNames[Random.Range(0, _npcGenerationDataSO.maleNames.Count)];
        else 
            data.firstName = _npcGenerationDataSO.femaleNames[Random.Range(0, _npcGenerationDataSO.femaleNames.Count)];
    }

    private void AssignLastName(NPCData data)
    {
        data.lastName = _npcGenerationDataSO.lastNames[Random.Range(0, _npcGenerationDataSO.lastNames.Count)];
    }

    private void AssignAge(NPCData data)
    {
        data.age = Mathf.FloorToInt(_npcGenerationDataSO.ageCurve.Evaluate(Random.value));
        data.birthday = Random.Range(1, 365);
    }

    private void AssignJob(NPCData data)
    {
        data.isEmployed = Random.value < _npcGenerationDataSO.employedRatio;
        if (data.isEmployed)
        {
            data.workplace = "test";
            //data.workplaceIdentifier = Random.Range(0, _npcLocationDataSO.jobList.Count);
        }
    }


    private void AssignHome(NPCData data)
    {
        data.hasHome = Random.value > _npcGenerationDataSO.homelessRatio;

        if (data.hasHome)
        {
            data.homeType = Random.Range(0, 2);
            //data.homeIdentifier = Random.Range(0, _npcLocationDataSO.homeList.Count);
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

