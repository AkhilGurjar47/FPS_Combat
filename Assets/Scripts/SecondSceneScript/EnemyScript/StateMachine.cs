using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public patrolState patrolStat;
    public void Initialise()
    {
        patrolStat = new patrolState();  
        ChangeState(patrolStat);
    }

    private void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }
        activeState = newState;
        if (activeState != null)
        {
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }
}
