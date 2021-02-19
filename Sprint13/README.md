# Csh-Marathon-Spr13
 C# Marathon Sprint13

 
Sprint 13. Tasks

All the views are based only on the Razor syntax.
1.	Change Index view:
![Index](/images/1.png)
   - Change the title of tab;
   - Add navy bar “Sprint Tasks” that redirect to page “Sprint Tasks”;
   - ‘Our project’ is a link to your project on Git.



2.	View ‘SprintTasks’:
![SprintTasks](/images/2.png)
 
The page contains navigation bars  that redirect the user to the appropriate view-pages.



3.	View ‘Greetings’:
![Greetings](/images/3.png)
 
   - Messages are placed as variables;
   - Use DateTime methods;
   -	Use branching to send the greeting (evening or morning).




4.	View ‘ProductInfo’
![ProductInfo](/images/4.png)
 
   - Create the class Product with properties: Name (string), Price (double)
   -	Use this class to create the list of products just within the view.
   -	Use loop to output the information on the page.




5.	View ‘SuperMarkets’
![SuperMarkets](/images/5.png)
 
View page receives the list of supermarkets via ViewBag and output it with their quantity.




6.	View ‘ShoppingList’
![ShoppingList](/images/6.png)
 
View page receives the model dictionary from controller. Dictionary contains name of product (key), quantity (value).
View contains partial view ‘TimeToBuy’




7.	Partial view ‘TimeToBuy’ uses @inject.
You have to:
   - create the folder Services;
   -	define interface ITimeService with method GetTimeForTomorrow();
   -	define the class SimpleTimeService, that implement interface ITimeService. The method GetTimeForTomorrow() have to return the time for shopping just in a day;
   - map the dependencies in the Startup class, changing its ConfigureServices() method;
   -	inject dependencies into view to output the time of shopping for tomorrow.




8.	View ‘ShoppingCart’
![ShoppingCart](/images/7.png)
 
The page contains controls that you have to define using html-helpers:
   -	Input boxes;
   -	DropDown box that receives and contains the list of supermarkets;
   -	RadioButtons with values according to the today-date. User can choose date to ship order;
   -	ListBox that receives the keys of dictionary (use ShoppingList);
   -	‘submit’ input.
You should consider both (HttpPost and HttpGet) controller methods for this view.
As the result of submit user might receive the message:



![Result](/images/8.png)



As the result the structure of your project would be as follows:
![Structure](/images/9.PNG)



Resourses:
https://metanit.com/sharp/aspnet5/9.1.php
 


