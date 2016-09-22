
** Project has moved to [RWTH GitLab](https://git.rwth-aachen.de/auxua/L2P-Api-Client) **

# L²P API Client

This is an implementation of a client for the L²P API using C# and .NET. Every API Call fo the L²P is available in here. 

## Projects

There are currently two projects in this solution. 

 - The L2PAPITestApplication is a very simple Console Application that shows, that the API is working and provides examples, how to use the API Client
 - The L2PAPIClientPortable contains the actual implementation of the Client for the REST-API of the L²P.

## Configuration

In the L2PAPIClient Project you find the *ConfigSample.cs* - just add your ClientID in here to enable the Client to work.

Further, you might want to override the getters and setters in the Config for xour needs (e.g. store these data in a persistent storage)

## Dependencies

Besides the .NET Framework there are further dependencies. These include:

 - Newtonsoft.JSON package - this is licensed under MIT license (see *RESTCalls.cs* where it is used) - If you do not want to use this for JSON-(De)Serialization, you might replace it.
 - System.net.http - this is an assembly of Microsoft, that is not part of the inner .NET Core but is available via NuGet. This package is used for the Http WebRequests for the REST-Calls
 - Xamarin.Forms - this is used for portability of the library. Xamarin is integrated by Microsoft sind Aptril '16. In old VS-Versions you might add templates/NuGet by yourself
 
All of these dependencies are available as PCL enabling support for portability.
 
## Remarks

 - This Client can be used with Xamarin.Android, Xamarin.iOS, WinPhone (8.1), Windows (8.1) and the Windows Universal Projects
 - If you find Bugs in the API, please report to CiL
 - By using the L2P API you have to commit to the RWTH/CiL/IT Center Guidelines for API usage and Privacy
 - If you need a legacy version of the client, you can find an old version in the git - Project "L2PAPIClient"

## Files

A very short explanation about the Files in the API Client:

* DataModel: contains the classes for Data model representation of the API. (No logic in here)
* AuthenticationManager: implementation of the OAuth Authentication and managing the tokens
* RESTCalls: The Calls of API and OAuth endpoints
* Config: The basic configuration of the API Client (base endpoints, tokens, etc.)

## License

This piece of software is licensed under the 2-clause BSD License (see *LICENSE*) - so, it's Open Source and everyone is welcome to use it.
