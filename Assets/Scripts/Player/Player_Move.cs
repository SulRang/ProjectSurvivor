using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObject;
    public string[] animationNames = new string[6]  // 애니메이션 저장
    { "Idle", "Walk", "Run", "Dead", "Skill", "Attack" };                    
    Animator anim;

    public static bool Right = false;

    static public Player_Move playerMove;
    int animationNumber = 0;
    int playingAnimationNumber = 0;

    public float moveSpeed;
    string lastState;                                       // 플레이어의 상태
    Player player;                                          // 상태패턴 -> 플레이어
    Vector3 Position;                                       // 플레이어의 좌표

    public float Horizontal;
    public float Vertical;

    //재성 추가 변수
    [SerializeField]
    GameObject triggers;

    abstract class PlayerState
    {
        protected Player _player;

        public void SetPlayer(Player player)
        {
            _player = player;
        }

        public abstract void Idle(Player player);
        public abstract void Moving(Player player);
    }

    class PlayerIdle : PlayerState
    {
        public override void Idle(Player player)
        {
            playerMove.animationNumber = 0;
        }
        public override void Moving(Player player)
        {
            _player._Move();
        }
    }

    class PlayerMoving : PlayerState
    {
        public override void Idle(Player player)
        {
            _player._Stop();
        }
        public override void Moving(Player player)
        {
            playerMove.animationNumber = 2;

            if (playerMove.Horizontal > 0)
            {
                Right = false;
            }
            else if (playerMove.Horizontal < 0)
            {
                Right = true;
            }
            playerMove.Position.x += playerMove.Horizontal * Time.deltaTime * playerMove.moveSpeed;
            playerMove.Position.y += playerMove.Vertical * Time.deltaTime * playerMove.moveSpeed;
        }
    }

    class Player
    {
        private PlayerState playerState;

        public Player(PlayerState state)
        {
            this.playerState = state;
        }

        public void _Stop()
        {
            playerState = new PlayerIdle();
            Debug.Log("움직임 정지");
        }

        public void _Move()
        {
            playerState = new PlayerMoving();
            Debug.Log("움직임 시작");
        }

        public PlayerState State
        {
            get
            {
                return playerState;
            }
            set
            {
                playerState = value;
            }
        }
        public void Idle()
        {
            playerState.Idle(this);
        }
        public void Move()
        {
            playerState.Moving(this);
        }
    }

    public void PlayAnimation()
    {
        Animator[] animators = GetComponentsInChildren<Animator>();
        foreach (Animator anim in animators)
        {
            anim.SetBool(animationNames[playingAnimationNumber], false);
            anim.SetBool(animationNames[animationNumber], true);
        }
        playingAnimationNumber = animationNumber;
    }

    void CurrentCharacter()
    {
        if (Right)
        {
            transform.localScale = new Vector3(1, 1, -1);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        cameraObject.transform.position = new Vector3(Position.x, Position.y, Position.z - 10);
        transform.position = Vector3.Lerp(transform.position, Position, 0.5f);
        triggers.GetComponent<ObjectInitializer>().RotationInit(); // 재성 추가 부분
    }

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(new PlayerIdle());
        playerMove = gameObject.GetComponent<Player_Move>();

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");       // x축
        Vertical = Input.GetAxis("Vertical");           // y축
        //Debug.Log(Vertical + "," + Horizontal);

        Position = transform.position;                  // 플레이어 현재 좌표값을 받는다.
        lastState = player.State.GetType().Name;        // 플레이어 현재 상태

        if (Horizontal != 0 || Vertical != 0)
        {
            if(lastState != "PlayerMoving")
            {
                player._Move();
            }
            player.Move();     // 상 하 좌 우 키 입력이 있을 때
        }
        else
        {
            if (lastState != "PlayerIdle")
            {
                player._Stop();
            }
            player.Idle();      // 아무것도 안할 때
        }
        PlayAnimation();
        CurrentCharacter();
    }

    public string GetState()
    {
        return lastState;
    }
}
