# Project - MusicBox web music service

Development of a web application that implements the simple functionality of Yandex Music. There is a site admin panel for creating and editing artists, albums, tracks.
 
To create the application, I used the following tools and technologies:

• ASP.NET
• Entity Framework
• Autofac
• OWIN & KATANA
• ASP.NET Identity
• FluentValidation
• Bootstrap
• jQuery
• Ajax

Application code has been created with MVC architectural design pattern. Used onion architecture.
Code-First was used to create the database. There are 3 types of links: "one to one", "one-to-many", "many-to-many.".

Basic functionality for users: Listening to songs of specific artists and albums. Chart formation (most listened to songs at the moment). Add the song you like to your playlist. Registration on the service, with the ability to reset the password and confirm mail.

The main functionality for the administrator: СRUD operations with tracks, albums, artists. Particular attention is paid to the validation of the input data.
