# AskMe

[<img src="https://i.ytimg.com/vi/Qw-R3leMJxk/maxresdefault.jpg" width="50%">](https://www.youtube.com/watch?v=Qw-R3leMJxk)

#### Web Application description
<p>This web application is similar to StackOverflow, i.e. intended for asking questions. Users have the opportunity to ask questions and get answers to those questions, and also other functionalities that it offers are searching through questions, upVote and downVote on questions and answers, and also validation.</p>

#### How to start the web application
<ul><li>First we start the database through Docker with the following command<br>
<code>docker run -e "ACCEPT_EULA=1" -e "MSSQL_SA_PASSWORD=Strong@Password" -e "MSSQL_PID=Developer" -e "MSSQL_USER=SA" -p 1433:1433 -d --name=sql mcr.microsoft.com/azure-sql-edge</code>
<p>This way Microsoft SQL Server is started in the background using the Docker</p>
</ul></li>
<img width="1396" alt="docker" src="https://user-images.githubusercontent.com/77225921/190634749-07d796ed-7c63-4553-8e86-7a948de53758.png">

<ul><li>Next with Azure Data Studio I will connect to the database to see if I have anything created</ul></li>
<img width="1640" alt="Screenshot 2022-09-16 at 14 40 00" src="https://user-images.githubusercontent.com/77225921/190641221-79f8b029-11dc-4615-8161-980b26f8d2f0.png">
<img width="1641" alt="Screenshot 2022-09-16 at 14 41 35" src="https://user-images.githubusercontent.com/77225921/190641240-edc45f01-9b8f-4455-9f42-dab98a0edc7b.png">

<ul><li>In the project I have previosly defined a <b>ConnectionString</b> which contains all the parameters needed for the application to connect a database server</ul></li>
<img width="1723" alt="Screenshot 2022-09-16 at 15 12 10" src="https://user-images.githubusercontent.com/77225921/190647021-761b9202-137f-4c40-8a4d-4fe4f8dd6420.png">

<ul><li>Next in the <b>NuGet Package Manager Console</b> of the project I run the command <code>update-database</code> and then I go back to Azure Data Studio to see if there are created tables(which are defined as Models in the project) in the database AskMe</ul></li>
<img width="1723" alt="Screenshot 2022-09-16 at 15 26 51" src="https://user-images.githubusercontent.com/77225921/190653856-7b70553b-f756-4df5-baca-308200820bea.png">
<p>Previosly I have had run two migrations(first was to add table Question, and second was to add table Answer and relation with Question table) as you can see in the picture below. So we see that there is created a database <b>AskMe</b> and the tables <b>Question</b> and <b>Answer</b> in that database</p>
<img width="1641" alt="Screenshot 2022-09-16 at 15 29 12" src="https://user-images.githubusercontent.com/77225921/190653884-b80c84d8-ff60-416a-b8ee-a8c15b44c1e6.png">

#### Run the web application AskMe
<i>You can check my <a href="https://www.youtube.com/watch?v=Qw-R3leMJxk&t=3s">demo</a> to see how my web application works</i>
