## This is an application that allows to view and manage list of products and list of users
## Please, add the next functionality to the application:
### Validation of products:
1. **Price**: value should be within boundaries 0 and 100000
2. **Name**: mandatory field
3. **Description**: 
   - not mandatory fild. 
   - if set, length sould be longer than 2 symbols
   - should not be equal to Name but should start with the Name of the product
4. **Type**: enum with values: *Toy, Technique, Clothes, Transport* - make this field displayed with a SelectList on Views for editing and creation to make impossible entering wrong value.

After clicking on Save button:
 - if there are no validation errors - the product should be saved and displayed in view (details) mode
 - othervise validation errors should be displayed on the same page
 
 ### Binding:
 1. Add an abiity to edit all prices at once for products of chosen category:
    - add corresponding links to the view with list of products
    - display **Id, Name and Price** of all products of chosen category on the view for editing prices
    - **price** should be available for editing 
    - **Id** and **Name** - readonly
    - Click on **Save** button: 
      - saves all the prices if there are no validation errors
      - displays errors if there are ones
 2. Add an ability to add a new user with query string (and this should be the only way) 
     - all fields on a creational form should be readonly 
     - fields should fill in only with parameters fron query string
     - on click on the Save button user should be displayed in wiew mode
 
