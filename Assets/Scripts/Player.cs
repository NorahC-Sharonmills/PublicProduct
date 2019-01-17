using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D myRigidbody;

    private Animator myAnimator;

    [SerializeField]
    private float movementSpeed;

    private bool attack;

    private bool facingRight;

    private bool slider;

    [SerializeField]
    Transform[] groundPoints;

    [SerializeField]
    float groundRadius;

    [SerializeField]
    LayerMask whatIsGround;

    bool isGrounded;

    bool jump;

    bool jumpAttack;

    [SerializeField]
    bool airControl;

    [SerializeField]
    float jumpForce;
    public int ourHealth;
	public int maxHealth = 5;
    public Gamemaster gm;
    public SoundManager soundManager;
    public AttackPlayer at;
    public TestEnemy te;
    public EnemyyBlood eyybd;
    public OcBlood ob;
    public NhimScrips ns;
    public DeadUI dead;
    // Use this for initialization
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        ourHealth = maxHealth;
        gm = GameObject.FindGameObjectWithTag("gamemaster").GetComponent<Gamemaster>();
        soundManager = GameObject.FindGameObjectWithTag("Sounds").GetComponent<SoundManager>();
        at = GameObject.FindGameObjectWithTag("attri").GetComponent<AttackPlayer>();
        te = GameObject.FindGameObjectWithTag("Enemy").GetComponent<TestEnemy>();
        eyybd = GameObject.FindGameObjectWithTag("Enemy1").GetComponent<EnemyyBlood>();
        // ob = GameObject.FindGameObjectWithTag("Oc").GetComponent<OcBlood>();
        // ns = GameObject.FindGameObjectWithTag("Nhim").GetComponent<NhimScrips>();
        dead = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<DeadUI>();
    }

    void Update()
    {
        HandleInput();
    }
    public void Damage(int damage){
        ourHealth -= damage;
    }
    public void Knockback(float Knockpow, Vector2 Knockdir){
        myRigidbody.velocity = new Vector2(0, 0);
        myRigidbody.AddForce(new Vector2(Knockdir.x * 100, Knockdir.y * Knockpow));
    }
    public void Dead() {
        // Time.timeScale = 0;
        // dead.DeadUIGame.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = IsGrounded();

        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        HandleLayers();
        ResetValues();

        if(ourHealth <= 0){
            Dead();
        }
    }

    void HandleMovement(float horizontal)
    {
        if (myRigidbody.velocity.y < 0)
        {
            myAnimator.SetBool("land", true);
        }
        if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (isGrounded || airControl))
        {
            myRigidbody.velocity = new Vector2(horizontal * movementSpeed, myRigidbody.velocity.y);
        }

        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidbody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
        }

        if (slider && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("ani_slide"))
        {
            myAnimator.SetBool("slide", true);
        }
        else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("ani_slide"))
        {
            myAnimator.SetBool("slide", false);
        }


        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }

    void HandleAttacks()
    {
        if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnimator.SetTrigger("attack");
            myRigidbody.velocity = Vector2.zero;
        }

        if (jumpAttack && !isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("ani_jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", true);
        }

        if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("ani_jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", false);
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            attack = true;
            jumpAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            slider = true;
        }
    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }

    void ResetValues()
    {
        attack = false;
        slider = false;
        jump = false;
        jumpAttack = false;
    }

    bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            foreach( Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for(int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    void HandleLayers()
    {
        if (!isGrounded)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }

    public void TriggerAttackTrue(){
        string GetRaycast = at.Aaaa();
        Debug.Log(GetRaycast);
        if(GetRaycast == "SnowMan"){
            te.Damageee(20);
        }
        if(GetRaycast == "Enemyy"){
            eyybd.Damageee(20);
        }
        if(GetRaycast == "Oc"){
            ob.Damageee(20);
            Debug.Log("A");
        }
        if(GetRaycast == "Nhim"){
            ns.Damageee(20);
            Debug.Log("B");
        }
    }

    public void ResetTrigerAttack(){
        // Debug.Log("False");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Coins"))
        {
            Destroy(col.gameObject);
            soundManager.Playsound("coins");
            gm.pointsss += 1;
        }
        if(col.CompareTag("Water")){
            ourHealth = 0;
        }
    }
}
