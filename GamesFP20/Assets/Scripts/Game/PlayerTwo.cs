using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
///  This class handles all behaviours associated with the second Player
/// character and his interactions with the game world.
/// </summary>
public class PlayerTwo : Player
{

    // Start is called before the first frame update
    public new void Start()
    {
        controller = GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("HorizontalTwo"), Input.GetButtonDown("JumpTwo"));
    }
}
