# 1. Introduction

## 1.1 Purpose 
The purpose of this SRS is to fully explain the requirements, constraints, and considerations of the software application “Vigilance”. The SRS will lastly document the future possibilities of the program and will pave a way for future builds/implementation of more features. The intent of this SRS is to provide enough information for an initial implementation of the application to be used as a prototype or early release of the program. The final specifications of the program will be verified following the initial release and will be tailored based on user feedback of features and problems that were encountered while running the program. This SRS and the information contained herein is for other developers. Developers may utilize the ideas listed within and apply their own logic of execution, trouble shooting, and functionality to deliver a working product with the specified requirements herein. This document is not open for distribution external to the Microsoft Software and Systems Course unless permission is granted by the author or co-authors of this SRS. 
## 1.2 Scope
“Vigilance” is aptly named because it will provide people, families, and business owners the ability to access crime information that was previously compartmentalized within the ranks of law enforcement agencies. Based upon the end user’s specific location of interest, icons will be populated on the map each of which representing an individual crime that has taken place. Once an icon is interacted with by a user, a report will be populated detailing the specifics of the crime that was committed. Vigilance will be comprised of multiple integral applications including a web portal, a Microsoft SQL Database(MSSQL), and a Universal Windows Application (UWP).

The UWP will be the “face” of what every user interacts with and will provide the method of initial implementation for the program with future implementation including Android and IOS versions for mobile applications. The UWP will leverage software designed by ArcGIS and ERNIE to populate a map that includes street names. The map will have a map overlay known as a layer. The layer is georeferencing information hosted on the ArcGIS web portal. The MSSQL will be the center point for the information that will be populated using the map layer in addition too also being the container for all information associated with each individual crime. The MSSQL will be updated quarterly. All crime information for crimes that have taken place one year or greater will not be populated. This information will instead by transferred to a separate table to create a historical database to allow for statistical analysis. 

## 1.3 Definitions 
//TODO
## 1.4 References	
//TODO
## 1.5 Overview 	
The remainder of this document include two chapters and appendixes.  The second chapter discusses the program’s finite details including capabilities, shortfalls, future implementation, and requirements of the program. Chapter 3 discusses the overarching premise and implementation. The organization throughout the entirety of this document explains each sub-point from highest echelon of task subsequently followed by sub-tasks and an explanation of how this sub-task contributes to the overarching task. 
 
# 2 Overall Description

## 2.1 Product Prospective 
The program will have three main features or interfaces necessary to ensure the proper function and employment of the program. The first feature of the application will be to allow a user to access a map of their local area. The second feature will be a web portal hosted by ArcGIS servers to allow developers to have easy access of up to date georeferencing data and allow the developers to create map layers. The third feature will be the database that maintains all the crime records for a specific area. The graphical user interface (GUI) will display the map by accessing the web portal hosted by ArcGIS. The map will be the most predominate feature and will be the main tool users will leverage to get information. The map will be populated by icons that correlate to their respective criminal charge and a crime report. Users will select an icon and the program will query the data that corresponds to the crime represented by the specific icon the user chose from the database and that information will be presented in a separate view window on the same page as the map. The database will hold all information related to each crime. The database information will be loaded to the ArcGIS web portal to keep web layers updated with appropriate geocoords of crimes so that the program can populate all icons. 

The target device market will be primarily focused on windows devices. Future implementation will include release on IOS and Android platforms. With mobile platforms being the centerpiece of devices, memory management in conjunction with multithreaded operations will be highly considered to ensure a product that is easily processed on the variety of devices.  
## 2.3 Product Functions
The program is driven by user interaction in different forms. To best explain the product, an example of a user’s a full cycle of interactions with the program using the various functionality aspects will be used. Upon a user selecting the program, a load screen will be displayed. The loading screen will include a loading bar and a brief description of how to navigate the application. Once the application has loaded a map will displayed of an area. The map will be a map that does not show imagery or topography and only displays streets with their names. In addition to the street names, small icons will be displayed. Each icon is representative of a location where a crime took place. Each icon will be color coded with a small image relating to the type of crime each specific icon represents. The user will be able to zoom in and out of the map as well as scroll the map to display an area of interest. Once the user finds the area of interest and icons are displayed, the user will click on an icon. Once the user clicks on the icon, a small message will populate with all of information that pertains to the specific crime the icon pertains to. A sidebar containing the tools a user be select that affect the program output will be displayed next to the map viewport. Within this tool bar, a user can refine the icons populated by using a filter option. Each type of crime will have an individual selection box that the user will select and a search button to initiate a repopulation of icons on the map. Below the filter option will be a button that changes the map screen to a statistics page that displays the number of occurrences of each type of crime. A small legend will be located below the toolbar section containing each icon and a small description next to it. Once a user has finished, the application will be closed and immediately terminated by the system. An overview of the previous sequence of events is as follows:
-Display loading screen
-Display street map
-Display icons on the map
-Present message box once icon is clicked
-Display a toolbar 
-Display a filter operation
-Display a legend
-Display a statistics page
-Close program and terminate background operation

## 2.4 User Characteristics 
The intended audiences of the program are split amongst intended purposes of the program. To further elaborate on this idea, the program is intended for research purposes. The reasoning for the research can vary greatly and as such the persons conducting the research is also impossible to pinpoint. Below are some of the intended purposes of this program. 

-High school/College Research. 
Students in high school and college are often assigned projects or essays where crime statistics, and crime information is knowledge that is necessary for the completion of the assignment. As such, Vigilance would offer a platform for students to find information that is relevant to the assignment and from within their locale. The program will offer users the ability to display statistical information. All the information contained and displayed within the program is acquired from law enforcement agencies and is reasonably accurate and reliable which would suffice for reputable source guidance. 

-Buying/Renting property
Everyday thousands of people move to different areas or within the same city. These moves can be nerve racking and stressful. One of the main concerns while moving is generally the safety of the area surrounding the new home. This application would present an easily accessible platform to provide invaluable information to people in a stressful situation. 
## 2.4 Constraints
//TODO
## 2.5 Assumptions and dependencies
The dependencies of this application stem from the reliance on information for law enforcement agencies and the availability of mapping software used within the application. The critical shortfall of this application is the reliance on open/public access to law enforcement arrest information. The data contained within MSSQL is sourced from law enforcement agencies that publish this information to the public. This relationship presents a potentially problematic set of situations. First, if the law enforcement agencies stop publishing the data, then the database would not be able to be updated. Additionally, certain areas may not make arrest information publicly accessible. Based on this possibility, the areas with information may be limited. The reliance of the application with mapping software stems from the license agreement with ArcGIS. The current planned implementation would allow for free use of ArcGIS servers and mapping. If ArcGIS decides to change this offer, the mapping software would either have to change or the application would have to accrue income to pay for the continuous use of ArcGIS servers.   
## 2.6 Apportioning of Requirements
Too fully implement all the desired features may be unrealistic for the current deadline of 24 May 2018. Listed Below are the requirements that may be delayed until further releases.
-Toolbar feature with statistical information
-Detailed icons (early implementation may be simply color coded in lieu of graphics)
-Loading screen
# 3 Specific Requirements 
## 3.1 External Interfaces
This section describes each of the individual interfaces that are necessary for the application to function properly and provides the functionality. Each interface is divided by the task it handles. 
### 3.1.1 User Interfaces
The user interface is comprised of a graphical page that presents the map, toolbar, and a blank crime description window. The user will zoom in and scroll the map accordingly to find their desired area. When the map is centralized on the location the user is interested in, icons will populate across the viewport of the map. If the user wants to refine the results and the icons that are printed, the filter option located in the toolbar will be used. The map will take up the entirety of the viewport window. The message box is located below the viewport for the map. The text box will contain all information the crime report contains. The toolbox which extends from the top of the screen to bottom will contain buttons to select or deselect icons to be displayed. Below the search button that initializes the filter, is the legend that displays the icon’s explanation. 
### 3.1.2 Hardware Interface
The program is not reliant on one specific hardware to conduct its operations. In future implementation from the initial release, an interface may need to be included to account for accessing a user’s GPS to automatically center the map on their location. 
### 3.1.3 Software Interface 
The key functionality of producing a report of information that corresponds to a specific crime will involve an interface to communicate between the application itself, the database, and the ArcGIS servers. When a user is navigating through the map and an icon is selected, a connection must be made to the server to identify the Crime ID which is used within the Database as a primary key to access information. The server connection and application only require a read type of access to the database as neither of these aspects will be creating new data that needs to be contained within the database.
### 3.1.4 Communications Interface 
## 3.2 Functions
### 3.2.1
ID:FR1
Title: Download Application 
DESC: The application shall be packaged for download by users using windows devices. 
RAT: Enables the use of the application.
DEP: None.

### 3.2.2
ID:FR2
Title: Present Map 
DESC: The application shall automatically load the map in the viewport of the application. 
RAT: Loads the map and presents it to the user. Sets a generalized starting point for the map to allow users a familiar look across separate uses of the application.
DEP: ArcGIS Web Server.

### 3.2.3
ID:FR3
Title: Center Map 
DESC: The application shall automatically center the map. 
RAT: Sets a generalized starting point for the map to allow users a familiar look across separate uses of the application.
DEP: None.

### 3.2.4
ID:FR4
Title: Populate Map 
DESC: The application shall populate icons on the map. 
RAT: After the map is loaded, icons will immediately be loaded onto the map. As previously mentioned, the Icons represent different instances of crimes. The icons will not populate if the map zoomed out further than a 2-mile range in any direction. 
DEP: ArcGIS Web Server, MSSQL.

### 3.2.5
ID:FR5
Title: Populate Map Details  
DESC: The application shall populate streets and street names on the map. 
RAT: After the map is loaded, the names of streets and their graphical representation will populate on the map. 
DEP: ArcGIS Web Server.

### 3.2.6
ID:FR6
Title: Navigate Map  
DESC: The map within the viewport must be able to be moved in different cardinal directions.
RAT: A user will need the ability to move the map to allow for new areas to be presented.
DEP: ArcGIS Web Server.

### 3.2.7
ID:FR7
Title: Magnify Map  
DESC: The map must support a zoom in and zoom out function.
RAT: A user will need the ability to zoom in and out of a map to show different areas.
DEP: ArcGIS Web Server.

### 3.2.8
ID:FR8
Title: Select Icon  
DESC: The program shall allow users to select an icon by touching the icon on the map
RAT: This is the event that subsequently leads to the crime report being generated and displayed to the user. 
DEP: ArcGIS Web Server, MSSQL.

### 3.2.9
ID:FR9
Title: Display Toolbar  
DESC: The main page will have a toolbar that presents different options to the user.
RAT: The toolbar will offer the ability to implement functionality that is not necessary for the application to do every task but will further refine the results of those tasks.
DEP: None.

### 3.2.10
ID:FR10
Title: Display Legend 
DESC: The application shall have a legend containing each icon and a brief description of the type of crime each icon relates to. 
RAT: The legend will allow users a quick reference guide to what each symbol means so they do not have to guess. 
DEP: None.

### 3.2.11
ID:FR11
Title: Display Filtering Options  
DESC: Within the afore mentioned toolbar will be options to filter the icons populated on the map.
RAT: Not all information that is contained within the database may not be of importance for the user. The filter option will allow users to select what information to show. 
DEP: None.

### 3.2.12
ID:FR12
Title: User Can Select Filter Options 
DESC: The application shall allow users to select which filter options they desire. 
RAT: After the map is loaded, icons will immediately be loaded onto the map. As previously mentioned, the Icons represent different instances of crimes. The icons will not populate if the map zoomed out further than a 2-mile range in any direction. 
DEP: ArcGIS Web Server, MSSQL.

### 3.2.13
ID:FR13
Title: Clear Filter Selections 
DESC: The application shall allow users to deselect filter options. 
RAT: Allows users to deselect any filter options that have previously been selected. 
DEP: None.

### 3.2.14
ID:FR14
Title: Create crime report   
DESC: Information will be presented to users in a single format.
RAT: Formats information for each crime into a consistent format. 
DEP: None.

### 3.2.15
ID:PR15
Title: Clear crime report results pane  
DESC: The program shall allow the user to clear the results pane that displays the crime report.  
RAT: To prevent users from having to look at information that may or may not be relevant while using the app after selecting an icon.  Results will not automatically be cleared unless another icon is selected. 
DEP: None.

### 3.2.16
ID:FR16
Title: Display Crime Report  
DESC: The crime report will be presented to the user. 
RAT: Implements the ability to view the information that correlates to the icon that was selected.  
DEP: None.

###3.2.17
ID:FR17
Title: Format/Display GUI  
DESC: The program shall be operated from within a GUI
RAT: The map and toolbar are not capable of being displayed without some form of GUI. 
DEP: None.

## 3.3 Performance Requirements
### 3.3.1
ID:PR1
Title: Dispose of previous crime report/icon   
DESC: The program shall dispose of any information stored within memory once the user clears the crime report or selects another icon.
RAT: Ensures the application will have quick response time and limit the possibility of a system out of memory exception.
DEP: None.

### 3.3.2
ID:PR2
Title: Exit program 
DESC: The program will close and dispose of any objects still retained in memory.
RAT: Provides a safety net to prevent the application’s utilization of memory from persisting after the application is no longer being used.
DEP: ArcGIS Web Server.
 
## 3.4 Logical Database Requirements
### 3.4.1
ID:LR1
Title: Filter results based on specified values    
DESC: Implements the filter option of the toolbar based on user specified values.
RAT: Not all information that is contained within the database may not be of importance for the user. The filter option will allow users to select what information to show. 
DEP: MSSQL.

### 3.4.2
ID:LR2
Title: Query crime information  
DESC: The program shall query the database of crime results 
RAT: Gathers the information needed for each crime report. 
DEP: MSSQL
# 3.5 Design Requirements 
       ## 3.5.1 Standards Compliance 
# 3.6 Software System Attributes
## 3.6.1 Reliability
## 3.6.2 Availability
## 3.6.3 Security
## 3.6.4 Maintainability
## 3.6.5 Portability 
# 3.7 Organizing the specific requirements
## 3.7.1 System Mode 
## 3.7.2 User Class
## 3.7.3 Objects
## 3.7.4 Feature
## 3.7.5 Stimulus
## 3.7.6 Response 
## 3.7.7 Functional Hierarchy
## 3.7.8 Additional Comments  
