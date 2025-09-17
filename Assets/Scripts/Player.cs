using UnityEngine;

public class Player : MonoBehaviour
{
    #region Configura��es Serializadas

    [Header("Movement Settings")]
    [SerializeField] private float maxForwardSpeed = 10f;       //Velocidade m�xima para frente
    [SerializeField] private float acceleration = 5f;           //Taxa de acelera��o
    [SerializeField] private float deceleration = 2f;           //Taxa de desacelera��o
    [SerializeField] private float backwardSpeedRatio = 0.5f;   //50% da velocidade m�xima para tr�s
    
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 180f;        //Velocidade de rota��o em graus por segundo

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;          //Prefab do proj�til
    [SerializeField] private Transform muzzle;                 //Ponto de origem dos tiros
    [SerializeField] private float bulletSpeed = 15f;          //Velocidade dos proj�teis
    [SerializeField] private float fireRate = 0.3f;            //Intervalo entre tiros

    #endregion

    #region Vari�veis Privadas

    //Componentes e controle de movimento
    private Rigidbody2D rb;                                     //Refer�ncia ao componente Rigidbody2D
    private Vector2 currentVelocity;                            //Velocidade atual do jogador
    private float lastFireTime;                                 //Timestamp do �ltimo tiros
    private float maxBackwardSpeed;                             //Velocidade m�xima calculada para tr�s

    //Vari�veis para o sistema de wraparound (teleporte pelas bordas)
    private Camera mainCamera;                                  //refer�ncia � c�mera principal
    private float acreenLeft, screenRight;                      //Limites horizontais da tela
    private float screenTop, screenBotton;                      //Limites verticais da tela
    private float playerWidth, playerHeight;                    //Dimens�es do jogador

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
