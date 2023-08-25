# FunBooksAndVideos

Description:
FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users
can have memberships for the book club, the video club or for both clubs (premium).

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
     
