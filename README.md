# UWP-Project-3
This repository contains code and information for my fourth-year (hons) undergraduate project for the module **Mobile Application Development 3.**
The module is taught to undergraduate students at [GMIT](http://www.gmit.ie/) in the Department of Computer Science and Applied Physics for the course [B.S.c. (Hons) in Software Developement.](https://www.gmit.ie/software-development/bachelor-science-honours-software-development)
The lecturer is Damien Costello.

## Project Guidelines:
> Create a Windows 10 UWP App.  The application should incorporate the following elements: 
>* A responsive UI across the Windows 10 devices.  There are some available for testing and this includes the IoT core, mobile devices, tablet and PC.  This includes Visual State Management and using available SDKs for individual device types. 
>* A UI that has been well designed and is fit for purpose.  User Experience should be carefully considered while developing the application.  The User Experience should be consistent across devices. 
>* Mobile services for data storage and retrieval. The cloud service does not have to be written in C# to be able to interact with a UWP.  The preferred cloud to use is Azure. 
>* Use of the MVVM design pattern in the development approach. 

## Project Overview:
For this project I developed an application that can be beneficial for individuals that partake in fishing. Essentially the application displays the current weather and tide levels based on the user's current location. The user can also view the weather forecast & tide forecast for any county in Ireland. The basic idea behind the application is to allow the user to pick the optimal time to go fishing, though the application can also be useful for other purposes such as simply checking the weather forecast or checking when the tide level is high enough to set sail etc.

The key component of this application is utilizing the [OpenWeatherMap](https://openweathermap.org/) API & [WorldTides](https://www.worldtides.info/home) API for retrieving weather data & tidal data respectively. The data retrieved from both of these  APIs is delivered in the json format and sorted into their respective class objects everytime a call is made to retrieve the data which is afterwards displayed to the user.

As part of this project I also created my own API which handles the data storage and retrieval aspect of this project using the standard MVC pattern. The API can be viewed in the following [repository](https://github.com/RicardsGraudins/Weather-Fisher-API).

## What is MVVM:
Model–view–viewmodel (MVVM) is a software architectural pattern.
![MVVM Image](https://upload.wikimedia.org/wikipedia/commons/8/87/MVVMPattern.png)

**Model:**  Think of the models as the business objects.  A Model should know nothing about the user experience - specifically the View or how it is implemented using a ViewModel.  The Model only interacts with the system and data services. 

**ViewModel:**  The ViewModel is where you encapsulate any code or data that your UX or View will need.  It is important that the ViewModel/s only know about and encapsulate the Model/s but shouldn’t be responsible for any buisness logic or buisness constraints – that should all be in the model/s. On the other side, the ViewModel/s should know nothing about the specifics of the Views and UX that use it.

**View:**  This is where you create the user experience – in Windows apps you do this declaratively with XAML markup language and design tools.  The View uses properties and actions on the ViewModel to get the job done.

## References
* [MVVM](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel)  
* [MVVM Summary](https://blogs.msdn.microsoft.com/johnshews_blog/2015/09/09/a-minimal-mvvm-uwp-app/)  
* [OpenWeatherMap API](https://openweathermap.org/current)
* [WorldTides API](https://www.worldtides.info/apidocs)

Code references can be found throughout the code in the `UWP-Project-3` folder.
