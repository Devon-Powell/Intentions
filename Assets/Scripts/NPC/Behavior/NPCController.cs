using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPCController : MonoBehaviour
{
    private NPCData _npcData;
    private static NPCLocationsSO _npcLocationsSo;

    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    public AnimationCurve speedCurve;

    public bool hasGoal;

    public Vector3 rnd;

    public float checkTime;

    private void Awake()
    {
        _npcLocationsSo = Resources.Load<NPCLocationsSO>("ScriptableObjects/NPCLocations");
        _npcData = gameObject.GetComponent<NPCData>();

        character = gameObject.GetComponent<ThirdPersonCharacter>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.avoidancePriority = Mathf.RoundToInt(Random.Range(0f, 200f));

        checkTime = 1f;

        //StartCoroutine(SelectNewLocation(1f));
    }

    private void Update()
    {
        character.Move(agent.remainingDistance > agent.stoppingDistance ? agent.desiredVelocity : Vector3.zero, false,
            false);
    }


    private IEnumerator SelectNewLocation(float waitTime)
    {
        while (true)
        {
            int rnd = Random.Range(1, 5);
            ChooseNewDestination(rnd);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void ChooseNewDestination(int location)
    {
        agent.speed = speedCurve.Evaluate(Random.value);

        switch (location)
        {
            case 1:
                Vector3 targetHome = _npcLocationsSo.homeList[_npcData.homeIdentifier].location;
                agent.SetDestination(targetHome);
                break;

            case 2:
                Vector3 targetJob = _npcLocationsSo.jobList[_npcData.workplaceIdentifier].location;
                agent.SetDestination(targetJob);
                break;

            case 3:
                int randomShop = Random.Range(0, _npcLocationsSo.shopList.Count);
                Vector3 targetShop = _npcLocationsSo.shopList[randomShop].location;
                agent.SetDestination(targetShop);
                break;

            case 4:
                int randomRecreation = Random.Range(0, _npcLocationsSo.recreationalList.Count);
                //Vector3 targetRecreation = _npcLocations.recreationalList[randomRecreation].location;
                //agent.SetDestination(targetRecreation);
                break;
        }
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private IEnumerator WaitUntilArrived(float waitTime)
    {
        while (true)
        {
            
            yield return new WaitForSeconds(checkTime);
        }
    }
}