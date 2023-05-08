using UnityEngine;

public class GrappleRope : MonoBehaviour
{
    [Header("General refrences:")]
    public GrapplingGun grapplingGun;
    public PlayerMovement playerMovement;
    [SerializeField] LineRenderer m_lineRenderer;

    [Header("General Settings:")]
    [SerializeField] private int precision = 20;
    [Range(0, 100)][SerializeField] private float straightenLineSpeed = 4;

    [Header("Animation:")]
    public AnimationCurve ropeAnimationCurve;
    [SerializeField] [Range(0.01f, 4)] private float WaveSize = 20;
    float waveSize;
    Animator myAnimator;

    [Header("Rope Speed:")]
    public AnimationCurve ropeLaunchSpeedCurve;
    [SerializeField] [Range(1, 50)] private float ropeLaunchSpeedMultiplayer = 4;

    float moveTime = 0;

    public bool isGrappling = false;
    
    bool drawLine = true;
    bool straightLine = true;
    

    // void Start() 
    // {
    //     myAnimator = GetComponent<Animator>();
    // }
    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_lineRenderer.enabled = false;
        m_lineRenderer.positionCount = precision;
        waveSize = WaveSize;
        
    }

    private void OnEnable()
    {
        moveTime = 0;
        m_lineRenderer.enabled = true;
        m_lineRenderer.positionCount = precision;
        waveSize = WaveSize;
        straightLine = false;
        LinePointToFirePoint();
        // playerMovement.enabled = true;
    }

    private void OnDisable()
    {
        m_lineRenderer.enabled = false;
        isGrappling = false;
        // playerMovement.enabled = false;
    }

    void LinePointToFirePoint()
    {
        for (int i = 0; i < precision; i++)
        {
            m_lineRenderer.SetPosition(i, grapplingGun.firePoint.position);
        }
    }

    void Update()
    {
        moveTime += Time.deltaTime;

        if (drawLine)
        {
            DrawRope();
        }
        // if(isGrappling)
        // {
        //     myAnimator.SetBool("isGrappling", true);
        // }
        // else
        // {
        //     myAnimator.SetBool("isGrappling", false);
        // }
    }

    void DrawRope()
    {
        if (!straightLine) 
        {
            if (m_lineRenderer.GetPosition(precision - 1).x != grapplingGun.grapplePoint.x)
            {
                DrawRopeWaves();
            }
            else 
            {
                straightLine = true;
            }
        }
        else 
        {
            if (!isGrappling) 
            {
                grapplingGun.Grapple();
                isGrappling = true;
            }
            if (waveSize > 0)
            {
                waveSize -= Time.deltaTime * straightenLineSpeed;
                DrawRopeWaves();
            }
            else 
            {
                waveSize = 0;
                DrawRopeNoWaves();
            }
        }
    }

    void DrawRopeWaves() 
    {
        for (int i = 0; i < precision; i++)
        {
            float delta = (float)i / ((float)precision - 1f);
            Vector2 offset = Vector2.Perpendicular(grapplingGun.grappleDistanceVector).normalized * ropeAnimationCurve.Evaluate(delta) * waveSize;
            Vector2 targetPosition = Vector2.Lerp(grapplingGun.firePoint.position, grapplingGun.grapplePoint, delta) + offset;
            Vector2 currentPosition = Vector2.Lerp(grapplingGun.firePoint.position, targetPosition, ropeLaunchSpeedCurve.Evaluate(moveTime) * ropeLaunchSpeedMultiplayer);

            m_lineRenderer.SetPosition(i, currentPosition);
        }
    }

    void DrawRopeNoWaves() 
    {
        m_lineRenderer.positionCount = 2;
        m_lineRenderer.SetPosition(0, grapplingGun.grapplePoint);
        m_lineRenderer.SetPosition(1, grapplingGun.firePoint.position);
    }

}