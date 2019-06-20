using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AJoys
{
    public class PlayerPlatformerController : PhysicsObject
    {
        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;
        private Animator player;
        private SpriteRenderer spriteRenderer;
        public Attack1 attack;
        public Joystick joy;


        // Use this for initialization
        void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            player = GetComponent<Animator>();

        }

        protected override void Attack()
        {


            if (Input.GetKeyDown(KeyCode.L))
            {

                player.SetTrigger("Attack");

            }


        }
        public void attack12()
        {
            player.SetTrigger("Attack");
        }
        public void OnEnableColider2D()
        {
            if (!spriteRenderer.flipX)
            {
                attack.rightAttackTrigger.enabled = true;


            }
            if (spriteRenderer.flipX)
            {
                attack.leftAttackTrigger.enabled = true;

            }
        }
        public void Jump()
        {
            if(velocity.y <= 0 && grounded)
            velocity.y = jumpTakeOffSpeed;
        }

        public void DisableColider2D()
        {
            attack.rightAttackTrigger.enabled = false;
            attack.leftAttackTrigger.enabled = false;
        }
        protected override void ComputeVelocity()
        {
            Vector2 move = Vector2.zero;

            move.x = joy.input.x;

            player.SetFloat("Run", Mathf.Abs(move.x));
            player.SetBool("Jump", grounded);

            if (Input.GetButtonDown("Jump") && grounded)
            {
                player.SetBool("Jump", true);
                velocity.y = jumpTakeOffSpeed;
            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * 0.5f;
                }
            }

            bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.001f) : (move.x < 0f));
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }


            targetVelocity = move * maxSpeed;



        }

    }
}