using UnityEngine;
using System.Collections;

public class TargetRandomizerScript : MonoBehaviour
{
    public int keepTargetsAmount = 10;
    void Start()
    {
        targetScript[] targets = FindObjectsOfType<targetScript>();
        int numTargets = targets.Length;
        if (numTargets > keepTargetsAmount)
        {
            int numToRemove = numTargets - keepTargetsAmount;
            bool[] removedIdx = new bool[targets.Length];
            for (int removed = 0; removed < numToRemove; removed++)
            {
                int idxToRemove = Mathf.FloorToInt(Random.Range(0, targets.Length));
                if (removedIdx[idxToRemove])
                {
                    removed--;
                }
                Destroy(targets[idxToRemove].gameObject);
                removedIdx[idxToRemove] = true;
            }
        }
    }

    void Update()
    {

    }
}
