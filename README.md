Pico Unity Project Setup Guide

 Project Requirements
- Pico Device OS: 5.9+
- Pico Unity Integration SDK: 2.5+
- Unity XR Interaction Toolkit: 3.0.3
- Unity Version: 2022.3.29f1

 XRI Hand Interaction with PICO Unity Integration SDK

 Packages and Samples
1. Add the Pico SDK `package.json` file into the Unity Editor to ensure project compatibility with PICO.
2. Install XR Interaction Toolkit 3.0.3 from the Package Manager and import the Starter Assets and Hands Interaction Demo.
3. Install XR Hand 1.4 from the Package Manager and import the HandVisualizer and Gesture Assets.
4. Install DoTween from the Package Manager for scale animations.

 Input Action Map Configuration
1. Locate the `XRI Default Input Actions` ScriptableObject and open the asset to edit bindings for the left and right hands in the interaction area.

  Bindings for Aim Position, Aim Rotation, and Aim Flags:
- Open the respective bindings.
- Aim Position: Add Pico bindings for Device Position.
- Aim Rotation: Add Pico bindings for Device Rotation.
- Aim Flags: Add Pico bindings for AimFlags.

  Configuring Left Hand Bindings:

  ![XRI Input Map Left](https://github.com/user-attachments/assets/c71250a6-5faf-4da2-86be-8641b278c2c3)

  

  - XRI Left Interaction:
    - Select: Add binding for `Index Pressed`.
    - Binding Properties: Tracked Devices → Pico Aim Hand (Left Hand) → Index Pressed.
    - Value: Add binding for `Pinch Strength Index`.
    - Binding Properties: Tracked Devices → Pico Aim Hand (Left Hand) → PinchStrengthIndex.
   - UI Press: Add binding for `Index Pressed`.
    - Binding Properties: Tracked Devices → Pico Aim Hand (Left Hand) → Index Pressed.
   - UI Press Value: Add binding for `Pinch Strength Index`.
    - Binding Properties: Tracked Devices → Pico Aim Hand (Left Hand) → PinchStrengthIndex.

  Configuring Right Hand Bindings:

  ![XRI Input Map Right](https://github.com/user-attachments/assets/fe869a29-9dea-4fe8-bbc9-f4d535bd7646)

  

 - Repeat the same steps as above for XRI Right Interaction, but choose the Right Hand.

XR Origin Rig Setup
1. Locate the XR Origin Prefab in the Starter Assets of the XR Interaction Toolkit.
2. Add the PXR_Manager component.
   - Turn off MRC.
   - Enable Hand Tracking.

PICO Hand Models

![XR_Origin_HandSetUp_Pico](https://github.com/user-attachments/assets/70d5f173-aece-4056-9497-2b707445eff7)


Unity's default hand models do not align well with PICO’s hand bone structure. To resolve this:
1. Navigate to: `Pico Integration Folder → Assets → Resources → Prefabs → Hand Left` and `Hand Right`.
2. Add the respective hand prefab under the Hand (Left/Right) of the XR Origin Rig in Hand Interaction Visual.
3. Configure the PICO Hand Models:
   - Open the HandLeft/Right Prefabs of Pico.
   - RayPose > DefaultRay: Turn off the Skin Mesh Renderer.
   - Assign the Pico Hand Mesh Renderer to the XR Hand Mesh Controller.
   - Disable the following components:
     - XR Hand Skeleton Driver.
     - L_Wrist.
     - Unity’s default Hand Left/Right.

 Project Settings
- Minimum API Level: API 29
- Scripting Backend: IL2CPP
- Target Architecture: ARM64
- Active Input Handling: Input System Package
- Go to XR Plugin Management and ensure PICO is enabled.

 Build and Run
1. Open Build Settings and add the scenes to include in the build.
2. Connect your Pico device to your PC.
3. Click Build and Run to test the project.
   - The APK will be built, installed, and opened on your headset.

Comments to Explain Key Functions and Logic
Scripts Used in the Project
RotateAndChangeColor

Purpose: This script handles the rotation of a GameObject whenever a swipe gesture is detected.
Key Logic:
The script listens for swipe gestures and, upon detection, performs the following:
Applies a rotational transformation to the target GameObject.
Optionally changes the color of the GameObject to visually indicate the action.
ScaleDownAnimation

Purpose: This script sequentially scales down the GameObjects assigned to an array. Once all GameObjects are scaled down, another set of GameObjects is enabled.
Key Logic:
Uses a coroutine to iterate through the array of GameObjects.
Scales down each GameObject over a specified duration.
Triggers the enabling of a secondary set of GameObjects once all animations are completed.
ScaleAnimation

Purpose: This script scales up the GameObjects assigned to an array in sequence.
Key Logic:
Implements a coroutine to animate each GameObject's scaling over time.
Ensures that GameObjects are scaled up one after another, providing a smooth visual sequence.

HandGesture Scenes Folder :
 Under this folder we can find scenes which i debugged to learn and implement the task, our main scene will be HandGestureScene. Here we can find the respective main task work i have done as per requirements.

HandGestureScene Setup and scene flow :

![SceneSetup](https://github.com/user-attachments/assets/4a9ec933-45f9-48c0-b505-097326d98dcf)

In the Hierarchy of the HandGestureScene (above Image) , all the GameObjects responsible for accomplishing the designated tasks are included. These GameObjects collectively represent the scene's structure and functionality.
 The setup ensures:
  -All required GameObjects for hand gesture detection, interaction, and visual representation are present.
  -Proper organization and naming conventions for better readability and maintenance.
  
Scaleup_UI :

![SceneFlow_1_ScaleUp_UI](https://github.com/user-attachments/assets/b8ebd9bf-cd08-4d4d-8753-d2784906a886)

 Within the Hierarchy, there is a GameObject named Scaleup_UI. This GameObject is equipped with a script named ScaleAnimation, which is responsible for managing the scale-up animation of the assigned GameObjects.
  Key features include:
   -Functionality: The script ensures a smooth scale-up effect for the associated GameObjects.
   -Assigned Objects: The GameObjects assigned to this script include UI elements, such as instructional content, enhancing the user interface experience.

Interaction with PokeButton_1 : 

![SceneFlow_2_PokeButton_1](https://github.com/user-attachments/assets/2350b204-c848-407b-bb7a-660ab14b37f8)

 The PokeButton_1 GameObject plays a crucial role in the scene’s interaction flow.
  Functionality:
   When PokeButton_1 is clicked:
   The current UI instructions are disabled.
   The PokeButton_1 itself is disabled.
   The Scaleup_Cube GameObject is enabled.
   The scene transitions to the tutorial section.
   This interactive flow ensures a smooth transition from the instruction phase to the tutorial phase, maintaining user focus and engagement while dynamically updating the scene elements.

   Fig 1 :
   
   ![SceneFlow_3_ScaleUpCube](https://github.com/user-attachments/assets/d887f58b-dfc5-4242-ae89-bce3b28e82a2)

   Fig 2 :
   
   ![SceneFlow_4_pokeButton_2_Enable](https://github.com/user-attachments/assets/01f97b29-e684-43a3-a930-5c79a700ad25)


  ScaleUp_Cube gameobject(Fig 1) will scaleup and show us the tutorial gameobjects and also posedebugger(fig 2) which is responsible for the handgesturedetection with "static Hand Gesture script" is also enabled 
  when we click on the PokeButton_1.
  
Interaction with PokeButton_2 :

![SceneFlow_5_PokeButton_2](https://github.com/user-attachments/assets/44f2c7f2-d40d-451f-b7fb-279940a99bf6)

  Once the tutorial is done we can clik on the PokeButton_2 which will disable the previous UI and tutorial gameobjects and enables the ScaleUpEnvironment gameobject.

ScaleUpEnvironment Gameobject:

  ![Sceneflow_6_ScaleUpEnvironment](https://github.com/user-attachments/assets/a100d862-8699-478b-b3a8-ac35a866a9b7)

 The ScaleupEnvironment GameObject is responsible for managing the transition to the main dungeon setup.

   Script: The ScaleDownAnimation script is attached to this GameObject.
    Functionality:
     The script sequentially scales down an array of GameObjects, creating a dynamic effect.
     Once the scale-down process is complete, it enables the DugenPrefab.
    DugenPrefab:
     This prefab contains the 3D GameObjects that make up the main dungeon setup, forming the core of the environment.

 DungenPrefab Gameobject : 
 
 ![SceneFlow_7_DungenPrefab](https://github.com/user-attachments/assets/1a5c076d-8634-426f-b8c2-016215661aad)

 The DungenPrefab GameObject serves as the central structure for the dungeon environment.
 Components:
  ScaleAnimation Script:
   Responsible for the scale-up animation of the dungeon environment, ensuring a smooth and dynamic transition when the dungeon is activated.
  Child Object: PoseDebugger:
   The PoseDebugger is a child of the DungenPrefab.
   Functionality:
   Detects swipe hand gestures, enabling user interaction within the dungeon environment.
   It is automatically enabled as part of the setup.
 This comprehensive setup combines animation and gesture detection to create an interactive and immersive dungeon environment.

 
UI Instructions and Interfaces :
Flow of the Scene and Event Progression
Instruction UI 1 : 

![Instructions](https://github.com/user-attachments/assets/1e8dc5ac-f600-4673-ad81-fe9b25ecca2d)

  - UI 1: Instructions Screen
    This initial UI provides instructions on how to perform basic interactions, such as grabbing an object and executing a swipe gesture.
    Interaction: A button is displayed on the screen. Clicking this button transitions the user to the tutorial phase.
    
Instruction UI 2 :

![Instructions2](https://github.com/user-attachments/assets/c86b24dd-30ca-46e9-b417-806c05a0ebc6)

  -> UI 2: Tutorial Phase
    The tutorial screen presents two interactive cubes:
    One cube demonstrates how to grab objects.
    The other cube showcases the rotation functionality using swipe gestures.
    Additional Interaction: A push button is included to allow progression to the next phase.
    
Instruction UI 3 : 

![Instructions3](https://github.com/user-attachments/assets/4324005b-1f04-40d4-b807-bbee7be2e6a0)

  -> UI 3: Tutorial Completion Screen
      This screen confirms that the user has successfully performed the grab and swipe gestures.
      Interaction: The push button on this screen enables users to proceed to the main scene.
      
Main Scene View  :

![mainScene](https://github.com/user-attachments/assets/28d843c0-7fa1-4d1c-8846-95165a69ca00)

 -> Main Scene: Dungeon Environment
    The main scene immerses the user in a dungeon-themed 3D environment.
      Features:
      Multiple 3D objects populate the environment.
      Particle effects enhance the atmosphere and visual appeal.
      
Object To Rotate On swipe Gesture view  : 

![MainScene_ObjectToRotate](https://github.com/user-attachments/assets/507455ce-e60f-403d-868a-899a4295486d)

Objects To Grab View :

![mainScene_ObjectsToInteract](https://github.com/user-attachments/assets/33765fcd-f3dc-4bb0-a7eb-25238de28ca5)

   Main Scene Interactions
     Rotatable Objects: The user can identify specific objects in the environment that can be rotated using swipe gestures.
     Grabbable Objects: Several 3D objects are placed on a virtual table, which the user can grab and interact with using their virtual hands.
   
Challenges and Creative Solutions

Challenge 1: Hand Tracking with Limited OS Support
In the absence of a Meta Quest device, which supports XR Hands with advanced hand gesture detection (including non-static gestures like swipe gestures), I used the Pico Neo 3 Pro Eye headset with OS version 5.7+. While the Pico headset supports hand tracking at a basic level, aligning it with XR Hands and XRI Interactions required significant adjustments. To address this:
- I implemented the modifications detailed in the PICO Hand Models section above.
- Despite these changes, I faced challenges in object-grabbing functionality due to the limited capabilities of the OS version. However, I managed to implement the basic required functions for the task.

Challenge 2: Implementing Swipe Gesture Detection
The Pico headset, when paired with the XR Hands package, only supports static hand gesture detection. Since swiping is not a static gesture, I developed a workaround:
- I utilized two hand poses:
  1. An open palm flexing shape as the base pose.
     
     Flex Shape :
     
     ![FlexShape](https://github.com/user-attachments/assets/d22f4827-5e45-4bc2-8ffd-ad3ef3e7e438)

     Conditions for Finger Shape Detection:
      Thumb: Excluded from the conditions.
      Other Fingers:
      Shape: Full Curl
      Upper Tolerance: 0.35
      Lower Tolerance: 0.25
      Desired Value: 0 (indicating no curl in the fingers)
     
    Flex Pose :

    ![FlexPose](https://github.com/user-attachments/assets/0010d1aa-4816-47c4-9683-26f1953f8d69)

     Assigned Hand Shape: FlexShape
     Relative Orientation Conditions:
     Hand Axis Thumb Extended Direction:
     Alignment: Aligns With
     Reference: Origin Up
     Angle Tolerance: 90
   Detection Workflow:
   When all Flex Shape and Flex Pose conditions are satisfied, the pose is considered detected.
   Upon successful detection, the system enables the left swipe gesture, allowing interaction based on this gesture.
  
  2. Full curl parameters to define another pose resembling a swipe gesture.
     
     Swipe Shape :
     
     ![Swipeshape](https://github.com/user-attachments/assets/338ad1c1-2e70-4846-9545-c17823056ead)

     Conditions for Finger Shape Detection:
      Thumb: Excluded from the conditions.
      Other Fingers:
      Shape: Full Curl
      Upper Tolerance: 0.15
      Lower Tolerance: 0.15
      Desired Value: 0.5 (indicating midlevel curl in the fingers)
     
     Swipe Pose :
     
     ![swipePose](https://github.com/user-attachments/assets/b98e9fe7-7475-4026-91b3-6b7f6ec78823)

      Assigned Hand Shape: SwipeShape
      Relative Orientation Conditions:
      Hand Axis Thumb Extended Direction:
      Alignment: Aligns With
      Reference: Origin Up
      Angle Tolerance: 90
   Detection Workflow:
   When all swipe Shape and swipe Pose conditions are satisfied, the pose is considered detected.
   Upon successful detection, the system enables the right swipe gesture, allowing interaction based on this gesture.

- Using these two poses and the On Gesture Performed events, I performed rotation operations on the respective game objects to simulate a swipe gesture.

These solutions allowed me to achieve the required functionality despite the hardware and software limitations.

Things I Could Have Done Better
 Availability of Meta Quest
  - The Meta Quest headset, with its advanced support for XR Hand interactions and dynamic gesture detection (like swiping gestures), would have made the implementation smoother and easier. Using this device could have significantly reduced the challenges faced with gesture detection on the Pico Neo 3 Pro Eye headset.

 Event Handling Through Code
  - Instead of assigning GameObjects and their events directly in the Unity Inspector, I could have implemented a programmatic approach using code logic. For instance: Triggering rotation events for GameObjects upon detecting a swipe gesture could have been achieved through inheritance and object-oriented programming principles.
    Similarly, for UI events like OnButtonClick(), using code-based event handling would have been more robust and scalable.
 Icon Design
  - My lack of experience in creating or designing icons led me to rely on reference images to convey instructions. Developing custom-designed icons could have enhanced the user experience and improved the application's overall aesthetic.

 Device Limitations
  - The Pico Neo 3 Pro Eye headset, although functional, lacked the OS version required for smooth XR Hand Tracking. Due to work constraints, I was unable to update the device's OS. With an updated OS, tasks like gesture detection and interaction would have been much smoother and efficient.

