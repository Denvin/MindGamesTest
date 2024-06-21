using System.Collections.Generic;
using UnityEngine;

public class FieldController : MonoBehaviour
{
    private List<int> _trueIndexes = new List<int>();

    public List<int> TrueIndexes => _trueIndexes;


    public void SetIndexes(int index)
    {
        _trueIndexes.Add(index);
    }
}
