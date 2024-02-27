using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    
    [field: Header("Investigation SFX")] 
    [field: SerializeField] public EventReference evidence { get; private set; }
    [field: SerializeField] public EventReference doorKnock { get; private set; } 
    [field: SerializeField] public EventReference doorOpen { get; private set; }
    [field: SerializeField] public EventReference doorClose { get; private set; }
    [field: SerializeField] public EventReference journalOpen { get; private set; }
    [field: SerializeField] public EventReference journalFlick { get; private set; }
    [field: SerializeField] public EventReference journalClose { get; private set; }
    
    [field: SerializeField] public EventReference lockScroll { get; private set; }
    
    [field: SerializeField] public EventReference lockOpen { get; private set; }
    
    [field: Header("Music")] 
    [field: SerializeField] public EventReference investigationMusic { get; private set; }
    [field: SerializeField] public EventReference HappyMusic { get; private set; }
    
    //field makes it so that this shows up in the editor even though it's a public get and private set
    

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Girl why is there more than one FMODEvents in the scene? Take it out smh");
        }

        instance = this;
    }
}
