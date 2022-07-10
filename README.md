# piggy-bank-v2

This project is the API version of the original piggy bank.

This project doesn't use any form of data persistance a inMemory database is used, if the project is restared all memory of previous actions will be lost.

Prerequisites for this project is:
  1) .net core version 6 installed on the computer.

Steps to run the project
  1) Clone this repository
  2) From the base project open terminal OR you can open the project from visual studio code or visual studio
  3) On the terminal type: dotnet run
  4) The command line should indicate that the project has been started on: https://localhost:7126
  5) Open a browser and in the URL section type https://localhost:7126/swagger
  6) That will take you to the endpoint documentation

There are 4 Endpoints associated to this project.

1) get-total-amount
  This endpoint is to view the current amount of money that is in the piggy bank.

2) Get-accepted-coin-types
 This is purely a endpoint for convenience, this endpoint retreives a list of coins that can be inserted and their ID which is used for the add-coins calls.
 
3) Add coins
  This endpoint is used to add an amount of a certain coin. 
  
  It has two parameters: 
  1) CoinID 
    This is used to identify what coin is being inserted, the viable id's can be found from the <b>Get-accepted-coins</b> end point
  2) Amount. 
  The amount refers to the amount of the coin you want to insert. 
  
4) reset
This endpoint resets the piggy bank.  
   

