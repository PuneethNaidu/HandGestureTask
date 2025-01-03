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
 - Repeat the same steps as above for XRI Right Interaction, but choose the Right Hand.

 XR Origin Rig Setup
1. Locate the XR Origin Prefab in the Starter Assets of the XR Interaction Toolkit.
2. Add the PXR_Manager component.
   - Turn off MRC.
   - Enable Hand Tracking.

 PICO Hand Models
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
 
UI Instructions and Interfaces :
Flow of the Scene and Event Progression
Instruction UI 1 : ![Instructions](https://github.com/user-attachments/assets/1e8dc5ac-f600-4673-ad81-fe9b25ecca2d)
  - UI 1: Instructions Screen
    This initial UI provides instructions on how to perform basic interactions, such as grabbing an object and executing a swipe gesture.
    Interaction: A button is displayed on the screen. Clicking this button transitions the user to the tutorial phase.
Instruction UI 2 : ![Instructions2](https://github.com/user-attachments/assets/c86b24dd-30ca-46e9-b417-806c05a0ebc6)
  -> UI 2: Tutorial Phase
    The tutorial screen presents two interactive cubes:
    One cube demonstrates how to grab objects.
    The other cube showcases the rotation functionality using swipe gestures.
    Additional Interaction: A push button is included to allow progression to the next phase.
Instruction UI 3 : ![Instructions3](https://github.com/user-attachments/assets/4324005b-1f04-40d4-b807-bbee7be2e6a0)
  -> UI 3: Tutorial Completion Screen
      This screen confirms that the user has successfully performed the grab and swipe gestures.
      Interaction: The push button on this screen enables users to proceed to the main scene.
Main Scene View  : ![mainScene](https://github.com/user-attachments/assets/28d843c0-7fa1-4d1c-8846-95165a69ca00)
 -> Main Scene: Dungeon Environment
    The main scene immerses the user in a dungeon-themed 3D environment.
      Features:
      Multiple 3D objects populate the environment.
      Particle effects enhance the atmosphere and visual appeal.
Object To Rotate On swipe Gesture view  : ![MainScene_ObjectToRotate](https://github.com/user-attachments/assets/507455ce-e60f-403d-868a-899a4295486d)
Objects To Grab View : ![mainScene_ObjectsToInteract](https://github.com/user-attachments/assets/33765fcd-f3dc-4bb0-a7eb-25238de28ca5)
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
  2. Full curl parameters to define another pose resembling a swipe gesture.
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

