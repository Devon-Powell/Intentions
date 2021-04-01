using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCNamesData", menuName = "ScriptableObjects/NPCNames")]
public class NPCNamesSO : ScriptableObject
{
     public List<string> maleNames;
     public List<string> femaleNames;
     public List<string> lastNames;
}
