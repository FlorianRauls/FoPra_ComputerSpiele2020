using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int levelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject boy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Boy"));
        GameObject level = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Level/Level"+levelIndex));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
