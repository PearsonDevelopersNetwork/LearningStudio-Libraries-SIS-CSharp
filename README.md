# The LearningStudio SIS API Libraries

The LearningStudio SIS API Libraries make working with the SOAP SIS APIs easier. There are three libraries that streamline our more complex and common domains. 

The full documentation is available in the \Documentation folder of this package. The main user guide describes the various functionality and use cases, but you can also skip straight to the auto-generated documentation if you prefer provided in the Documentation. 

## Getting Help 

Please use the PDN Developer Community at https://community.pdn.pearson.com


## Pre-Requisites 

These libraries are designed only as wrappers for the SOAP APIs. They make using the APIs easier, but will simply return the response from the API (i.e., an XML payload). You should be sure to read the API documentation and background information for LearningStudio while using these libraries. Here are some key places to start:

 * [LearningStudio Introduction](http://developer.pearson.com/learningstudio/get-started-0)
 * [LearningStudio Data Structure & API Info](http://developer.pearson.com/learningstudio/conventions-0)
 * [API Reference](http://developer.pearson.com/learningstudio/sis-apis-reference)


## Keys

For all API requests, you'll need a set of credentials; the APIs implement UsernameToken WS-Security. The API Username and Password control access to the LearningStudio campus you're integrating with. Every new campus you integrate with will have a distinct set of credentials.

You can get credentials for the Sandbox Campus in addition to other items useful for getting started, like test accounts and RESTful API Keys, through the PDN portal. Here's more information:

 * [How to Get Keys](http://developer.pearson.com/learningstudio/get-learningstudio-api-key-and-sandbox)
 * [Introduction to Multitenancy](http://developer.pearson.com/learningstudio/working-software-service-platforms)
 * [About the Sandbox Campus](http://developer.pearson.com/learningstudio/sandbox-campus)


## The Libraries 

### Courses
This library provides a variety of functions mapped to the Courses API to streamline the underlying create, copy, and update course operations. If you are building an application that provides an alternative way for administrators or professors to copy courses (i.e. a professor self-service course copy utility), this is the library you'll want to use.

### Terms 
This library provides a variety of functions mapped to the Terms API to streamline the underlying create, and update term operations. This library works well with the Courses library as the starting point for the course copy process is usually term creation and setup.

### Users
Automating the user creation and enrollment process is the most common reason people use the LearningStudio SIS APIs. This library makes working with the Users API a little bit easier. Note that this library currently only provides support for the synchronous user creation and enrollment operation; the asynchronous batch user creation and enrollment operation is not supported at this time.


(c) 2015 Pearson Education Inc. Released under the Apache 2.0 License.