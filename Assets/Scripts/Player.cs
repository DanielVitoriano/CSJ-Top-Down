using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int SwordDamage;
    [SerializeField] private float health;
    private float maxHealth;
    public bool isPaused;
    [SerializeField] private float speed;
    [SerializeField] private float run_speed;
    private int handlingObj;
    private PlayerItens playerItens;
    private float initial_speed;
    private Vector2 _direction;
    private bool _isRunning = false;
    private bool _isRolling = false;
    private bool _isCutting = false;
    private bool _isDigging = false;
    private bool _isWatering = false;
    private Rigidbody2D rig;
    private HUD_Controler hud_controler;
    private bool isAttacking;

    private void Awake() {
        hud_controler = FindObjectOfType<HUD_Controler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        rig = GetComponent<Rigidbody2D>();
        initial_speed = speed;
        playerItens = GetComponent<PlayerItens>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused){
            setHandling();
            OnInput();
            OnRolling();
            OnRun();
            OnCutting();
            OnDigging();
            OnWatering();
            OnAttack();
        }
    }
    public void OnHit(int damage){
        health -= damage;
        hud_controler.SetHealthBarFillAmount(health / maxHealth);
    }

    public void OnAttack(){
        if(handlingObj == 3){
            if(Input.GetMouseButtonDown(0) && !IsAttacking){
                isAttacking = true;
                speed = 0; 
            }
            if(Input.GetMouseButtonUp(0)){
                isAttacking = false;
                speed = initial_speed;
            }
        }
    }

    void setHandling(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            handlingObj = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            handlingObj = 3;
        }
        hud_controler.setSelectIten(handlingObj);
    }
    public int GetHandling(){
        return handlingObj;
    }

    void FixedUpdate() {
        if(!isPaused){
            OnMove();
        }
    }

    public Vector2 direction
    {
        get { return _direction;}
        set { _direction = value;}
    }
    public bool isRunning
    {
        get { return _isRunning;}
        set { _isRunning = value;}
    }
    public bool isRolling
    {
        get { return _isRolling;}
        set { _isRolling = value;}
    }

    public bool isCutting { get => _isCutting; set => _isCutting = value; }
    public bool isDigging { get => _isDigging; set => _isDigging = value; }
    public bool isWatering { get => _isWatering; set => _isWatering = value; }
    public bool IsAttacking { get => IsAttacking1; set => IsAttacking1 = value; }
    public bool IsAttacking1 { get => isAttacking; set => isAttacking = value; }
    public int SwordDamage1 { get => SwordDamage; set => SwordDamage = value; }

    #region Movement


    void OnWatering(){
        if(handlingObj == 2){
            if(Input.GetMouseButtonDown(0) && playerItens.Water > 0){
                isWatering = true;
                speed = 0;
            }
            if(Input.GetMouseButtonUp(0)){
                isWatering = false;
                speed = initial_speed;
            }
            if(isWatering){
                playerItens.setWater(-0.01f);
            }
        }
        else{isWatering = false;}
    }


    void OnDigging(){
        if(handlingObj == 1){
            if(Input.GetMouseButtonDown(0)){
                isDigging = true;
                speed = 0;
            }
            if(Input.GetMouseButtonUp(0)){
                isDigging = false;
                speed = initial_speed;
            }
        }
        else{isDigging = false;}
    }

    void OnCutting(){
        if(handlingObj == 0){
            if(Input.GetMouseButtonDown(0)){
            isCutting = true;
            speed = 0;
        }
            if(Input.GetMouseButtonUp(0)){
                isCutting = false;
                speed = initial_speed;
            }
        }
        else{isCutting = false;}
    }

    void OnInput(){
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove(){
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);   
    }
    void OnRun(){
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            speed = run_speed;
            _isRunning = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            speed = initial_speed;
            _isRunning = false;
        }
    }
    void OnRolling(){
        if(Input.GetMouseButtonDown(1)){
            speed = run_speed;
            _isRolling = true;
        }
        if(Input.GetMouseButtonUp(1)){
            speed = initial_speed;
            _isRolling = false;
        }
    }

    #endregion

}
