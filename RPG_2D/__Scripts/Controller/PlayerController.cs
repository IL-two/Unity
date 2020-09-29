using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController playerController;
    public enum eMode { idle, move, attack, transition}

    public PlayerModel player;
    private PlayerView playerView;
    
    public SwordController sword; // Меч
    public BowController bow; // Лук
        
    [Header("Set Dynamically")]
    public int dirHeld = -1; // Направление соответствующее удерживаемой клавише
    public int facing = 1; // Направлене движения
    public eMode mode = eMode.idle;
    public int currentHealth; // Промежуточное здоровье
    public int currentExp; // Промежуточный опыт   
    
    private float timeAtkDone = 0; // Время завершение анимации
    private float timeAtkNext = 0; // Время, когда можно повторить атаку

    private new Rigidbody2D rigidbody;
    private Animator animator;

    private Vector3[] directions = new Vector3[]
        { Vector3.right, Vector3.up, Vector3.left, Vector3.down };
    private KeyCode[] keys = new KeyCode[]
        {KeyCode.RightArrow, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow };

    public delegate void OnLevelUp();
    public OnLevelUp levelUp;
    
    private void Awake()
    {
        if (playerController != null)
        {
            Debug.LogWarning("Error inventory");
            return;
        }

        playerController = this;

        player = new PlayerModel();
        playerView = GetComponent<PlayerView>();        
        currentHealth = player.MaxHealth; // Установление начального здоровья игрока

        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();        
        currentExp = 0;
    }
   
    // Update is called once per frame
    void Update()
    {
        //Перемещение
        dirHeld = -1;
       
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKey(keys[i])) dirHeld = i;
        }

        //Атака
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= timeAtkNext)
        {
            mode = eMode.attack;            
            timeAtkDone = Time.time + player.AttackDuration;
            timeAtkNext = Time.time + player.AttackDelay;

            if (bow.isActiveAndEnabled) bow.Attack();           
        }

        //Завершение атаки
        if (Time.time >= timeAtkDone)
        {
            mode = eMode.idle;
        }
        
        // Выбор режима, без атаки
        if (mode != eMode.attack)
        {
            if (dirHeld == -1)
            {
                mode = eMode.idle;
            }
            else
            {
                facing = dirHeld;
                mode = eMode.move;
            }
        }
        

        // Действия в текущем режиме
        Vector3 vel = Vector3.zero;
        switch (mode)
        {
            case eMode.attack:
                animator.CrossFade("Dray_Attack_" + facing, 0);
                animator.speed = 0;                
                break;

            case eMode.idle:
                animator.CrossFade("Dray_Walk_" + facing, 0);
                animator.speed = 0;
                break;

            case eMode.move:
                vel = directions[dirHeld];
                animator.CrossFade("Dray_Walk_" + dirHeld, 0);
                animator.speed = 1;
                break;
        }
               
        rigidbody.velocity = vel * player.Speed;
        
        LevelUp();
    }

    public void ChangeHealth (int ammoutn)
    {
        int ch = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + ammoutn, 0, player.MaxHealth);
        if (ch > currentHealth)
        {
            playerView.ViewEffectDamage(transform.position, ammoutn);            
        }
        playerView.UpdateSliderHealth(currentHealth);
        print(currentHealth + "/" + player.MaxHealth);

        if (currentHealth <= 0)
        {
            Dead();
        }        
    }

    public int MaxExp ()
    {
        return player.MaxExperience += 100 * player.Level;
    }

    private void LevelUp() // Повышения уровня
    {
        if (currentExp >= player.MaxExperience)
        {
            currentExp = currentExp - player.MaxExperience;            
            player.Level++;
            player.MaxHealth += 10;
            player.Strenght++;
            player.Dexterity++;
            playerView.ViewEffectLevelUp(transform.position);
            print("Plaeyr Level UP!");
            
            if (levelUp != null)
            {
                levelUp.Invoke();
            }
        }
        playerView.UpdateSliderExperience(currentExp);
    }

    public void CreditingExpirience(int exp)
    {
        currentExp += exp;
    }


    public void Dead()
    {        
        Destroy(gameObject, 0.15f);
        playerView.OneDeadMenu();
        Time.timeScale = 0f;
    }
}
