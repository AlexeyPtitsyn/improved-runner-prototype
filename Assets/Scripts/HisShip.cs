// Player model animations.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2023
using System.Collections;
using UnityEngine;

public class HisShip : MonoBehaviour
{
    private float _time = 0;

    // Coroutines count. Used to prevent animations conflict.
    private int _runningCoroutinesNum = 0;

    private void Update()
    {
        FloatInSpace();
    }

    /**
     * Float player in space. Always running.
     */
    private void FloatInSpace()
    {
        _time += Time.deltaTime * 2;
        transform.localPosition = new Vector3(0, Mathf.Sin(_time) / 8.0f, 0);
    }

    /**
     * Turn to normal direction (bottom down).
     */
    public void TurnNormal()
    {
        if (transform.localEulerAngles.z == 0f) return;
        StartCoroutine(TurnNormalCoroutine());
    }

    IEnumerator TurnNormalCoroutine()
    {
        _runningCoroutinesNum++;
        float countdown = .5f;
        while (countdown > 0)
        {
            countdown -= Time.deltaTime;

            float rotationAngle = Time.deltaTime * 180.0f;
            transform.Rotate(new Vector3(0, 0, rotationAngle * 2));

            yield return new WaitForEndOfFrame();
        }

        if (transform.localEulerAngles.z > 0)
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        _runningCoroutinesNum--;
    }

    /**
     * Turn (over z axis). Upside down.
     */
    public void TurnOver()
    {
        if (transform.localEulerAngles.z == 180f) return;
        StopAllCoroutines();
        _runningCoroutinesNum = 0;
        StartCoroutine(TurnOverCoroutine());
    }

    IEnumerator TurnOverCoroutine()
    {
        _runningCoroutinesNum++;
        transform.localEulerAngles = new Vector3(0, 180, 0);
        float countdown = .5f;
        while(countdown > 0)
        {
            countdown -= Time.deltaTime;

            float rotationAngle = Time.deltaTime * 180.0f;
            transform.Rotate(new Vector3(0, 0, rotationAngle * 2));

            yield return new WaitForEndOfFrame();
        }

        if (transform.localEulerAngles.z > 170)
        {
            transform.localEulerAngles = new Vector3(0, 180, 180);
        }
        _runningCoroutinesNum--;
    }

    /**
     * Roll to left/right or middle.
     * 
     * TODO: make roll animations more smooth.
     */
    public void Roll(int direction)
    {
        if (_runningCoroutinesNum > 0) return;
        if (transform.localEulerAngles.z == 180f) return;

        float targetDegree = direction * 30;

        transform.localEulerAngles = new Vector3(0, 180, targetDegree);
    }
}
