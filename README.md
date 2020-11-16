# Project "MusicBox" - web music service

Development of a web application that implements simple Yandex Music functionality. There is a site admin panel for creating and editing artists, albums, tracks.

To create the application, we used the following tools and technologies:

• ASP.NET MVC
• Entity Framework
• SQL
• Autofac
• OWIN & KATANA
• ASP.NET Identity
• FluentValidation
• HTML
• Bootstrap
• jQuery
• Ajax

The application code was created using the MVC architectural design pattern. Onion architecture is used.

An approach "Code-First" was used to create the database. There are 3 types of links: one-to-one, one-to-many, and many-to-many.

Basic functionality for users: Listening to specific artists and albums. Chart formation (the most popular songs at the moment). Add the song you like to your playlist. Registration on the service, including the ability to reset your password and confirm your mail.

The main functionality for the administrator: СRUD operations with tracks, albums, artists. Particular attention is paid to validating input data.
