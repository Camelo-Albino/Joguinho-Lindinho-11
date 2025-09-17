using UnityEngine;

public class Player : MonoBehaviour
{
    #region Configurações Serializadas

    [Header("Movement Settings")]
    [SerializeField] private float maxForwardSpeed = 10f;       //Velocidade máxima para frente
    [SerializeField] private float acceleration = 5f;           //Taxa de aceleração
    [SerializeField] private float deceleration = 2f;           //Taxa de desaceleração
    [SerializeField] private float backwardSpeedRatio = 0.5f;   //50% da velocidade máxima para trás
    
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 180f;        //Velocidade de rotação em graus por segundo

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;          //Prefab do projétil
    [SerializeField] private Transform muzzle;                 //Ponto de origem dos tiros
    [SerializeField] private float bulletSpeed = 15f;          //Velocidade dos projéteis
    [SerializeField] private float fireRate = 0.3f;            //Intervalo entre tiros

    #endregion

    #region Variáveis Privadas

    //Componentes e controle de movimento
    private Rigidbody2D rb;                                     //Referência ao componente Rigidbody2D
    private Vector2 currentVelocity;                            //Velocidade atual do jogador
    private float lastFireTime;                                 //Timestamp do último tiros
    private float maxBackwardSpeed;                             //Velocidade máxima calculada para trás

    //Variáveis para o sistema de wraparound (teleporte pelas bordas)
    private Camera mainCamera;                                  //referência à câmera principal
    private float acreenLeft, screenRight;                      //Limites horizontais da tela
    private float screenTop, screenBotton;                      //Limites verticais da tela
    private float playerWidth, playerHeight;                    //Dimensões do jogador

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
