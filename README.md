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

