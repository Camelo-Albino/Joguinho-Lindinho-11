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

    #region M�todos Unity (lifecycle)
    
    //Inicialização do jogador - configuração de componente e sistema de wraparound
    void Start()
    {
        //Verificar se o RigidBody2D existe, se n�o, adicionar um automaticamente
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            Debug.Log("Rigidbody2D adicionado automaticamente ao player");
        }

        //Calcular velocidade m�xima para tr�s baseada na porpor��o configurada
        maxBackwardSpeed = maxForwardSpeed * backwardSpeedRatio;

        //Configurar o RigidBody2D para movimento especial realista
        rb.linearDamping = 0.5f;                                         //Pequeno arrasto para simular resist�ncia espacial
        rb.angularDamping = 5f;                                    //Arratso angular para estabilizar rota��o
        rb.gravityScale = 0f;                                   //Desabilitar gravidade para jogo espacial

        //Inicializar sistema de wraparound (Teleporte pelas bordas)
        SetupScreenBounds();
    }

    void Update()
    {
        HandleInput();
    }

    //Atualiza��o de f�sica - aplica movimento e verifica wraparound
    void FixedUpdate()
    {
        ApplyMovement();                                        //Aplica velocidade ao Rigidbody2D
        CheckScreenWrap();                                      //Verifica se precisa teleportar pelas bordas
    }

    #endregion

    #region Sistema de Input

    //Processa toda a entrada do usuário (Movimento, rotação, tiro)
    private void HandleInput()
    {
        //Processar entrada de movimento (frente/trás)
        HandleMovementInput();

        //Processar entrada de rotação (esquerda/direita)
        HandleRotationInput();

        //Processar entrada de tiro (espaço)
        HandleShootingInput();
    }
    
    //Processa a entrada de movimento
    //Inclui tratamento de erro para compatibilidade com Input System
    private void HandleMovementInput()
    {
        bool accelerating = false; //Se está acelerando para frente
        bool decelerating = false; // Se está acelerando para trás
        
        //Usar o input.inputString ou verificar se o input system está ativo
        try
        {
            //Verificar teclas de aceleração (frente)
            accelerating = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            //Verificar teclas de desaceleração (trás)
            decelerating = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        }
        catch(System.InvalidOperationException)
        {
            //Fallback para quando o Input System não está configurado corretamente
            Debug.LogWarning("Configura essa merda certo");
            return;
        }

        //Aplicar movimento baseado na entrada
        if (accelerating)
        {
            AccelerateForward();                                 //Acelerar para frente
        }
        else if (decelerating)
        {
            AccelerateBackward();                               //Acelerar para trás
        }
        else
        {
            ApplyDeceleration();                                //Aplicar desaceleração natural
        }
    }

    //Processa entrada de rotação
    //Inclui tratamento de erro para compatibilidade de Input
    private void HandleRotationInput()
    {
        float rotationInput = 0f;                               //Valor de entrada de rotação(-1 a 1)

        try
        {
            //Verificar rotação anti-horária (esquerda)
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rotationInput = 1f; //Rotação anti-horária
            }
            //Verificar rotação horária (direita)
            else if(Input.GetKey(KeyCode.rightArrow) || Input.GetKey(KeyCode.D))
            {
                rotationInput = -1f; //Rotação horária
            }
        }
        catch(System.InvalidOperationException)
        {
            //Fallback para quando o Input System não está configurado corretamente
            Debug.LogWarning("Configura essa merda certo");
            return;
        }

        //Aplicar rotação se há entrada
        if (rotationInput !- 0f)
        {
            RotatePlayer(rotationInput);
        }
    }
}
