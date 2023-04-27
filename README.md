# Battleship game with Sockets

## Important note:

If you encounter errors in the code/design upon opening the project, it's due to the references. To resolve this, click on the references for the "Player1" and "Player2" projects and select "add new reference".
<p></p>
Then, click on "browse" and open the "Krypton-master" folder that is located with the other project files.
<p></p>
After that, just open the bin folder (click "type" to make it easier) and select the files that start with "ComponentFactory.Krypton....", EXCEPT for "ComponentFactory.Krypton.Design.dll", which should not be added.
<p></p>
<p></p>
<b>How to play:</b>
<p></p>
Open the "Server" file where you can view logs of the game (moves made by players).
Connect the player from the "Player1" file to the server first, and then the "Player2" file. Otherwise, the project will not work properly.

You need to play first with "Player1", and after their turn, play with "Player2" following the same process.

Note that the code is in Portuguese because the im from Portugal. This was my first time working with Sockets, so the project has some bad code and bugs. It doesn't work 100% as it may eventually crash or do something unexpected, such as not displaying the moves right away. I will try to fix it one day tho.
<p></p>
Feel free to use this project to improve and make it work 100%, as it could be a cool project if it worked well. 

<p></p>
<b>The UI was created with Krypton -> https://github.com/ComponentFactory/Krypton</b>
<p></p>
<p></p>
<b>Project created in collaboration with: https://github.com/DreamOutLoud365 | Im the only one updating it now tho.</b>
<p></p>

https://user-images.githubusercontent.com/66210711/195928002-e63e497b-bd03-48ca-9598-fb64162b11b8.mp4

# UPDATES

<h2>Update as of 04/27/2023 - Bugs have been fixed and the game now functions way better.</h2>

- Players are now only able to attack after placing their boats
- Real-time play on the attacked player's side is now displayed immediately after an attack, rather than waiting until the next play
- Additionally, turns have been implemented to prevent players from making multiple attacks in a row
- Finally, the winner can now be easily identified.
