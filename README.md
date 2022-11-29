<br />
<p align="center">

  <h3 align="center">Checkingx</h3>

  <p align="center">
    Project checking application targeted for design offices collaborating in teams with many projects at same time.
    <br />
  </p>
</p>


<!-- TABLE OF CONTENTS -->

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#about-the-project">About The Project</a></li>
	<li><a href="#built-with">Built With</a></li>
	<li><a href="#features">Features</a></li>
	<li><a href="#possible-features">Possible Features</a></li>
	<li><a href="#screenshots">Screenshots</a></li>
  </ol>
</details>


<!-- ABOUT THE PROJECT -->

## About The Project

The main goal of the application is to improve and facilitate the process of checking projects.

My idea of checking process is composed with 2 phases:
1. Checking - At this point, the user goes through all the checkpoints and mark them as OK, Incorrect or N/A, optionally with attached screenshot. 
2. Review - When checking phase is finished, then Review phase could be started. Here another user checks all items marked as "incorrect" and correct them if required.

### Built With

- Blazor and C#
- Entity Framework
- SQLite
- Newtonsoft.Json
- MudBlazor (UI components)

## Features

- All projects and check items are stored in the database
- Checking items are grouped by categories
- Each checking item has its own history and priority
- Each checking item has its unique order number. This solution helps list checking items during checking process in the expected order.
- Each checking item can be updated or removed.
- Checker can attach screenshots of the errors and inculde description.
- Uploaded screenshots are stored in database.
- Review progress is showed in the main table.
- Filtering of the project or check items.
- Data pagination.

## Possible features

- Major languages
- Frameworks
- Technologies used

## Screenshots

