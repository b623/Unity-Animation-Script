using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	public enum Direction {None, Left, Front_Left, Front, Front_Right, Right, Back_Right, Back, Back_Left}
	//public Direction direction = Direction.None;
	
	//public bool IsShooting = false;
	//public bool IsAiming = false;
	
	public enum Stance { Stand, Crouch };
	//public Stance stance =  Stance.Stand;
	public enum MoveSpeed { Walk, Run};
	//public MoveSpeed moveSpeed = MoveSpeed.Walk;
	
	public struct State
	{
		public bool isFiring;
		public bool isAiming;
		public Stance stance;
		public Controller.Direction direction;
		public MoveSpeed moveSpeed;
		
		/*public State()
    	{
			isFiring = false;
			isAiming = false;
			stance = Stance.Stand;
			direction = Direction.None;
			moveSpeed = MoveSpeed.Walk;    
    	}*/
		
		public static bool operator ==(State left, State right) 
   		{
			//retourne true si tout est égale sinon pas égale.
      		return (left.direction == right.direction && left.isFiring == right.isFiring
				&& left.isAiming == right.isAiming && left.stance == right.stance 
				&& left.moveSpeed == right.moveSpeed);
   		}
		public static bool operator !=(State left, State right) 
   		{
			//retourne faux si tout est égale sinon c'est égale.
      		return !(left.direction == right.direction && left.isFiring == right.isFiring
				&& left.isAiming == right.isAiming && left.stance == right.stance 
				&& left.moveSpeed == right.moveSpeed);
   		}
	}
	
	public State curState;
	
	// W,A,S,D pour savoir si les touche sont enfoncé, 
	// ça revient à faire Input.getkey()
	private bool W = false, A = false, S = false, D = false;
	private bool front = false, back = false, left = false, right = false;
	
	// Use this for initialization
	void Start () {
		curState.stance = Stance.Stand;
	}
	
	// Update is called once per frame
	void Update () {
		
		//Boutton LeftControl change l'état stance, crouch ou stand *Mode Toggle*
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			if(curState.stance == Stance.Crouch)
				curState.stance = Stance.Stand;
			else
				curState.stance = Stance.Crouch;
			//print(stance.ToString());
		}
		
		//Vérification de tir
		if(Input.GetMouseButtonDown(0))
			curState.isFiring = true;
			//print("polling?"); // testé, non on poll pas!
		//On arrête de tirer lorsque le bouton0 de la souris est lâché
		if(Input.GetMouseButtonUp(0))
			curState.isFiring = false;
		//print(IsShooting.ToString());
		
		//Vérification de Aim
		if(Input.GetMouseButtonDown(1))
			curState.isAiming = true;
		if(Input.GetMouseButtonUp(1))
			curState.isAiming = false;
		//print(IsAiming);
		
		//on vérifie la course
		if(Input.GetKeyDown(KeyCode.LeftShift))
			curState.moveSpeed = MoveSpeed.Run;
		if(Input.GetKeyUp(KeyCode.LeftShift))
			curState.moveSpeed = MoveSpeed.Walk;
		//print(moveSpeed); //fonctionne.
		
		//on vérifie W.A.S.D
		if(Input.GetKeyDown(KeyCode.W))
			W = true;
		if(Input.GetKeyDown(KeyCode.A))
			A = true;
		if(Input.GetKeyDown(KeyCode.S))
			S = true;
		if(Input.GetKeyDown(KeyCode.D))
			D = true;
		
		//on relève les touches
		if(Input.GetKeyUp(KeyCode.W))
			W = false;
		if(Input.GetKeyUp(KeyCode.A))
			A = false;
		if(Input.GetKeyUp(KeyCode.S))
			S = false;
		if(Input.GetKeyUp(KeyCode.D))
			D = false;
		
		//On détermine la direction
		//on reset la direction
		front = back = left = right = false;
		
		//Impossible d'avoir Front et Back = true, ni Left et Right = true
		//Front?
		if(W && !S)
			front = true;
		//Back??
		if(S && !W)
			back = true;
		//Left
		if(A && !D)
			left = true;
		//Right
		if(D && !A)
			right = true;
		
		//on set la direction
		curState.direction = Direction.None;
		
		if(left)
		{
			curState.direction = Direction.Left;
		}
		
		if(right)
		{
			curState.direction = Direction.Right;
		}
		
		if(front)
		{
			curState.direction = Direction.Front;
			if(left)
				curState.direction = Direction.Front_Left;
			if(right)
				curState.direction = Direction.Front_Right;
		}
		
		if(back)
		{
			curState.direction = Direction.Back;
			if(left)
				curState.direction = Direction.Back_Left;
			if(right)
				curState.direction = Direction.Back_Right;
		}
		
		//print(direction); // ça fonctionne très bien
	}
}
