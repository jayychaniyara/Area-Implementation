# AreaImplementationMVC-Crud

Initial steps to follow before start project into local system:

1. Web.config : file change connection string to your system.

2. Update database : (i) Update-Database -Configuration UdemyMVC.CompanyMigration.Configuration (ii) Update-Database -Configuration UdemyMVC.IdentityMigrations.Configuration

Description of project :

This project demonstrates diffrent Areas in MVC (eg. Admin, Manager and Customer) and according rights for CRUD with respect of diffrent Areas. Ajax and WebApi used in Admin->Brands. Register and Login functionality also applied with AspNet.Identity. Layered architecture followed to differentiate and manage code. InCase if you change any models then you need to update database by following commands:

1. Enable-Migrations -ContextTypeName UdemyMVC.Identity.ApplicationDbContext -MigrationsDirectory IdentityMigrations
2. Add-Migration -Configuration UdemyMVC.IdentityMigrations.Configuration Initial01
3. Update-Database -Configuration UdemyMVC.IdentityMigrations.Configuration
