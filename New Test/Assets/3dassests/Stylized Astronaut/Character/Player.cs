using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

        public float health = 100;
        public float energy = 100;
        public float motivation = 100;

        public float deathRate;
        public float energyRate;
        public float motivationRate;

        public Slider HBar;
        public Slider Ebar;
        public Slider MBar;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w")) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;

        HBar.value = this.health;
        Ebar.value = this.energy;
        MBar.value = this.motivation;

        energy = energy - (energy * energyRate);
        motivation = motivation - (motivation * motivationRate);

        if(health<=0)
        {
            health = 0;
            anim.SetTrigger("dead");
            gameObject.GetComponent<Player>().enabled = false;
        }
        if (energy <= 0 || motivation <= 0) {
            health = health - (deathRate * Time.deltaTime);
        }
        if (energy <= 0) energy = 0;
        if (motivation <= 0) motivation = 0;






		}
}
