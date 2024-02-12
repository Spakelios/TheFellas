using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsMenu : MonoBehaviour
{
  private SaveSlot[] saveSlots;

  private void Start()
  {
    ActivateMenu();
  }

  private void Awake()
  {
    saveSlots = this.GetComponentsInChildren<SaveSlot>();
  }

  public void ActivateMenu()
  {
    Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetALlProfilesGameData();

    foreach (SaveSlot saveSlot in saveSlots)
    {
      GameData profileData = null;
      
      profilesGameData.TryGetValue(saveSlot.GetProfileId(), out profileData);
      
      saveSlot.SetData(profileData);
      
      if (profileData == null)
      {
        saveSlot.SetInteractable(false);
      }
      else
      {
        saveSlot.SetInteractable(true);

      }
    }
  }
}