Observations
-----------

For the scope of the project, I think it is laid out very nicely and would not have gone about it much more differently. Great test.

Things I think work out well:

- No unnecessary abstractions (ex. no IRepository's). I like that there is no attempt at a domain model. The existing model is "anemic", and a "transaction script" architectural pattern is used with the command handlers. I think this is good because a domain model isn't necessary at this stage.
- There are consistent and obvious patterns used throughout, which make it much simpler for a developer to dive in and be productive. 
- Framework & libraries are used throughout in the manner that is prescribed.
- Mocks are used for unit tests, effectively separating database integration from the behavior and making them fast and easy to use.
- Controllers are very thin, and the ViewModel builder pattern is nice.

Things I would've perhaps considered to add:
- The role of the current user is a very important concept in the application. I would have maybe preferred 
a more explicit approach to authorization; maybe have AuthorizeSellerRole and AuthorizeBuyerRole attributes instead of OrangeBricksAuthorize(Roles = "Buyer").
- I would've maybe not done the SaveChanges calls in the command handlers, but instead left management of the transaction scope up to the calling layer. This would free the layer above to combine command handlers and do other
cool things. This is debatable though, as one could argue that if there is a composite command, it should be a handler itself. Good discussion to have.
- Test names - This is a matter of taste, but I prefer tests to follow a more BDD naming approach of the form "when XXX then XXX". Unless we are testing a very low-level "unit", such as a Money class, for example, the important thing to know isn't that CreatePropertyCommandHandlerTests failed, it's that the assertion "when creating a new property it should have a price higher than zero" no longer holds true.
- Some abstractions could be of use, ex. an IBus that would route commands to the appropriate handlers.
- A DI container wasn't needed at this point, but it would simplify creation of the handlers when they inevitably become more complicated (more dependencies).

Definitely did not like:

- Unless my developers were really, like really bored with absolutely nothing in the backlog to do, I wouldn't be as gung-ho about enforcing that a separate test be written for each property that is being mapped from a command to the data model. This could be done in one single test, or caught by a higher-level suite. Even then I would've rather
used that free time to do something else.
- Used UTC timestamps instead of DateTime.Now. In the US in particular we have 4 time zones so it simplifies things greatly when systems standardize on Utc and offset as appropriate for the user in the
presentation layer.

From a security perspective:

- Input sanitization
- Follow OWASP recommendations about hiding the server type & version in web.config
- Antiforgery tokens in every form.
- Rename the auth cookie to something else.

From a performance perspective:

- The problem space seems like very read-intensive (many more people viewing properties than listing them), with a certain level of tolerance for eventual consistency. I would hate to see a user attempt to create a new property and get an error
because the DB was locked by some read process at that point in time.
- Caching would be another approach.

From an architectural perspective:

- A stricter separation of the different aggregates - Property and Offer. Current model blurs the lines a little bit, but this is expected to happen with ORMs