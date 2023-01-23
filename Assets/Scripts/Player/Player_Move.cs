using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObject;
    static string[] animationNames = new string[6]  // 애니메이션 저장
    { "Idle", "Walk", "Run", "Dead", "Skill", "Attack" };                    
    static Animator anim;

    static bool Right = false;

    static private int animationNumber = 0;
    static private int playingAnimationNumber = 0;

    static float moveSpeed = 3;
    string lastState;                               // 플레이어의 상태
    Player player;                                  // 상태패턴 -> 플레이어
    static Vector3 Position;                               // 플레이어의 좌표

    static float Horizontal;
    static float Vertical;

    abstract class PlayerState
    {
        protected Player _player;

        public void SetPlayer(Player player)
        {
            this._player = player;
        }

        public abstract void Idle(Player player);
        public abstract void Moving(Player player);
    }

    class PlayerIdle : PlayerState
    {
        public override void Idle(Player player)
        {
            animationNumber = 0;
        }
        public override void Moving(Player player)
        {
            this._player._Move();
        }
    }

    class PlayerMoving : PlayerState
    {
        public override void Idle(Player player)
        {
            this._player._Stop();
        }
        public override void Moving(Player player)
        {
            moveSpeed = Player_Status.instance.SPEED;
            animationNumber = 1;
            
            if (Horizontal > 0)
            {
                Right = true;
            }
            else if (Horizontal < 0)
            {
                Right = false;
            }
            Position.x += Horizontal * Time.deltaTime * moveSpeed;
            Position.y += Vertical   * Time.deltaTime * moveSpeed;
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
            this.playerState = new PlayerIdle();
            Debug.Log("움직임 정지");
        }

        public void _Move()
        {
            this.playerState = new PlayerMoving();
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

    // Start is called before the first frame update
    void Start()
    {
        player = new Player(new PlayerIdle());
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal"); // x축
        Vertical = Input.GetAxis("Vertical");     // y축

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

        if (Right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, -1);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        cameraObject.transform.position = new Vector3(Position.x, Position.y, Position.z - 10);
        transform.position = Vector3.Lerp(transform.position, Position, 0.5f);
    }

    public string GetState()
    {
        return lastState;
    }
}
