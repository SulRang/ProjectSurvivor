using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Move : MonoBehaviour
{
    [SerializeField]
    GameObject cameraObject;
    public string[] animationNames = new string[6]  // �ִϸ��̼� ����
    { "Idle", "Walk", "Run", "Dead", "Skill", "Attack" };                    
    Animator anim;

    public static bool Right = false;

    static public Player_Move playerMove;
    int animationNumber = 0;
    int playingAnimationNumber = 0;

    public float moveSpeed;
    string lastState;                                       // �÷��̾��� ����
    Player player;                                          // �������� -> �÷��̾�
    Vector3 Position;                                       // �÷��̾��� ��ǥ

    public float Horizontal;
    public float Vertical;

    //�缺 �߰� ����
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
            Debug.Log("������ ����");
        }

        public void _Move()
        {
            playerState = new PlayerMoving();
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
        triggers.GetComponent<ObjectInitializer>().RotationInit(); // �缺 �߰� �κ�
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
        Horizontal = Input.GetAxis("Horizontal");       // x��
        Vertical = Input.GetAxis("Vertical");           // y��
        //Debug.Log(Vertical + "," + Horizontal);

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
        CurrentCharacter();
    }

    public string GetState()
    {
        return lastState;
    }
}
