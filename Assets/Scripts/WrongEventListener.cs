using UnityEngine;

//Small script which triggers the Wrong answer animation whenever the player triggers the incorrect event. 
[RequireComponent(typeof(Animator))]
public class WrongEventListener : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        MouseSelectionData._instance.onIncorrect += TriggerWrong;
    }

    public void TriggerWrong()
    {
        anim.SetTrigger("WrongTrigger");
    }
}
