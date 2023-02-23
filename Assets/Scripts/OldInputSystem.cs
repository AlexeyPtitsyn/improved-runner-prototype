// Old input system.
// TODO: remove this.
// Copyright Alexey Ptitsyn <alexey.ptitsyn@gmail.com>, 2023

using System.Collections;
using UnityEngine;

public class OldInputSystem : Player
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Controls());
    }

    IEnumerator Controls()
    {
        while (true)
        {
            float hor = Input.GetAxis("Horizontal");
            int horRounded = (int)Mathf.Round(hor);

            _hisShip.Roll(horRounded);
            Move(horRounded);

            bool jump = Input.GetButton("Jump");
            if (jump)
            {
                if (!_inAir)
                {
                    _inAir = true;
                    Jump();
                }
            }

            yield return new WaitForFixedUpdate();
        }
    }
}
