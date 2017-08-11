using System.Collections;
using UnityEngine;

/// <summary>
/// Ubh coroutine.
/// </summary>
[DisallowMultipleComponent]
public sealed class UbhCoroutine : UbhSingletonMonoBehavior<UbhCoroutine>
{
    protected override void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Start continue coroutine of object in non-active.
    /// Example : UbhCoroutine.Start (CoroutineMethod());
    /// </summary>
    public static Coroutine StartIE(IEnumerator routine)
    {
        return instance.StartCoroutine(routine);
    }
}
