AngularJS .NET WebAPI timelogs
===============================

##Steps to Execute project.

###Server Side – Web API

1. Start Visual Studio 2013 Web Express Edition

2. Open the OrgBT solution file from <path-to-directory>\TimeLog folder.

3. Press F5 to run the project in debug mode

4. It should the default web api template page

###Client Side

1. Type http://localhost:60251/PresentationLayer/app/index.html in the browser address bar.

##Walk through the app

+ You will see login page.

![Login screen](/screenshots/login.jpg)

+ First we will login as Developer. Enter “Karuna” as username and “Test1234” as password.

+ The app will display developer’s time log entry page, with default to first project, and first task

![Developer Entry page](/screenshots/devlog1.jpg)

+ Select a project/task 

+ Click on the Start Date text box, the app will pop up bootstrap date picker.

![Developer Entry page](/screenshots/devlog2.jpg)

+ Pick start date

+ Repeat the 5 and 6 for end date selection

+ Enter actual effort and click on Log Time.

+ The app will show a confirmation message. Click on Logout.

+ The app will show a confirmation message and take you to login page.

+ Now, as a client login with “Sebastian/Test1234”

+ The app will show time sheets page with a filter by projects and the selected project’s time sheet.

![Developer Entry page](/screenshots/report.jpg)

##E2E Testing - Protractor

1. Start Webdriver manager

2. Start protractor with test/e2e/conf.js

3. The E2E test will login as developer first and then client and will logout.
