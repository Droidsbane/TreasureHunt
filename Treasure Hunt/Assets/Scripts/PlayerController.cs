using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D mRigidbody = null;
    [SerializeField] private Animator mAnimator = null;
    [SerializeField] private PlayerData mPlayerConfig = null;
    private float mHorizontalMovement;
    private float mVerticalMovement;
    private float mMoveSpeed;

    private bool mIsMoving;
    private bool mIsOnGround;

    private const string FORWARD = "Forward";
    private const string BACKWARD = "Backward";
    private const string RIGHT = "Right";
    private const string LEFT = "Left";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string JUMP = "Jump";

    private void Start()
    {

        
        mHorizontalMovement = 0;
        mVerticalMovement = 0;
        mMoveSpeed = mPlayerConfig.MovementSpeed;
        mIsMoving = false;
        mIsOnGround = true;
    }

    private void FixedUpdate()
    {
        mHorizontalMovement = Input.GetAxis("Horizontal");
        mVerticalMovement = Input.GetAxis("Vertical");

        mRigidbody.velocity = new Vector2(mHorizontalMovement * mMoveSpeed, mVerticalMovement * mMoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        ResetAnimation();

        if (mHorizontalMovement != 0 || mVerticalMovement != 0)
        {
            mIsMoving = true;

            mAnimator.SetLayerWeight(1, 1);

            if (mHorizontalMovement != 0)
            {
                mAnimator.SetBool(mHorizontalMovement < 0 ? LEFT : RIGHT, true);
            }
            else if (mVerticalMovement != 0)
            {
                mAnimator.SetBool(mVerticalMovement < 0 ? FORWARD : BACKWARD, true);
            }
        }
        else
        {
            mIsMoving = false;
            mAnimator.SetLayerWeight(1, 0);
            mAnimator.SetLayerWeight(2, 0);
        }
    }

    void ResetAnimation()
    {
        mAnimator.SetBool(FORWARD, false);
        mAnimator.SetBool(BACKWARD, false);
        mAnimator.SetBool(RIGHT, false);
        mAnimator.SetBool(LEFT, false);
    }

    public void OnMovement(InputValue value)
    {
        mHorizontalMovement = value.Get<Vector2>().x;
        mVerticalMovement = value.Get<Vector2>().y;
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Actions.IncreaseScore?.Invoke(100);
            collision.gameObject.SetActive(false);
        }
    }
}