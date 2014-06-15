timelog
=======

AngularJS .NET WebAPI timelogs

Steps to Execute project.

Server Side – Web API

1. Start Visual Studio 2013 Web Express Edition

2. Open the OrgBT solution file from C:\Workspace\WebApplication1\Karunamoorthy\TimeLog 

folder.

3. Press F5 to run the project in debug mode

4. It should the default web api template page

Client Side

1. Type http://localhost:60251/PresentationLayer/app/index.html in the browser address bar.

Walk through the app

1. You will the login page.

2. First we will login as Developer. Enter “Karuna” as username and “Test1234” as password.

3. The app will display developer’s time log entry page, with default to first project, and first task

4. Select a project/task 

5. Click on the Start Date text box, the app will pop up bootstrap date picker

6. Pick start date

7. Repeat the 5 and 6 for end date selection

8. Enter actual effort and click on Log Time.

9. The app will show a confirmation message. Click on Logout.

10. The app will show a confirmation message and take you to login page.

11. Now, as a client login with “Sebastian/Test1234”

12. The app will show time sheets page with a filter by projects and the selected project’s time 

sheet.

E2E Testing - Protractor

1. Start Webdriver manager

2. Start protractor with test/e2e/conf.js

3. The E2E test will login as developer first and then client and will logout.
