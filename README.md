# Stocks App
A project showing a SPA application using ASP.NET Core 5.0, EFC, REST Api, Blazor WebAssembly (also some custom css and html) and SQL database. The application is similar to [Yahoo Finance](https://finance.yahoo.com).

# The architecture of the application is presented below
![image](https://user-images.githubusercontent.com/80456075/123469429-53861f00-d5f3-11eb-9e29-82d30538ff2e.png)

# Solutions
The application allows you to create and add a new user to the database. Authentication in the application is implemented using ASP.NET Core Identity, and communication with the database is done using Entity Framework Core. The database has been created using the CF (Code-First) pattern. After logging in, the client application first communicates with our REST Api, then our controller, depending on the type of request, directs it to a separate service responsible for communication with PolygonIO (an external service storing data about stock quotes of a given company), or to a service responsible for communication with our database. The whole project is created in Blazor WebAssembly technology. On the client side I used additional framework Syncfusion, which is responsible for rendering simple objects like list of liked companies or company stock quotes chart. The application has a caching system for stock data of previosly searched companies.

# Screenshots from application below
![image](https://user-images.githubusercontent.com/80456075/123469776-cd1e0d00-d5f3-11eb-8f6c-de3a534ea21e.png)
![image](https://user-images.githubusercontent.com/80456075/123469828-ddce8300-d5f3-11eb-8462-37c9b9210a50.png)
![image](https://user-images.githubusercontent.com/80456075/123469894-f0e15300-d5f3-11eb-9e91-75521db6e311.png)
![image](https://user-images.githubusercontent.com/80456075/123470060-284fff80-d5f4-11eb-8a76-75d080dbdd60.png)
![image](https://user-images.githubusercontent.com/80456075/123470091-36058500-d5f4-11eb-8bb2-44fcd972b841.png)
