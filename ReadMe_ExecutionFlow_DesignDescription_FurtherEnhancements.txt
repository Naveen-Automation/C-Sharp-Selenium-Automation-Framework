**************************************************************************
To Do Items (Refactoring)
**************************************************************************
1. Clear browing data 
2. 




. Stopwatch implementation to understand the performanc issue 
.Generating a unique number using  (Guid id = Guid.NewGuid()). Guid is a static class which returns Guid type.








**************************************************************************
Execution Flow Information
**************************************************************************
0. StartUp.cs & ExtentReportingHooks.cs has all the setup & cleanup methods. 

1. Used C-Sharp reflections to create Page Instance of POM at run time. This helps to reduce the number of steps in step definition file. POMHelpers class has a static method that is 	responsible for creating a page object at run time and it accepts page name as parameter which is passed from feature file. Implementation is present under POMHelpers.cs.
	
2. Every page class has 3 abstract methods implementation.(1. To check weather page is loaded or not   2. To fill the complete form or sections of the form     3. To click on link/button    to navigate to next page)
   All these abstract methods are defined in BasePage.cs.

3. All webelements are initialized via page factory in BasePage.cs 

4. All global variables are maintenaned under GlobalVariables.cs.

5. All constants are maintained under GlobalConstants.cs.

6. AppSettings.json used for all the configuration settings.

7. Webdriver instantiation is done in the ChromeDriver.cs which inherits BaseBrowser.cs.

8. Screen shots & HTML report are saved in bin/TestResults.

9. ParentPOMClass.cs is implemented to store common application specific webelements to avoid duplication in individual POM classes.

10. Feature files are presnt in 'FeatureFiles' folder.

11. Step definitions are present in 'StepDefinitions' Folder.

12. Page class files of POM are present under 'POMClassFiles' folder.

13. Logging is done using Log4Net but hasn't been switched on as it has not been tested.

14. Execution report of the above 2 scenarios is placed under 'ExecutionReport' folder along with screen shots. Both the scenarios were executed under a minute.




**************************************************************************
Framework/Solution Details:
**************************************************************************
Tooling & Programing Language:
	1. Visual Studio 2019
	2. DontNet Core
	3. C Sharp
	4. Specflow
	5. BDD Framework
	6. NUnit Unit Test Framework
	7. GIT
	8. XPath
	9. Extent Reporting
	10. Log4Net 

Portable & Configurable:
	1. All the configurations are driven from AppSettings.json file. For example: Selecting browser type, browser timeout, User credentials etc.
	2. No hard coded paths used in Framework.

Multi-Browser Support:
	1. Currently implementation exists for Chrome browser but kept provision for other browsers too.

Headless Mode Support:
	Headless mode enabled for Chrome and can be enabled for all the headless mode supported browsers.
	
Design Patterns:
	1. Page Object Model:
	Used Selenium's inbuilt pagefactory implementation to mimic Page Object Model design pattern.
	Easy, simple & clean.

Reporting:
	1. Used readily available Extent Report. In the interest of time configured for basic reporting.
	2. Test Results Folder path: '/bin/TestResults'.

Synchronization:
	Added multi level synchronization to make test execution smooth & robust. One at browser level and the other at webelements level.

Screen Shots:
	Screen shots are placed inside a new folder each time. Folder is created at run time with the help of time stamp to keep it unique and to avoid over ridding earlier ones.

Loging:
	Implementaed Log4Net logging and pending with testing, hence turned off the logs for this excersise.

Test Data:
	Currently solution uses specflow tables to drive test data.

Exception Handling:
	In the intrest of time Added try catch blocks in very few places but it can be improvised.

Coding Standards:
	1. Used industry best practices
	2. Commented where ever possible in the intrest of time and added dummy comments.
	
Readability:
	Added sections for better readability.
	Used meaningful names for objects and methods for quicker understanding.
	Used proper naming conventions to identify the Locator/Webelement types.

Code Maintenance:
	Developed reusable wrapper methods for better maintenance and consistancy of code.

XPath functions & Axes:
	Used where ever applicable. Used methods and axes.
 
JenkinsSupport:
	Created basic jenkinsfile. Same can be reffered in jenkins pipeline jobs in jenkins to trigger scripts.





**************************************************************************
I can improvise this Framework by adding :
**************************************************************************
1. Declarative Jenkins jobs via jenkinsfile.

2. Cloud platforms support like Sauce labs & BrowserStack for consistant test environment and faster execution.

3. Dependency Injection concepts.

4. Comprehensive Extent report Open screen shots directly from Extent Report).

5. Full length screen shots can be implemented when the page is long with scroll bar.

6. Data driven mechanism using 'Scenario Outline'.

7. Parallization techniques to reduce execution time.

8. Jira Integration.

9. Email notifications.

10. Debugging mode using element highlighter via JavaScript executor.






**************************************************************************
How to Launch Jenkins Server :
**************************************************************************
1. Go to the path where jenkins.war is present.  "C:\NAVEEN\Jenkins"
2. Enter cmd in the address bar
3. Enter command "java -jar jenkins.war"
4. Open Browser and enter "http://localhost:8080"
5. Enter User Name : Veer3586    
6. Enter Password Veer@3586



**************************************************************************
How to Install Jenkins Server :
**************************************************************************


