using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitialSceneManager : MonoBehaviour
{
    public InputField deerGroupsCount;
    public InputField wolfsCount;
    public InputField haresCount;
    
    public void StartSimulation()
    {
        int deerGroups = int.Parse(deerGroupsCount.text);
        int wolfs = int.Parse(wolfsCount.text);
        int hares = int.Parse(haresCount.text);

        SceneManager.LoadScene("Main");
        AnimalsSpawner.Instance.SetAnimalCounts(deerGroups, wolfs, hares);
        AnimalsSpawner.Instance.StartSimulation();
    }
}
