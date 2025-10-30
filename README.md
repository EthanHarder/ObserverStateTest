Ethan Harder 100877874


known issue that the UI doesnt scale correctly on the build. sorry!

<img width="751" height="424" alt="image" src="https://github.com/user-attachments/assets/c59e7283-db20-49db-b1bd-17d6baa901e3" />

# Observer

My UI wants to know when the player has made progress and how much. but you dont want the player to tell the UI to do that, and you also dont want the UI to be running its own update that constantly checks the player progress if you can help it. Instead, I can just regularly make an event that updates the value of how much progress has been made.

This observer reduces the number of updates happening that we dont know about, and can also add the incremental progress bar feel of the origional game (versus it being too smooth/updated too frequently).

We connect the listener at the start
<img width="446" height="134" alt="image" src="https://github.com/user-attachments/assets/8a2d3e39-f146-44d8-bf77-d5791145021d" />
and then perform the behaviour only when we observe the responce from the player here:  <img width="194" height="53" alt="image" src="https://github.com/user-attachments/assets/48e76f79-9700-4fd1-944e-94996d91264d" />  
This section controls the frequency of the observation, so the progress bar always increments in peices.



