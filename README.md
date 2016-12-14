# DesignByContract2
A school assignment of making a small simple banking application using code contract and design by contract principles. 

<h2> What I did and realised during this project</h2>
I chose to use UWP to show the different changes of state of the application, might have been a mistake on my part as it complicated the entire project many times over, but when I realised this I was so far in to it that I decided to finish it off anyway. 

the code contract I chose to implement was again with the interfaces and having the code contract part in abstract 
classes that implements the interface. 
when I make the implementation of the code contract I simply implement the interfaces and through them I will be forced to uphold the contract defined in the abstract classes.

I realise that this is not accessing any database and everything is happening in memmory. I was at first working on som form of data access layer and a place to store the data generated. But because of timelimitation and the difficulties I had with figuring out a good way to connect a database with the UWP framework, it is not impossible but currently lacking a lot of easy access tool support,I chose to make this project in memmory. Because of this I also feel I didn't accomplish all the assignment goals but I have to the best of my knowledge solved it in such a way that in principles all I need to make is a good data layer access component and a Database and then it should in reality be accomplishing all the goals of the assignment. Because the assignemnt focus is more on Code Contract and Design by contract principles I think that my little slip will not affect the assigment to intolerable levels.

<h2>Use of this project</h2>
The use of this project is fairly simple. 
compile and run the application on any windows 10 computer. 
Select one or more banks add accounts to their customers.
put money in and withdraw money from their accounts.
move money between the accounts. 
Remember to fill out the textbloks with relevant information to move money between accounts.
deposit and withdraw is simply hardcoded 100 credits.
if you make a move that breaks the contract there will be thrown an exception in your face.
a good way to see this is to try and make one account go in to minus or to attempt to move more money from one account than it contains.
in the real world there should be guards against exeptions but in this program I've left those out to see that the code contracts actually works.
