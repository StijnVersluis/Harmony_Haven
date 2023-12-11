using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/NPCDialogueTreeScriptableObject", order = 1)]
public class NPCDialogueTreeScriptableObject : ScriptableObject
{
    public NPCDialogueScriptableObject dialogue;
    public List<NPCDialogueTreeScriptableObject> next;
}
