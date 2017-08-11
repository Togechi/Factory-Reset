using UnityEngine;

/// <summary>
/// Ubh bullet.
/// </summary>
[DisallowMultipleComponent]
public class UbhBullet : UbhMonoBehaviour
{
    private Transform m_transformCache;
    private UbhBaseShot m_parentBaseShot;
    private float m_speed;
    private float m_angle;
    private float m_accelSpeed;
    private float m_accelTurn;
    private bool m_homing;
    private Transform m_homingTarget;
    private float m_homingAngleSpeed;
    private bool m_wave;
    private float m_waveSpeed;
    private float m_waveRangeSize;
    private bool m_pauseAndResume;
    private float m_pauseTime;
    private float m_resumeTime;
    private UbhUtil.AXIS m_axisMove;

    private float m_selfFrameCnt;
    private float m_selfTimeCount;

    private UbhTentacleBullet m_tentacleBullet;

    public bool shooting { get; private set; }

    public UbhBaseShot parentShot { get { return m_parentBaseShot; } }

    private void Awake()
    {
        m_transformCache = transform;
        m_tentacleBullet = GetComponent<UbhTentacleBullet>();
    }

    private void OnDisable()
    {
        m_parentBaseShot = null;
        m_transformCache.ResetPosition();
        m_transformCache.ResetRotation();
        shooting = false;
    }

    /// <summary>
    /// Bullet Shot
    /// </summary>
    public void Shot(UbhBaseShot parentBaseShot,
                     float speed, float angle, float accelSpeed, float accelTurn,
                     bool homing, Transform homingTarget, float homingAngleSpeed,
                     bool wave, float waveSpeed, float waveRangeSize,
                     bool pauseAndResume, float pauseTime, float resumeTime, UbhUtil.AXIS axisMove)
    {
        if (shooting)
        {
            return;
        }
        shooting = true;

        m_parentBaseShot = parentBaseShot;

        m_speed = speed;
        m_angle = angle;
        m_accelSpeed = accelSpeed;
        m_accelTurn = accelTurn;
        m_homing = homing;
        m_homingTarget = homingTarget;
        m_homingAngleSpeed = homingAngleSpeed;
        m_wave = wave;
        m_waveSpeed = waveSpeed;
        m_waveRangeSize = waveRangeSize;
        m_pauseAndResume = pauseAndResume;
        m_pauseTime = pauseTime;
        m_resumeTime = resumeTime;
        m_axisMove = axisMove;

        if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
        {
            // X and Z axis
            m_transformCache.SetEulerAnglesY(-m_angle);
        }
        else
        {
            // X and Y axis
            m_transformCache.SetEulerAnglesZ(m_angle);
        }

        m_selfFrameCnt = 0f;
        m_selfTimeCount = 0f;
    }

    /// <summary>
    /// Update Move
    /// </summary>
    public void UpdateMove()
    {
        if (shooting == false)
        {
            return;
        }

        float deltaTime = UbhTimer.instance.deltaTime;
        m_selfTimeCount += deltaTime;

        // pause and resume.
        if (m_pauseAndResume && m_pauseTime >= 0f && m_resumeTime > m_pauseTime)
        {
            if (m_pauseTime <= m_selfTimeCount && m_selfTimeCount < m_resumeTime)
            {
                return;
            }
        }

        if (m_homing)
        {
            // homing target.
            if (m_homingTarget != null && 0f < m_homingAngleSpeed)
            {
                float rotAngle = UbhUtil.GetAngleFromTwoPosition(m_transformCache, m_homingTarget, m_axisMove);
                float myAngle = 0f;
                if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
                {
                    // X and Z axis
                    myAngle = -m_transformCache.eulerAngles.y;
                }
                else
                {
                    // X and Y axis
                    myAngle = m_transformCache.eulerAngles.z;
                }

                float toAngle = Mathf.MoveTowardsAngle(myAngle, rotAngle, deltaTime * m_homingAngleSpeed);

                if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
                {
                    // X and Z axis
                    m_transformCache.SetEulerAnglesY(-toAngle);
                }
                else
                {
                    // X and Y axis
                    m_transformCache.SetEulerAnglesZ(toAngle);
                }
            }

        }
        else if (m_wave)
        {
            // acceleration turning.
            m_angle += (m_accelTurn * deltaTime);
            // wave.
            if (0f < m_waveSpeed && 0f < m_waveRangeSize)
            {
                float waveAngle = m_angle + (m_waveRangeSize / 2f * Mathf.Sin(m_selfFrameCnt * m_waveSpeed / 100f));
                if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
                {
                    // X and Z axis
                    m_transformCache.SetEulerAnglesY(-waveAngle);
                }
                else
                {
                    // X and Y axis
                    m_transformCache.SetEulerAnglesZ(waveAngle);
                }
            }
            m_selfFrameCnt += UbhTimer.instance.deltaFrameCount;
        }
        else
        {
            // acceleration turning.
            float addAngle = m_accelTurn * deltaTime;
            if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
            {
                // X and Z axis
                m_transformCache.Rotate(0f, -addAngle, 0f);
            }
            else
            {
                // X and Y axis
                m_transformCache.Rotate(0f, 0f, addAngle);
            }
        }

        // acceleration speed.
        m_speed += (m_accelSpeed * deltaTime);

        // move.
        if (m_axisMove == UbhUtil.AXIS.X_AND_Z)
        {
            // X and Z axis
            m_transformCache.position += m_transformCache.forward * m_speed * deltaTime;
        }
        else
        {
            // X and Y axis
            m_transformCache.position += m_transformCache.up * m_speed * deltaTime;
        }

        if (m_tentacleBullet != null)
        {
            // Update tentacles
            m_tentacleBullet.UpdateRotate();
        }
    }
}