using UnityEngine;

public class patrolState : BaseState
{
    public int wayPointIndex;
    public float waitTimer;
    public override void Enter()
    {
        
    }
    public override void Perform()
    {
        PatrolCycle();
    }
    public override void Exit()
    {
        
    }

    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if(waitTimer > 3 )
            {
                if(wayPointIndex < enemy.path.wayPoints.Count - 1)
                {
                    wayPointIndex++;
                    Debug.Log(wayPointIndex);
                }
                else
                {
                    wayPointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointIndex].position);
                waitTimer = 0;
            }
        }
    }
}
