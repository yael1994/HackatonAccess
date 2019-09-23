# Hackaton Access
The Hackaton sabjet was accessibility, providing a solution to an existing problem for disabled people.
Our system answer the problem that deaf people do not hear the announcing systems in different places such as the train station, airport And more.
Our solution for the problen is a system that converts the message from voice to text and sends the message to deaf people on the mobile phone.
The system combine 3 parts: 

## Web program
The web program connect to the system announces and knows when a new message is coming, when there is a new massage the program send to the next part.
the web progeam is at C#.

![](DesHa.JPG)

The program listener to all the massage that come, send to the algorithm in the next section and then show the massage before senging it to all the people that "listener" to the service. 
we can make change in the massage and then click on "Send". 

## Algorithem convert - voice to text
Using a algorithm open source of google to cover from voice to text. 
the algorithm is at python. 

## Android app
Android application that connect to the local service and get the new massage as a "pop up" massage.

![](AppHa.JPG)
