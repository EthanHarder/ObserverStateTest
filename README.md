# Ethan Harder 100877874, Observer and States prototype


known issue that the UI doesnt scale correctly on the build. sorry!

<img width="751" height="424" alt="image" src="https://github.com/user-attachments/assets/c59e7283-db20-49db-b1bd-17d6baa901e3" />

# Observer

My UI wants to know when the player has made progress and how much. but you dont want the player to tell the UI to do that, and you also dont want the UI to be running its own update that constantly checks the player progress if you can help it. Instead, I can just regularly make an event that updates the value of how much progress has been made.

This observer reduces the number of updates happening that we dont know about, and can also add the incremental progress bar feel of the origional game (versus it being too smooth/updated too frequently).

We connect the listener at the start
<img width="446" height="134" alt="image" src="https://github.com/user-attachments/assets/8a2d3e39-f146-44d8-bf77-d5791145021d" />
and then perform the behaviour only when we observe the responce from the player here:  <img width="194" height="53" alt="image" src="https://github.com/user-attachments/assets/48e76f79-9700-4fd1-944e-94996d91264d" />  
This section controls the frequency of the observation, so the progress bar always increments in peices.


# States
I use a player logic script (perhaps incorrectly labelled as simply a playerStateHandler, and it has a current state, and some floats regarding the amount of time spent in that state. I can artifically add acceleration/decceleration by using the time spent in a state (multiply impact of state behaviour by how long its been active, thus accelerating over time). 

With this system, its nice that the player logic in the PlayerStateHandler doesnt need to know about how to move itself. In fact, player behaviours dont need to know anything except their own behaviour, and we pass any contexts they do need (like the input vector from PlayerInput, so it knows what direction to go) intentionally. It both prevents the urge to making crossconnections between input and movement, and also reduces the number of Updates happening all over the place. More streamlined procedures are always nice for later bug searching.

<img width="378" height="310" alt="image" src="https://github.com/user-attachments/assets/4c63154d-2b8a-47f1-bc85-4d23534050be" />

States are fairly simple with a function for how to behave in that state, and the rules of transitioning.  
<img width="328" height="230" alt="image" src="https://github.com/user-attachments/assets/3108a4e6-9fd2-44f7-ac5b-a3ce419dd9ba" />  
importantly, you cant transition to the hit stage or the drive stage if you have no fuel. The hit stage also 'unhits' itself when enough time has passed, which is a nice bonus of this solution (unhit logic is selfcontained in hitStatus)

Having a DeadState (dead meaning no fuel, like dead in the water, i guess?)  is great because i can have it decellerate you over time while still considering your inputs, rather then a hard cut once fuel hits 0.
  
  
If you hit the obstruction block, you are placed in the 'hit' state where you slow down, and then return to the drive state eventually.
<img width="397" height="294" alt="image" src="https://github.com/user-attachments/assets/3e918baf-8b45-4fc4-8732-49a58f0c1329" />

Sadly, i didnt get a refueling obstactly in time. This is my excuse for not making a dead -> drive state transition (since if you have no fuel but a fueling car should hit you, TECHNICALLY there is a change to refuel?). but I dont think this is a significant enough component to fret about, im simply agknowledging it.

# Object Pooling Addition

The obstructions in the way of the player now implement a simple object pool. the obstructions disable themselves if they hit the player or go offscreen, and the manager enables one of the obstructions if possible before creating new ones. This also as a bonus means that the special fuel recovery obstructions will be spawned routinely, since once the first is spawned it will be in the pool and iterated through as obstructions spawn.  
<img width="340" height="197" alt="image" src="https://github.com/user-attachments/assets/7bdb0c2b-13db-45eb-9c90-06cbbb9aceee" /><img width="332" height="106" alt="image" src="https://github.com/user-attachments/assets/8bf7eb40-7742-40d7-939d-9b98d9b732ba" />

# Command Addition

I wanted to add dev cheats for this game. i know that with some arcade games like PacMan they would break if a int overflowed or something several hours into play. so i wanted to add some tools for the devs to let them see how the game stress tests after several hours of play. to allow that, i added these 'cheat' commands  
Press f3 to get infinite fuel.  
Press f4 to disable your hitbox so you cant get hit by obstacles.  
Press Z to revert the commands, setting your fuel back to what it was when the command was entered.

<img width="248" height="410" alt="image" src="https://github.com/user-attachments/assets/62c4316d-3bcf-4156-bbb2-3e8476920f30" />

<img width="338" height="284" alt="image" src="https://github.com/user-attachments/assets/ab696ce6-29a0-4359-bb3f-5536222ab08d" />

You could imagine this getting expanded to a 'konami code' style cheat, so something like that.

<img width="371" height="337" alt="image" src="https://github.com/user-attachments/assets/45ff456a-281a-47c5-9ed3-54c34d73e311" />


# bonus question answers:

Game Engine Fundamentals.

A game engine is a piece of software intended to facilitate game creation. They contain base systems ideal for a specific type of game, and often contain extensible components to allow the engine to adapt to other genres as well.

Unity, Unreal Engine, Source, Scratch, Gamemaker, Godot, Renpy, and Swarm are examples of game engines.

Game engine architecture at the high level is composed of many components, like physics, audio, visual effect rendering, and input handling work together to produce real-time interactive experiences.

Rather then purely layered, many of these components want to act alongside other game events, not ‘before’ or ‘after’ them, so instead of a rigid hierarchy, high level components often work in parallel.

Design Patterns.

Game design patterns are architecture concepts that can help developers create more effective, performant, encapsulated, or expandable code.

Some patterns serve to reduce redundancy (singetons simplify references), some help encapsulate elements (command, factory), or optimize and reduce high-cost operations (object pool, dirty flag).

<img width="197" height="151" alt="image" src="https://github.com/user-attachments/assets/a43afb0e-ceaf-4300-8b63-09784589e5d8" />


Design patterns are a workflow aid. They help us go from making code that works now, to code that will keep working and doesnt need to be refactored when new demands are made of it.

Singleton

Singletons are a static instance reference to itself. 

Singletons allow you to contact systems or objects the object doesn't have a defined link/ proper reference  to.

