VAR RunAway = false
VAR numOfEnemies = 3

Hello... Do you hear me?
I need your help. It looks like we're stuck here.
You look strong. You can take out the enemies here.
Defeat the 3 enemies and I think we can escape from here.
Will you help me?
+ [Yes] -> Fight
+ [No] -> Run
=== Fight ===
Thank you... I'll be back after you defeat the enemies...
-> DONE

===Run===
I see, You aren't ready yet...
. . .
~RunAway = true
->END
