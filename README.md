1. install
   a. Microsoft.EntityFrameworkCore.SqlServer
   b. Microsoft.EntityFrameworkCore.Design
   c. Microsoft.EntityFrameworkCore.Tools
2. create Models Folder
3. create Data Folder
   program.cs -> builder.Services.AddDbContext
   appsettings.json -> ConnectionStrings     "Data Source=localhost;Initial Catalog=finshark;User Id=sa;Password=MyPass@word;Integrated Security=True;TrustServerCertificate=true;Trusted_Connection=false"
