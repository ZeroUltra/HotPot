using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Role : MonoBehaviour
{
    public int id;
    public Characters character;
    private Arm arm;
    // private Vomit vomit;
    public PlayerInfo playerInfo;
    [HideInInspector] public PlayerUIInfo playerUIInfo;

    public GameObject shitPrefab;

    private KeyCode switchKey;  //��ͷ�л���ť
    private KeyCode vomitKey; //Ż���ﴥ����ť

    [SerializeField] private GameObject arrowGo; //��ͷ
    [SerializeField] private bool vomitIsSelf = true;//Ż�¶����Ƿ�Ϊ�Լ�

    [SerializeField] private int chooseTargetIndex;
    [SerializeField] private int bechoose;

    private Transform arrowpool;
    [SerializeField] private Role targetRole;
    private Vector3 vomitPos;
    public int ChooseTargetIndex
    {
        get { return chooseTargetIndex; }
        set
        {
            chooseTargetIndex = value;
            if (chooseTargetIndex > GameManager.Instance.rolesList.Count - 1)
            {
                chooseTargetIndex = 0;
            }
        }
    }
    #region Key 
    private Dictionary<int, KeyCode> DicSwitchKey = new Dictionary<int, KeyCode>()
    {
        [0] = KeyCode.S,
        [1] = KeyCode.K,
        [2] = KeyCode.DownArrow,
        [3] = KeyCode.Keypad8
    };
    private Dictionary<int, KeyCode> DicVomitKey = new Dictionary<int, KeyCode>()
    {
        [0] = KeyCode.D,
        [1] = KeyCode.L,
        [2] = KeyCode.RightArrow,
        [3] = KeyCode.Keypad9
    };
    #endregion




    public void Init(int id, Characters character, Transform UIPlayerTrans)
    {
        this.id = id;
        this.character = character;
        //������Ϣ
        playerInfo = new PlayerInfo(id, this.character);
        //�첲
        arm = GetComponentInChildren<Arm>();
        arm.Init(id, character);
        arm.OnEat += Arm_OnEat;
        //UI��Ϣ
        this.playerUIInfo = UIPlayerTrans.GetChild(id).GetComponent<PlayerUIInfo>();
        playerUIInfo.Init(character);

        //����id���ô�����ť
        switchKey = DicSwitchKey[id];
        vomitKey = DicVomitKey[id];

        //����id���ü�ͷͼ��
        arrowGo = new GameObject(this.character.ToString(), typeof(SpriteRenderer));
        arrowGo.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("arrow/" + (id + 1).ToString());
        arrowpool = transform.parent.Find("arrowpool");
        arrowGo.transform.SetParent(arrowpool); //���õ���ͷ��
        arrowGo.transform.localScale = Vector3.one * 0.16f;
        ChooseTargetIndex = id;
        ChooseTarget();

        // ����shit 
        shitPrefab = Resources.Load<GameObject>("shit/shit");
        //Ż��λ��
        vomitPos = transform.Find("vomitpos").position;

        playerInfo.OnVomit += PlayerInfo_OnVomit;
    }

    private void PlayerInfo_OnVomit()
    {
        playerUIInfo.SetPanel(this.playerInfo);
    }

    /// <summary>
    /// ����ҳٵ�ʳ��
    /// </summary>
    /// <param name="food"></param>
    private void Arm_OnEat(int food)
    {
        int score = playerInfo.updateInfo(food);
        playerUIInfo.SetPanel(this.playerInfo);
        if (score >= 100)
        {
            //����
            GameTools.LoadScene("04End");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            ChooseTargetIndex++;
            ChooseTarget();
        }
        if (Input.GetKeyDown(vomitKey)&&targetRole!=null&&targetRole!=this)
        {
            Vomit();
        }
    }

    /// <summary>
    /// ѡ��Ҫ��������
    /// </summary>
    private void ChooseTarget()
    {
        targetRole = GameManager.Instance.rolesList[ChooseTargetIndex];
        //�����ǰĿ��Ϊ�Լ�
        if (targetRole.transform == this.transform)
        {
            vomitIsSelf = true;
            arrowGo.gameObject.SetActive(false);
        }
        else
        {
            vomitIsSelf = false;
            arrowGo.gameObject.SetActive(true);
        }
        SetArrowPos(targetRole);
    }


    /// <summary>
    /// ���ü�ͷλ��
    /// </summary>
    /// <param name="target"></param>
    private void SetArrowPos(Role roleTarget)
    {
        arrowGo.transform.SetParent(roleTarget.arrowpool);
        Vector3 pos = roleTarget.transform.position + new Vector3(-0.2f + (roleTarget.arrowpool.childCount - 1) * 0.2f, 1.4f, 0f);
        arrowGo.transform.position = pos;
    }

    /// <summary>
    /// ����Ż�¹���
    /// </summary>
    private void Vomit()
    {
        if (playerInfo.getRepletion() < 5) return;  //��ʳ��С��5����
        playerInfo.vomit(5);
        GameObject shit = Instantiate(shitPrefab, vomitPos, Quaternion.identity) as GameObject;
        Shit shi = shit.GetComponent<Shit>();
        shi.target = targetRole.transform;
        shi.OnTrigger += () =>
        {
            targetRole.BeVomitted();
            Destroy(shit, 0.1f);
        };
        shit.transform.DOMove(targetRole.transform.position, 1f);
    }
    public void BeVomitted()
    {
        arm.ClearFood();
        playerInfo.beVomitted();
    }
}
