# L²P API Client

This is an implementation of a client for the L²P API using C# and .NET. Every API Call fo the L²P is available in here. 

## Projects

There are currently two projects in this solution. 

 - The L2PAPITestApplication is a very simple Console Application that shows, that the API is working and provides examples, how to use the API Client
 - The L2PAPIClient contains the actual implementation of the Client for the REST-API of the L²P.

## Configuration

In the L2PAPIClient Project you find the *ConfigSample.cs* - just add your ClientID in here to enable the Client to work.

Further, you might want to override the getters and setters in the Config for xour needs (e.g. store these data in a persistent storage)

## Dependencies

Besides the .NET Framework there are further dependencies. These include:

 - Newtonsoft.JSON package - this is licensed under MIT license (see *RESTCalls.cs* where it is used) - If you do not want to use this for JSON-(De)Serialization, you might replace it.
 - System.net.http - this is an assembly of Microsoft, that is not part of the inner .NET Core but is available via NuGet. This package is used for the Http WebRequests for the REST-Calls
 
## Remarks

 - This Client is not using WCF and also has some Compiler Options integrated to make it portable. This should allow you to use this not only for Windows Platforms but further, portable ones. (e.g. Xamarin.Android, Xamarin.iOS, Windows Phone 8, Unix/Mono)
 - If you find Bugs in the API, please report to CiL

## License

This piece of software is licensed under the 2-clause BSD License (see *LICENSE*) - so, it's Open Source and everyone is welcome to use it.