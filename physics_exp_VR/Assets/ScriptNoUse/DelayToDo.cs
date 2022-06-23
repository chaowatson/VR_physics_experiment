using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelayToDo : MonoBehaviour
{
    public static IEnumerator DelayToInvokeDo(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }
}
