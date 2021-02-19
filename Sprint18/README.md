# Sprint18.-Authentication-Authorization
### The structure of the project is the same as in previous two sprints.
### Please, differentiate access to the resources as described:
###  

1. All users are allowed to see pages products and supermarkets
1. Only user with role "admin" can create/edit/delete supermarket
1. Only user with role "admin" can create/edit/delete product
1. Only authenticated users can see the content of the Home page
1. Only users with role "admin" can see page Customers
1. User with role "admin" can see page *Orders* with orders from all users
1. User with role "buyer" can see page *Orders* only with his own orders and cannot modify, create or delete orders
1. Every buyer receives claim "buyerType" with possible values: "none", "regular", "golden", "wholesale".
1. Only buyers with "golden", "wholesale" claim values have access to Discount page (*My Discount* tab in the main menu)

1. Implement *Register* page that creates user and assigns to him default role Buyer and type Regular
1. Implement *Login* page that should be accessible through *Login* tab (link) in the main menu. When user is logged in the link should be changed to *Logout*
1. **Implement Admin tab that is available only to users with Admin role.  On this tab user with an "admin" role can*
	* See the list of all users
	* Edit any user - ability to change his role and claim buyerType
# 	
*Note: if some action or view is forbidden for user, corresponding links or tabs should be hidden and action shouln't be accessible neither via link nor via url*
