# Battleship Game with Sockets

## Introduction
Welcome to the Battleship game made with Sockets! This project was created with the aim of providing an entertaining and interactive game that can be played between two players over a network connection, it was asked for a school project. Please note that the code and UI is written in Portuguese since I am from Portugal.

## Getting Started
If you encounter errors in the code/design upon opening the project, it's likely due to the references. To resolve this, click on the references for the "Player1" and "Player2" projects and select "add new reference". Then, click on "browse" and open the "Krypton-master" folder that is located with the other project files. After that, just open the bin folder (click "type" to make it easier) and select the files that start with "ComponentFactory.Krypton....", EXCEPT for "ComponentFactory.Krypton.Design.dll", which should not be added.

To play the game, open the "Server" file where you can view logs of the game (moves made by players). Connect the player from the "Player1" file to the server first, and then the "Player2" file. Otherwise, the project will not work properly. You need to play first with "Player1", and after their turn, play with "Player2" following the same process.

## Features
The game has the following features:
- Players are only able to attack after placing their ships
- Real-time play on the attacked player's side is displayed immediately after an attack, rather than waiting until the next play
- Turns have been implemented to prevent players from making multiple attacks in a row
- The winner can now be easily identified.

## Project Status
This was my first time working with Sockets, so the project has some bad code and maybe still a few bugs even after the updates. However, I welcome any contributions to improve the project and make it work 100%, as it could be a cool project if it worked 100% well.

## Credits
The UI was created with [Krypton](https://github.com/ComponentFactory/Krypton).
This project was created in collaboration with [DreamOutLoud365](https://github.com/DreamOutLoud365), although the developer is currently the only one updating it.

## Video (Outdated - recorded when there was many bugs, now its way better)
To see a video of the game in action, click [here](https://user-images.githubusercontent.com/66210711/195928002-e63e497b-bd03-48ca-9598-fb64162b11b8.mp4).

## Updates
### April 27, 2023 | Fixed some bugs
- Players are now only able to attack after placing their boats
- Real-time play on the attacked player's side is displayed immediately after an attack, rather than waiting until the next play
- Turns have been implemented to prevent players from making multiple attacks in a row
- The winner can now be easily identified.
