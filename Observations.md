Observations
-----------

1 - There is no attempt at a "domain model". Data model is anemic, and a "transaction script" is used with the command handlers. I think this is good because a domain model isn't necessary at this stage.

2 - Some abstractions could be of use, ex. an IBus and ICommand & ICommandHandlers, but refactoring to this would  introduce infrastructural noise and not necessarily add value to the codebase. Again, simplicity is a plus here in my book.

3 - The role of the current user is a very important concept in the application. I would prefer a more explicit approach to authorization, and perhaps have AuthorizeSellerRole and AuthorizeBuyerRole attributes instead of OrangeBricksAuthorize(Roles = "Buyer").

4 - Unless my developers were really, like really bored with absolutely nothing in the backlog to do, I wouldn't be as gung-ho about enforcing that a separate test be written for each property that is being mapped from a command to the data model. This could be done in one single test, or caught by a higher-level suite. 

5 - Test names - This is a matter of taste, but I prefer tests to follow a more BDD naming approach of the form "when XXX then XXX". Unless we are testing a very low-level "unit", such as a Money class, for example, the important thing to know isn't that CreatePropertyCommandHandlerTests failed, it's that the assertion "when creating a new property it should have a price higher than zero" no longer holds true.