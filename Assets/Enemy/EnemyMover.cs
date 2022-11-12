using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))] 
public class EnemyMover : MonoBehaviour
{
    [SerializeField] [Range(0f, 5f)] float speed = 1f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridmanager;
    Pathfinder pathfinder;

    void OnEnable()
    {
        transform.Rotate(0,90,0);
        ReturnToStart();
        RecalculatePath(true);
    }

    void Awake() {
        enemy = GetComponent<Enemy>();
        gridmanager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if(resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridmanager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath(coordinates);
        StartCoroutine(FollowPath()); 
    }

    void ReturnToStart()
    {
        transform.position = gridmanager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 1; i < path.Count; i++) 
        {
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = gridmanager.GetPositionFromCoordinates(path[i].coordinates);
                float travelPercent = 0f;
                
                transform.LookAt(endPosition);
                transform.Rotate(0,90,0);

                while(travelPercent <1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        FinishPath();
    }
}
