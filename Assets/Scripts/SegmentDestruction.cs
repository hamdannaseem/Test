using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentDestruction : MonoBehaviour
{
    public string parentName;
    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroySegment());
    }
    IEnumerator DestroySegment()
    {
        yield return new WaitForSeconds(50);
        if (parentName == "Segment(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
