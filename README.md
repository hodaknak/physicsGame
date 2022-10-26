# physicsGame
physics game vr

instructions for devs:
basically you want to go to Assets/Assets/Modules and create a new scene using my template by going to File > New Scene
Once you've created your scene that's your "module" so make everything in there
I'll organize files in the Assets/Assets folder by making folders such as "scripts", "materials", "prefabs", etc. so organize any new assets you make accordingly.

haven't decided yet but i think we're going to work with branches

some things to keep in mind:

make sure all interactable objects (objects you can hold) have the "interactable" layer assigned or you'll start skydiving when moving (yes unity is very weird)

make sure all interactable objects have the XR Grab Interactable component attached to it, and in "Colliders" add all the colliders you want to be "grabbable". Also make sure the Interaction Manager variable is set to the "XR Interaction Manager" script (I know this is confusing, just ask me in person for help). All interactable objects must have a rigidbody.
