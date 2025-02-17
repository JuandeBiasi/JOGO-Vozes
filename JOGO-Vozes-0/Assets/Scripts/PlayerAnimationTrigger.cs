using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTrigger : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void animationTrigger()
       
    {
        player.StateMachine.currentState.AnimationFinishTrigger();
    }


}
