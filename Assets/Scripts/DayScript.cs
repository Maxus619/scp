using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayScript : MonoBehaviour
{
    // TODO: Freeze SCPs' actions on 1 minute

    [SerializeField] GameObject prefab;

    int currentDay = 1;
    int currentSCPs = 0;

    Vector3[] cagesPos = new Vector3[4] {
        new Vector3(-28, -6.42f, 0),
        new Vector3(30, -6.42f, 0),
        new Vector3(-28, -15.4f, 0),
        new Vector3(30, -15.4f, 0)
    };

    void Start()
    {
        // Generating first SCPs in random cell
        switch (Random.Range(1, 5))
        {
            case 1:
                CreateSCP("euclid");
                CreateSCP("safe");
                CreateSCP("safe");
                CreateSCP("safe");
                break;
            case 2:
                CreateSCP("safe");
                CreateSCP("euclid");
                CreateSCP("safe");
                CreateSCP("safe");
                break;
            case 3:
                CreateSCP("safe");
                CreateSCP("safe");
                CreateSCP("euclid");
                CreateSCP("safe");
                break;
            case 4:
                CreateSCP("safe");
                CreateSCP("safe");
                CreateSCP("safe");
                CreateSCP("euclid");
                break;
        }
    }

    // Create SCP by danger class
    void CreateSCP(string danger)
    {
        GameObject SCP = Instantiate<GameObject>(prefab);
        SCP.transform.position = cagesPos[currentSCPs++];
        SCP.name = "SCP" + currentSCPs.ToString();
        SCP.GetComponent<ObjectAI>().danger = danger;

        SCP.AddComponent<WalkToHuman>();
    }

    // Create two SCPs in random cells
    void CreateSCP(string danger1, string danger2)
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                CreateSCP("danger1");
                CreateSCP("danger2");
                break;
            case 2:
                CreateSCP("danger2");
                CreateSCP("danger1");
                break;
        }
    }

    public void StartNewDay()
    {
        switch (++currentDay)
        {
            case 4:
                CreateSCP("safe", "euclid");
                break;
            case 7:
                CreateSCP("safe", "euclid");
                break;
            case 10:
                CreateSCP("safe", "keter");
                break;
            case 13:
                CreateSCP("safe", "euclid");
                break;
        }
    }
}
