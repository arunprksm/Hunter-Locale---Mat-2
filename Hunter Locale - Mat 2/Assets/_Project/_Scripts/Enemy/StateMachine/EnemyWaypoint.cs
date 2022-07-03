using UnityEngine;

public class EnemyWaypoint : MonoBehaviour
{
    public EnemyWaypoint WayPoint { get; }
    public EnemyWaypoint(EnemyView enemyView, int position)
    {
        enemyView.EnemyWaypoint.transform.position = new Vector3(enemyView.transform.position.x + position, enemyView.transform.position.y, enemyView.transform.position.z);
        WayPoint = Instantiate(enemyView.EnemyWaypoint);
    }
}
