# Cybersecurity Awareness Chatbot

A C# WPF chatbot application that helps users learn about cybersecurity topics such as phishing, password safety, malware protection, and safe browsing.

---

## Student Information

- Name: Ayakha Twalo  
- Student Number: ST10490430  
- Module: Programming  
- Module Code: PROG6221  

---

## Project Overview

The Cybersecurity Awareness Chatbot is a desktop application built using C# and WPF in Visual Studio 2022. The chatbot interacts with users through a graphical user interface and provides cybersecurity awareness tips using keyword recognition, sentiment detection, memory features, and personalised responses.

The application was developed as part of the PROG6221 Programming module.

---

## Features Implemented in Part 2

### GUI Features
- WPF graphical user interface
- User input textbox
- Chat display area
- Send button for interaction

### Cybersecurity Features
- Password safety tips
- Phishing awareness guidance
- Malware protection advice
- Safe browsing recommendations

### Advanced Features
- Voice greeting using WAV audio
- Personalised greeting with user name
- Sentiment detection:
  - Worried
  - Curious
  - Frustrated
  - Happy
- Memory system:
  - Stores user name
  - Stores favourite cybersecurity topic
- Follow-up responses such as:
  - “Tell me more”
  - “Explain further”
- Randomised chatbot responses for more natural interaction

### Programming Concepts Used
- Object-Oriented Programming (OOP)
- Classes and methods
- Dictionaries and lists
- Exception handling
- File handling
- Event-driven programming in WPF

---

## Technologies Used

- C#
- WPF (Windows Presentation Foundation)
- .NET 8.0
- Visual Studio 2022

---

## Prerequisites

Before running the project, make sure you have:

- Windows Operating System
- Visual Studio 2022
- .NET 8.0 SDK installed

---

## How to Clone and Run the Project

### Step 1: Clone the Repository

Open GitHub Desktop or Git Bash and run:

https://github.com/ayakha-twalo/PROG6221_CyberSecurityBotProject_POE


### Step 2: Open the Project

- Open Visual Studio 2022
- Click **Open a Project or Solution**
- Select the `.sln` file

### Step 3: Restore Dependencies

Visual Studio should automatically restore packages.

If needed:
- Go to **Tools → NuGet Package Manager → Restore Packages**

### Step 4: Build the Project

- Press `Ctrl + Shift + B`
- Ensure the build succeeds without errors

### Step 5: Run the Application

- Press `F5`
or
- Click the green **Start** button

The chatbot window should open successfully.

---

## Audio File Setup

For the voice greeting to work correctly:

- Place the `greeting.wav` file inside the project directory
- Ensure the file is included in the project in Visual Studio
- Set the file properties to:
  - **Build Action:** Content
  - **Copy to Output Directory:** Copy if newer

---

## Application Screenshots

### Main GUI


![GitHub Actions](screenshots/gui.png)

---

## GitHub Actions Build Status

![GitHub Actions](screenshots/github-actions.png)

---

## YouTube Presentation Video

https://youtu.be/VPbCCZRxPAM


---

## Project Timeline and Milestones

- 28 March 2026: Created project structure 
- 2 April 2026: Added personalised greeting 
- 3 April 2026: Implemented keyword detection 
- 5 April 2026: Added validation and default responses 
- 6 April 2026: Improved interface formatting 
- 7 April 2026: Added voice greeting 
- 10 April 2026: Completed Part 1 testing 
- 24 May 2026: Upgraded to WPF 
- 25 May 2026: Added GUI, memory, and sentiment detection 

---

## References

- Microsoft Learn. (2025). C# Documentation  
  https://learn.microsoft.com/

- W3Schools. (2025). C# Tutorial  
  https://www.w3schools.com/cs/

---

## Author

Ayakha Twalo  
ST10490430
