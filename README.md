# SD_Company
Please follow the following guides to Run the API correctly.

* First Of all You need to have these Packages Installed:
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.IdentityModel.Tokens
- System.IdentityModel.Tokens.Jwt
- Swashbuckle.AspNetCore

* Next you need to Import all these for classes that require tho.
now you can build the solution...

* Now You can Add Your First Migration to the SqlServer Instance Or any database you have Locally.
-for SQLServer-
open Package manage console then write down the follow:
- Add-Migration MyFirstMigration
- Update-DataBase

Next you can Insert a Login Data for YourSelf to Login Table.

Now login and Try to Do (POST , PUT , DELETE) for Departments and if not Authenticated I believe you won't be Allowed to.

* (Employee, Projects & WorkOn) are public so far So you can test'em with no JWT token.
Please start with POST To have some Existing Data to deal with.
