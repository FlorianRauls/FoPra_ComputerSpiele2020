using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject boy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        GameObject level = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level0"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
