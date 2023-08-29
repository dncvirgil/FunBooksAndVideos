# FunBooksAndVideos

Description:
FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users
can have memberships for the book club, the video club or for both clubs (premium).

# Implementation details
N-layered architecture was chosen for this PoC because of it's advantages: separation of code and simplicity.
It consists of the ApiLayer, Services (where the business logic is implemented) and Data accesss layer (responsible for communication with the database and EF Core migrations).
The ApiLayer receives a HttpRequest and calls the service which will apply all business logic once it validates and builds the domain object.
The Service layer is responsible for comunication with repositories. The repositories map the domain objects to entities and make the necesary changes to the database.
IntegrationTests project contains all the integration tests.
Service.UnitTests contains all the unit tests for the service layer.

Assumptions/missing information:
- Only one endpoint is implemented; all others showcase the proposed RESTfull design
- It is assumed that the purchase order request comes directly as it is from the client, without taking into account the payment system, the ability to choose the shipping address or any other information to fulfill the order
- The purchase order processor could be easily taken out and built as a standalone microservice which receives a message from the current app using a queue. For example, you could either use a microservice where the strategy is implemented or use topics with different listeners
- Website users must register if they want to buy any products and create an account. The customer account contains information regarding shipping address
- The website sells 4 types of products: video, book, ebook, membership. The membership is considered a product type. The membership type should be linked with available products once activated for an account (customerMemebership). 
- Users could see all their products after purchase in their account, see their memberships and check all available products given their membership type

# Build Prerequisites

- [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

# Local Run
1. You need to set-up appsettings.Development.json with correct values for database server name.

2. Create an SQL Server Instance locally and make sure that your domain user has 'dbowner' permissions on this database. 
Run migrations from FunBooksAndVideos.Data (you can use Package Manager Console and run Update-Databse. Make sure in console you select the EFcore project and your start-up project is the one containing the appsettings.Development.json file. Pay attention to your connection string to be the local one).
For testing the CreatePurchaseOrder endpoint, insert into the newly created database the following 2 records:  
&emsp;  Insert into Users Values ('username', 'password')  
&emsp;  Insert into Customers Values ('Customer Name', 'email@abc.com', 1, 'billing address', 'shipping asdress')  

Example of request for testing this endpoint:  
{  
  "customerId": 1,  
  "totalPrice": 45.80,  
  "itemLines": [  
&emsp; "Video \"Comprehensive First Aid Training\"",  
&emsp; "Book \"The Girl on the train\"",  
&emsp; "Book Club Membership"  
  ]  
}  
     
