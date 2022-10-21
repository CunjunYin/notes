# Representational state transfer (REST)
Common web applications are designed to provide backend logic, and persistent data storage and then serve as a graphical user interface to a browser for clients. In this method, backend logic and the presentation are coupled together, thus low extensibility. So Application Programming Interfaces APIs was introduced in web developenet to provide seperate  front-end(presentation) and backend(logic), so same logic can be provided to various types presentations.

Nowadays, Representational State Transfer(REST) is the most common architecture followed by industries when they develop Web APIs. To simply explain REST, it's an architecture used to transfer resources in a representation,  with State.
* resources can be anything
* representation (XML, JSON, etc)
* State transfer as HTTP is stateless, current page acting as a proxy for user state and operations to move from one to the other

## Characteristics of REST
There are 6 high level Characteristics set by Dr Fielding. `client-server`, `layered system`, `cache`, `code on demand`, `stateless`, `uniform interface`. Those are not enforced. Software engineers should apply differently for each case.

### 1. Client Server Model
Client and Server are two different software. They are communicated through transport layer.

### 2. Layered System
In a layered system, the client and the server do not need to talk to each other directly, intermediate software can be placed between the client and server. So abstract interface can be encapsulated to provide additionality functionality for the application like load balancing and proxy.

### 3. Cache
The cache principle states that it is acceptable for the client or intermediaries to cache responses to requests, and serve these without going back to the server every time, but for the best practice, the server must label whether the resource is cacheable.

> Note: do not cache encrypted resources in intermediates

### 4. Code on Demand (optional)
The code on demand principle states that the server can provide executable code in responses to a client. This is common practice with web browsers, where javascript is provided to be run by the client. However this isn’t commonly included in REST APIs since there is no standard for executable code, so for example, iOS won’t execute javascript.

### 5. Stateless
The server should not maintain any memory of prior transactions, and every request from the client should include sufficient context for the server to satisfy the request. The representative state is passed with the URL for each request.

> Pragmatically, many REST APIs record state

### 6. Uniform Interface
1. Unique resource identifers - the url `api/users/<id>`
2. Consistent Resource representations, The data exchange between client and server should be through an agreed format or negotiated through HTTP.
3. Self-descriptive messages. The communication between the client and server should make the intended action clear.
4. Hypermedia links. A client should be able to discover new resources by following provided hyperlinks.

# RESTful operations
In software, CREATE, READ, UPDATE and DELETE (CRUD) are standard ways to interact with persistent models. In Web application there operations are mapped to POST, GET, PUT (PATCH) and DELETE. These operations can be applied to each route in our
application, to allow client interact with the server side data model. The defination for these verbs are:
* GET: Retrieve data from the web service.
* POST: Create a new item of data on the web service.
* PUT: Update an item of data on the web service.
* PATCH: Update an item of data on the web service by describing a set of instructions about how the item should be modified. The sample application in this module doesn't use this verb.
* DELETE: Delete an item of data on the web service.