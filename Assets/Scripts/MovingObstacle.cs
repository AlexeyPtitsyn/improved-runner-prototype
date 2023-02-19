/**
 * Moving obstacles script.
 */
using System.Collections;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(MoveObstacleCoroutine());
    }

    IEnumerator MoveObstacleLeft()
    {
        while (transform.position.x > -1)
        {
            var tmpPos = transform.position;
            tmpPos.x -= Time.deltaTime;
            transform.position = tmpPos;
            yield return new WaitForEndOfFrame();
        }

        var pos = transform.position;
        pos.x = -1;
        transform.position = pos;
    }

    IEnumerator MoveObstacleRight()
    {
        while (transform.position.x < 1)
        {
            var tmpPos = transform.position;
            tmpPos.x += Time.deltaTime;
            transform.position = tmpPos;
            yield return new WaitForEndOfFrame();
        }

        var pos = transform.position;
        pos.x = 1;
        transform.position = pos;
    }

    IEnumerator MoveObstacleCoroutine()
    {
        while(true)
        {
            yield return MoveObstacleLeft();
            yield return new WaitForSeconds(1);
            yield return MoveObstacleRight();
            yield return new WaitForSeconds(1);
        }
    }
}
