# EventStormingPost
Simple project, where I try to use EventStorming + CQRS using MediatR

In this project, you can create post. 
After you created post, in project we have simple event with notification, which adds post to approve for Admin.

![project example](https://github.com/lebio7/EventStormingPost/blob/main/EventStormingPost.API/example.png)https://github.com/lebio7/EventStormingPost/blob/main/EventStormingPost.API/example.png)

API - Technologies

ASP.NET Core
C#
MediatR
Swagger


CQRS
EventStorming
Modular Application


EventStormingPost.Infrastructure is very simple, without database, because my main target was created Post and used Publish to implement event.

