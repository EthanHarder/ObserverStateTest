Ethan Harder 100877874

# Observer

My UI wants to know when the player has made progress and how much. but you dont want the player to tell the UI to do that, and you also dont want the UI to be running its own update that constantly checks the player progress if you can help it. Instead, I can just regularly make an event that updates the value of how much progress has been made.

This observer reduces the number of updates happening that we dont know about, and can also add the incremental progress bar feel of the origional game (versus it being too smooth/updated too frequently).
