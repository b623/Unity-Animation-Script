using UnityEngine;
using System.Collections;

public class AnimationSelector : MonoBehaviour {
	
	public float fadeLength = 0.5f;
	
	private Controller.State oldState;
	private Controller.State curState;
	//on prend les états du controller
	private Controller controller;
	
	
	//private AnimationState curAnimationState;
	public string animationName = "";
	public float animationTime = 0f;
	public float animationNormTime = 0f;
	private float idleTimer = 0.0f;
	private Controller.State idleState;
	
	// Use this for initialization
	void Start () {
		//on va cherche l'instance du script sur le même GameObject.
		controller = GetComponent<Controller>();
		idleState = oldState= controller.curState;
		//curAnimationState = animation["Standing"];
		UpdateAnimation();
	}
	
	// Update is called once per frame
	void Update () {		
		
		if(oldState != controller.curState)
		{
			curState = controller.curState;
			UpdateAnimation();
			oldState = curState;
		}
		
		//animationName = curAnimationState.name;
		//animationTime = curAnimationState.time;
		//animationNormTime = curAnimationState.normalizedTime;
		
		if(curState == idleState)
		{
			idleTimer += Time.deltaTime;
			if(idleTimer > 2.0f)
			{
				animation.CrossFade("Idle",fadeLength);
			}
		}
		else
		{
			idleTimer = 0f;
		}
		
		
	}
	
	void UpdateAnimation()
	{
				
		switch(curState.direction)
		{
#region direction none
		case Controller.Direction.None:
			
			if(curState.stance == Controller.Stance.Stand)
			{
				if(curState.isAiming && !curState.isFiring)
				{
					animation.CrossFade("StandingAim",fadeLength);
					break;
				}
				else if ( curState.isFiring)
				{
					animation.CrossFade("StandingFire",fadeLength);
					break;
				}
				else
				{	
					animation.CrossFade("Standing",fadeLength);
					break;
				}
			}
			
			if(curState.stance == Controller.Stance.Crouch)
			{
				if(curState.isAiming && !curState.isFiring)
				{
					animation.CrossFade("CrouchAim",fadeLength);
					break;
				}
				else if ( curState.isFiring)
				{
					animation.CrossFade("CrouchFire",fadeLength);
					break;
				}
				else
				{	
					animation.CrossFade("Crouch",fadeLength);
					break;
				}
			}
			break;
#endregion
#region direction left			
		case Controller.Direction.Left:
			
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("StrafeWalkLeftAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("StrafeWalkLeftFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("StrafeWalkLeft",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeWalkLeftAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeWalkLeftFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchStrafeWalkLeft",fadeLength);
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("StrafeRunLeftAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("StrafeRunLeftFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("StrafeRunLeft",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeRunLeftAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeRunLeftFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchStrafeRunLeft",fadeLength);
						break;
					}
				}
			}
			break;
#endregion
#region direction front left
		case Controller.Direction.Front_Left:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{		
						animation["StrafeWalkLeftAim"].normalizedTime = 0.5f;
						animation["WalkAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeftAim",fadeLength);
						animation.Blend("WalkAim");
						
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeWalkLeftFire"].normalizedTime = 0.5f;
						animation["WalkFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeftFire",fadeLength);
						animation.Blend("WalkFire");
					
						break;
					}
					else
					{
						animation["StrafeWalkLeft"].normalizedTime = 0.5f;
						animation["Walk"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeft",fadeLength);
						animation.Blend("Walk");
						
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeWalkLeftAim"].normalizedTime = 0.5f;
						animation["CrouchWalkAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeftAim",fadeLength);
						animation.Blend("CrouchWalkAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeWalkLeftFire"].normalizedTime = 0.5f;
						animation["CrouchWalkFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeftFire",fadeLength);
						animation.Blend("CrouchWalkFire");
						break;
					}
					else
					{	animation["CrouchStrafeWalkLeft"].normalizedTime = 0.5f;
						animation["CrouchWalk"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeft",fadeLength);
						animation.Blend("CrouchWalk");
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["StrafeRunLeftAim"].normalizedTime = 0.5f;
						animation["RunAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeftAim",fadeLength);
						animation.Blend("RunAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeRunLeftFire"].normalizedTime = 0.5f;
						animation["RunFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeftFire",fadeLength);
						animation.Blend("RunFire");
						break;
					}
					else
					{	
						animation["StrafeRunLeft"].normalizedTime = 0.5f;
						animation["Run"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeft",fadeLength);
						animation.Blend("Run");
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeRunLeftAim"].normalizedTime = 0.5f;
						animation["CrouchRunAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeftAim",fadeLength);
						animation.Blend("CrouchRunAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeRunLeftFire"].normalizedTime = 0.5f;
						animation["CrouchRunFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeftFire",fadeLength);
						animation.Blend("CrouchRunFire");
						break;
					}
					else
					{	
						animation["CrouchStrafeRunLeft"].normalizedTime = 0.5f;
						animation["CrouchRun"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeft",fadeLength);
						animation.Blend("CrouchRun");
						break;
					}
				}
			}
			break;
#endregion
#region direction front
		case Controller.Direction.Front:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("WalkAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("WalkFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("Walk",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchWalkAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchWalkFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchWalk",fadeLength);
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("RunAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("RunFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("Run",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchRunAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchRunFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchRun",fadeLength);
						break;
					}
				}
			}
			break;
#endregion
#region front right			
		case Controller.Direction.Front_Right:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{		
						animation["StrafeWalkRightAim"].normalizedTime = 0.0f;
						animation["WalkAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRightAim",fadeLength);
						animation.Blend("WalkAim");
						
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeWalkRightFire"].normalizedTime = 0.0f;
						animation["WalkFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRightFire",fadeLength);
						animation.Blend("WalkFire");
					
						break;
					}
					else
					{
						animation["StrafeWalkRight"].normalizedTime = 0.0f;
						animation["Walk"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRight",fadeLength);
						animation.Blend("Walk");
						
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeWalkRightAim"].normalizedTime = 0.0f;
						animation["CrouchWalkAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRightAim",fadeLength);
						animation.Blend("CrouchWalkAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeWalkRightFire"].normalizedTime = 0.0f;
						animation["CrouchWalkFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRightFire",fadeLength);
						animation.Blend("CrouchWalkFire");
						break;
					}
					else
					{	animation["CrouchStrafeWalkRight"].normalizedTime = 0.0f;
						animation["CrouchWalk"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRight",fadeLength);
						animation.Blend("CrouchWalk");
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["StrafeRunRightAim"].normalizedTime = 0.0f;
						animation["RunAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRightAim",fadeLength);
						animation.Blend("RunAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeRunRightFire"].normalizedTime = 0.0f;
						animation["RunFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRightFire",fadeLength);
						animation.Blend("RunFire");
						break;
					}
					else
					{	
						animation["StrafeRunRight"].normalizedTime = 0.0f;
						animation["Run"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRight",fadeLength);
						animation.Blend("Run");
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeRunRightAim"].normalizedTime = 0.0f;
						animation["CrouchRunAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRightAim",fadeLength);
						animation.Blend("CrouchRunAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeRunRightFire"].normalizedTime = 0.0f;
						animation["CrouchRunFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRightFire",fadeLength);
						animation.Blend("CrouchRunFire");
						break;
					}
					else
					{	
						animation["CrouchStrafeRunRight"].normalizedTime = 0.0f;
						animation["CrouchRun"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRight",fadeLength);
						animation.Blend("CrouchRun");
						break;
					}
				}
			}
			break;
#endregion
#region direction right
		case Controller.Direction.Right:
			
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("StrafeWalkRightAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("StrafeWalkRightFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("StrafeWalkRight",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeWalkRightAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeWalkRightFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchStrafeWalkRight",fadeLength);
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("StrafeRunRightAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("StrafeRunRightFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("StrafeRunRight",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeRunRightAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchStrafeRunRightFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchStrafeRunRight",fadeLength);
						break;
					}
				}
			}
			break;
#endregion
#region direction back left
		case Controller.Direction.Back_Left:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{		
						animation["StrafeWalkRightAim"].normalizedTime = 0.0f;
						animation["WalkBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRightAim",fadeLength);
						animation.Blend("WalkBackwardsAim");
						
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeWalkRightFire"].normalizedTime = 0.0f;
						animation["WalkBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRightFire",fadeLength);
						animation.Blend("WalkBackwardsFire");
					
						break;
					}
					else
					{
						animation["StrafeWalkRight"].normalizedTime = 0.0f;
						animation["WalkBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkRight",fadeLength);
						animation.Blend("WalkBackwards");
						
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeWalkRightAim"].normalizedTime = 0.0f;
						animation["CrouchWalkBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRightAim",fadeLength);
						animation.Blend("CrouchWalkBackwardsAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeWalkRightFire"].normalizedTime = 0.0f;
						animation["CrouchWalkBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRightFire",fadeLength);
						animation.Blend("CrouchWalkBackwardsFire");
						break;
					}
					else
					{	animation["CrouchStrafeWalkRight"].normalizedTime = 0.0f;
						animation["CrouchWalkBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkRight",fadeLength);
						animation.Blend("CrouchWalkBackwards");
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["StrafeRunRightAim"].normalizedTime = 0.0f;
						animation["RunBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRightAim",fadeLength);
						animation.Blend("RunBackwardsAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeRunRightFire"].normalizedTime = 0.0f;
						animation["RunBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRightFire",fadeLength);
						animation.Blend("RunBackwardsFire");
						break;
					}
					else
					{	
						animation["StrafeRunRight"].normalizedTime = 0.0f;
						animation["RunBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunRight",fadeLength);
						animation.Blend("RunBackwards");
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeRunRightAim"].normalizedTime = 0.0f;
						animation["CrouchRunAimBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRightAim",fadeLength);
						animation.Blend("CrouchRunAimBackwards");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeRunRightFire"].normalizedTime = 0.0f;
						animation["CrouchRunFireBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRightFire",fadeLength);
						animation.Blend("CrouchRunFireBackwards");
						break;
					}
					else
					{	
						animation["CrouchStrafeRunRight"].normalizedTime = 0.0f;
						animation["CrouchRunBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunRight",fadeLength);
						animation.Blend("CrouchRunBackwards");
						break;
					}
				}
			}
			break;
			#endregion
#region direction back
		case Controller.Direction.Back:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("WalkBackwardsAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("WalkBackwardsFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("WalkBackwards",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchWalkBackwardsAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchWalkBackwardsFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchWalkBackwards",fadeLength);
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("RunBackwardsAim",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("RunBackwardsFire",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("RunBackwards",fadeLength);
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation.CrossFade("CrouchRunAimBackwards",fadeLength);
						break;
					}
					else if ( curState.isFiring)
					{
						animation.CrossFade("CrouchRunFireBackwards",fadeLength);
						break;
					}
					else
					{	
						animation.CrossFade("CrouchRunBackwards",fadeLength);
						break;
					}
				}
			}
			break;
#endregion
#region direction back right
		case Controller.Direction.Back_Right:
			if(curState.moveSpeed == Controller.MoveSpeed.Walk)
			{
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{		
						animation["StrafeWalkLeftAim"].normalizedTime = 0.5f;
						animation["WalkBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeftAim",fadeLength);
						animation.Blend("WalkBackwardsAim");
						
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeWalkLeftFire"].normalizedTime = 0.5f;
						animation["WalkBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeftFire",fadeLength);
						animation.Blend("WalkBackwardsFire");
					
						break;
					}
					else
					{
						animation["StrafeWalkLeft"].normalizedTime = 0.5f;
						animation["WalkBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeWalkLeft",fadeLength);
						animation.Blend("WalkBackwards");
						
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeWalkLeftAim"].normalizedTime = 0.5f;
						animation["CrouchWalkBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeftAim",fadeLength);
						animation.Blend("CrouchWalkBackwardsAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeWalkLeftFire"].normalizedTime = 0.5f;
						animation["CrouchWalkBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeftFire",fadeLength);
						animation.Blend("CrouchWalkBackwardsFire");
						break;
					}
					else
					{	animation["CrouchStrafeWalkLeft"].normalizedTime = 0.5f;
						animation["CrouchWalkBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeWalkLeft",fadeLength);
						animation.Blend("CrouchWalkBackwards");
						break;
					}
				}
			}
			
			if(curState.moveSpeed == Controller.MoveSpeed.Run)
			{
			
				if(curState.stance == Controller.Stance.Stand)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["StrafeRunLeftAim"].normalizedTime = 0.5f;
						animation["RunBackwardsAim"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeftAim",fadeLength);
						animation.Blend("RunBackwardsAim");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["StrafeRunLeftFire"].normalizedTime = 0.5f;
						animation["RunBackwardsFire"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeftFire",fadeLength);
						animation.Blend("RunBackwardsFire");
						break;
					}
					else
					{	
						animation["StrafeRunLeft"].normalizedTime = 0.5f;
						animation["RunBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("StrafeRunLeft",fadeLength);
						animation.Blend("RunBackwards");
						break;
					}
				}
				
				if(curState.stance == Controller.Stance.Crouch)
				{
					if(curState.isAiming && !curState.isFiring)
					{
						animation["CrouchStrafeRunLeftAim"].normalizedTime = 0.5f;
						animation["CrouchRunAimBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeftAim",fadeLength);
						animation.Blend("CrouchRunAimBackwards");
						break;
					}
					else if ( curState.isFiring)
					{
						animation["CrouchStrafeRunLeftFire"].normalizedTime = 0.5f;
						animation["CrouchRunFireBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeftFire",fadeLength);
						animation.Blend("CrouchRunFireBackwards");
						break;
					}
					else
					{	
						animation["CrouchStrafeRunLeft"].normalizedTime = 0.5f;
						animation["CrouchRunBackwards"].normalizedTime = 0.0f;
						animation.CrossFade("CrouchStrafeRunLeft",fadeLength);
						animation.Blend("CrouchRunBackwards");
						break;
					}
				}
			}	
			break;
		}	
#endregion
		//animation.SyncLayer(0);		
	}
	
}
