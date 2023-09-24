# ChattingApp

## Introduction
This platform is designed to connect people, facilitate communication, and create a vibrant online community. In this document, we will outline the key features of our social media website, giving you a comprehensive understanding of the capabilities and functionalities available to users and administrators.

## Features
- User authentication and authorization.
- User profiles and photo uploading.
- Real-time text-based chat.
- Notification system for new messages.
- Add User to Favorites
- Filter Users
- Admin role and photo management 

## Technologies Used
- **Frontend:**
  - HTML5, CSS3
  - Typescript
  - Angular for UI components
  - Bootstrap for styling

- **Backend:**
  - ASP .NET Core for server environment
  - WebSocket for real-time communication
  - PostgreSQL for database
  - JSON Web Tokens (JWT) for authentication

## Setup Instructions

To get our social media website up and running locally or on your own server, follow these setup instructions:

### Prerequisites

Before you begin, make sure you have the following software and tools installed:

- **Frontend:**
  - Node.js and npm (Node Package Manager)
  - Angular CLI (Command Line Interface)

- **Backend:**
  - ASP .NET Core
  - PostgreSQL database

### Installation

1. **Clone the Repository:**
   ```shell
   git clone https://github.com/AbdelrahmanRF/ChattingApp
   ```

2. **Frontend Setup:**

   - Navigate to the frontend directory:
     ```shell
     cd client
     ```

   - Install dependencies:
     ```shell
     npm install
     ```

   - Start the Angular development server:
     ```shell
     ng serve
     ```

   The frontend should now be accessible at `http://localhost:4200`.

3. **Backend Setup:**

   - Navigate to the backend directory:
     ```shell
     cd API
     ```

   - Install ASP .NET Core dependencies using your preferred package manager (e.g., NuGet).

   - Configure your PostgreSQL database connection in the backend settings.

   - Start the backend server. You can use Visual Studio, Visual Studio Code, or the .NET CLI.

   The backend should now be accessible at `http://localhost:5000`.

### Configuration

1. **Environment Variables:**

   - Configure any necessary environment variables for your application, such as API keys, secret keys, and database connection strings. Refer to the respective documentation for guidance.

2. **Database Initialization:**

   - Set up and initialize your PostgreSQL database with the required schema and tables. You can use database migration tools or scripts for this purpose.

### Running the Application

With both the frontend and backend set up, you can now access your social media website by visiting the specified URL in your browser. Users can register, log in, and start using the various features offered by the platform.



