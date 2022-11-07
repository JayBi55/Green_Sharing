# Morgan Stanley Hackathon novembre 2022
## Project: Earth Day Canada
## Team 11: Green Sharing
* Abdoul Sadikou <br />  			
* Bassel Assi  <br />
* Jeanne Audrey Mboua Bitoungui <br />
* Myyank Shukla <br />
* Marguerite Mireille Camara <br />
* Van Nam Vu <br />

**Mentor** : Marcel Tawé  <br />

## Project artifact
* Morgan Stanley Project : https://codetogive.bemyapp.com/#/projects/636478762b5a55720fb83e7a <br />
* Front-end Green Sharing : https://green-sharing.netlify.app/ <br />
* Back-end Green Sharing : https://greensharingapi.azurewebsites.net/swagger/index.html <br />
* MCD-SAX-ML models Diagrams : https://app.diagrams.net/#G1J_-efr0K0X03nbX8w-cENkyHh6ZV7eTP <br />
* Figma design : https://www.figma.com/file/TqOf0pTMOZGpH9VtUyGTqs/CGT-T11?node-id=0%3A1 <br />

##  The Problem: 

Earth Day expressed a need for application that could help :
* Organize multi-parties’ interactions
* Optimize (by reducing waste)  the gleaning process in Canada


## The solution: Green Sharing
* Personalization of the user experience 


* Interactive map 


* Gamification with the Review/Score  feature


* Ability to prioritised  event (high/urgent, mid, low)
Carpooling capabilities between gleaners  

* Ludification of the platform  with a gallery page 

* OAuth Support (google/facebook)  (already in the DB) 

* Offline mode enabled


* Automatic matching on Gleaning Events/Gleaner/BankFood using ML model  



## Implementation:
**1.  FrontEnd** <br /> 
Read the readMe_frontE in the repository **front-end** for a better understanding of this part  <br /> 

**2.  BackEnd**  <br /> 
Resources and requirements :
* .NET 5.0 <br />
* .ASPNetCore <br />
* .EntityFrameWorkCore <br />
* MSSQL <br />
* RestAPI <br />

**3.  Hosting**  <br /> 
* Nestify - for front-end <br />
* Azure Cloud - for back-end <br />



## Other folders:

* In **Green_pics** we have all the pictures taken during the project.
* **Delivery:** All the documents that needs to be consulted by the client











## Green_Sharing

EntityFrameworkCore\Add-Migration InitialCreate -Context GreenSharingContext -Project  GreenSharing.API -StartupProject GreenSharing.API -Verbose
