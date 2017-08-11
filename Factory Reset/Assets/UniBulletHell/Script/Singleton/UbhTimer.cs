using UnityEngine;

/// <summary>
/// Ubh timer.
/// </summary>
[DisallowMultipleComponent]
public sealed class UbhTimer : UbhSingletonMonoBehavior<UbhTimer>
{
    private const float FPS_60_DELTA = (1f / 60f);

    private float m_deltaTime;
    private float m_deltaFrameCount;
    private float m_frameCount;
    private bool m_pausing;

    /// <summary>
    /// Get delta time of UniBulletHell.
    /// </summary>
    public float deltaTime { get { return m_pausing ? 0f : m_deltaTime; } }

    /// <summary>
    /// Get delta frame count of UniBulletHell.
    /// </summary>
    public float deltaFrameCount { get { return m_pausing ? 0f : m_deltaFrameCount; } }

    /// <summary>
    /// Get frame count of UniBulletHell.
    /// </summary>
    public float frameCount { get { return m_frameCount; } }

    /// <summary>
    /// Get pause flag
    /// </summary>
    public bool pausing { get { return m_pausing; } }

    protected override void Awake()
    {
        base.Awake();
        UpdateTimes();
    }

    private void Update()
    {
        UpdateTimes();
        UbhBulletManager.instance.UpdateBullets();
    }

    private void UpdateTimes()
    {
        m_deltaTime = Time.deltaTime;
        m_deltaFrameCount = m_deltaTime / FPS_60_DELTA;

        if (m_pausing == false)
        {
            m_frameCount += m_deltaFrameCount;
        }
    }

    /// <summary>
    /// Pause time of UniBulletHell.
    /// </summary>
    public void Pause()
    {
        m_pausing = true;
    }

    /// <summary>
    /// Resume time of UniBulletHell.
    /// </summary>
    public void Resume()
    {
        m_pausing = false;
    }
}