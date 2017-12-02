# webapi-jwt-angular-boilerplate
This is a sample boilerplate for web solutions using web api 2.2 with jwt based authentication and angular as a web client.
# Architecture
* Frontend
Consists of an Angular-based web client, styling is accomplished by using bootstrap together with some custom css
* Backend
An ASP.NET Web api 2.2 based RESTful API
# Components
* Frontend
  * Angular for the functional UI parts
  * Bootstrap provides the responsive layout
* Backend
  * Web API 2.2 based RESTful API
  * Authentication/Authorization is done via JWT based token flow
  * For persistence T-SQL is used with Entity framework as ORM
  * Special thanks to mehdime : https://github.com/mehdime/DbContextScope for writing a wonderful ambient context wrapper for entity framework

 
# Requirements
* Visual studio 2012+
* SQL Server/Express/LocalDB for persistence
* non-IE browser
