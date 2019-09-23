# Hackaton Access
The Hackaton subjet was accessibility - to provide a solution to an existing everyday problem for disabled people.
We addressed the issue that deaf people do not hear the announcing systems in different places such as the train station, airport and more. Our solution for the problen is a system that converts a spoken message from voice to text and displays the message on the mobile application.
The system consists of 3 parts:

## Web program
The web component connects to the announcements system and checks for new messages. When a new message is broadcasted, the program receives it and sends it to the next component. The web component is implemented in C#.

![](DesHa.JPG)

The program listener to all the massage that come, send to the algorithm in the next section and then show the massage before senging it to all the people that "listener" to the service. 
we can make change in the massage and then click on "Send". 

## Algorithem convert - voice to text
Using an open source algorithm to convert the received voice to text. The text is then sent to the Android application. The algorithm is implemented in Python.

## Android app
Android application that connects to the local server and receives the converted text and displays it as a "pop up" message. The application is implemented in Java.

![](AppHa.JPG)
