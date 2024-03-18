using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class ChangeSortOrder : MonoBehaviour
{
    public Canvas canvas;

    public void IncreaseSortOrder()
    {
        canvas.sortingOrder = 11;
    }

    public void DecreaseSortOrder()
    {
        canvas.sortingOrder = 9;
    }
}
