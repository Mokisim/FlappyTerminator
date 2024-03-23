using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string JumpInput = "Jump";
    
    public bool GetJumpInput()
    {
        return Input.GetButtonDown(JumpInput);
    }

    public bool GetShootInput()
    {
        return Input.GetKeyDown(KeyCode.Mouse0);
    }
}
