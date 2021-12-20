using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float run_speed;
    private int handlingObj;
    private float initial_speed;
    private Vector2 _direction;
    private bool _isRunning = false;
    private bool _isRolling = false;
    private bool _isCutting = false;
    private bool _isDigging = false;
    private Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initial_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        setHandling();
        OnInput();
        OnRolling();
        OnRun();
        OnCutting();
    }

    void setHandling(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            handlingObj = 2;
        }
    }

    void FixedUpdate() {
         OnMove();
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

    #region Movement

       void OnDigging(){
        if(Input.GetMouseButtonDown(0)){
            isDigging = true;
            speed = 0;
        }
        if(Input.GetMouseButtonUp(0)){
            isDigging = false;
            speed = initial_speed;
        }
    }

    void OnCutting(){
        if(Input.GetMouseButtonDown(0)){
            isCutting = true;
            speed = 0;
        }
        if(Input.GetMouseButtonUp(0)){
            isCutting = false;
            speed = initial_speed;
        }
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
            _isRolling = true;
        }
        if(Input.GetMouseButtonUp(1)){
            _isRolling = false;
        }
    }

    #endregion

}
