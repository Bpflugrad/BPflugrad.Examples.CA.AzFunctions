# BPflugrad.Examples.CA.AzFunctions

An example project attempting to show Uncle Bob's [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) 
implemented with the Command Pattern executed by Azure Functions.

`BPflugrad.Examples.CA.AzFunctions` is the executable, or "Main Component", where dependencies are wired up in the `IServiceCollection`.

## BPflugrad.Examples.CA.Infra.Web

This project has the definition of each Azure Function trigger method, as well as any classes interested in details of Http Requests and
other web related activities.

## BPflugrad.Examples.CA.Adapters

This project contains adapters between the Infrastructure layers, and the Application Use Case layer.
Controllers, Gateways, and Presenters are defined here.

## BPflugrad.Examples.CA.Application

Application Use Cases, and the base abstract Commands are defined here.