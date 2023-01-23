using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObject;
    static string[] animationNames = new string[6]  // �ִϸ��̼� ����
    { "Idle", "Walk", "Run", "Dead", "Skill", "Attack" };                    
    static Animator anim;

    static bool Right = false;

    static private int animationNumber = 0;
    static private int playingAnimationNumber = 0;

    static float moveSpeed = 3;
    string lastState;                               // �÷��̾��� ����
    Player player;                                  // �������� -> �÷��̾�
    static Vector3 Position;                               // �÷��̾��� ��ǥ

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
            Debug.Log("������ ����");
        }

        public void _Move()
        {
            this.playerState = new PlayerMoving();
            Debug.Log("������ ����");
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
        Horizontal = Input.GetAxis("Horizontal"); // x��
        Vertical = Input.GetAxis("Vertical");     // y��

        Position = transform.position;                  // �÷��̾� ���� ��ǥ���� �޴´�.
        lastState = player.State.GetType().Name;        // �÷��̾� ���� ����

        if (Horizontal != 0 || Vertical != 0)
        {
            if(lastState != "PlayerMoving")
            {
                player._Move();
            }
            player.Move();     // �� �� �� �� Ű �Է��� ���� ��
        }
        else
        {
            if (lastState != "PlayerIdle")
            {
                player._Stop();
            }
            player.Idle();      // �ƹ��͵� ���� ��
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
