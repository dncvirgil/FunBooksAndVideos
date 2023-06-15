# FunBooksAndVideos

Description:
FunBooksAndVideos is an e-commerce shop where customers can view books and watch online videos. Users
can have memberships for the book club, the video club or for both clubs (premium).

# Build Prerequisites

- [.Net 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

#Local Run
1. You need to set-up appsettings.Development.json with correct values.

2. Create an SQL Server Instance locally (named: FunBooksAndVideosDb) and make sure that your domain user has 'dbowner' permissions on this database. 
Run migrations from FunBooksAndVideos.Data (you can use Package Manager Console and run Update-Databse. Make sure in console you select the EFcore project and your start-up project is the one containing the appsettings.Development.json file. Pay attention to your connection string to be the local one).
     
