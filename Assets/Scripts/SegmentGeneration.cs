using System.Collections;
using UnityEngine;

public class SegmentGeneration : MonoBehaviour
{
    public GameObject[] Sections;
    int zPosition = 50;
    public bool CreatingSections = false;
    public int RandomSection;
    void Update()
    {
        if (!CreatingSections && !PlayerMovement.GameOver)
        {
            CreatingSections = true;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        RandomSection = Random.Range(0, Sections.Length);
        GameObject newSection = Instantiate(Sections[RandomSection], new Vector3(-2, 1, zPosition), Quaternion.identity);
        newSection.SetActive(true);
        zPosition += 30;
        yield return new WaitForSeconds(2);
        CreatingSections = false;
    }
}
