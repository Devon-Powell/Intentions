using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRandomSeed : MonoBehaviour
{
    private SetRandomSeedSO _setRandomSeedSo;
    public void Awake()
    {
        _setRandomSeedSo = Resources.Load<SetRandomSeedSO>("ScriptableObjects/GameData/SetRandomSeedSO");
        
        if (_setRandomSeedSo.useStringSeed)
            _setRandomSeedSo.seed = _setRandomSeedSo.stringSeed.GetHashCode();

        else if (_setRandomSeedSo.randomizeSeed)
            _setRandomSeedSo.seed = Random.Range(0, 999999);

        Random.InitState(_setRandomSeedSo.seed);
        
        for(int i = 0; i < _setRandomSeedSo.values.Length; i++)
        {
            _setRandomSeedSo.values[i] = Random.Range(0, 10);
        }
    }
}
