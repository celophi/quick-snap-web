# QuickSnap - Web & API

This repository contains the server-side component of the [Quick Snap App](https://github.com/celophi/quick-snap-app), designed to handle account and picture information for the application.

## Overview

The server manages account and picture data through a shared cache, which is cleared upon server shutdown. It acts as the backend API for the Quick Snap App, providing all necessary endpoints for the client-side to communicate with.

### Key Features
- **Shared Cache:** All account and image data is stored temporarily in a shared in-memory cache.
- **Ephemeral Data:** The cache is cleared upon server shutdown, meaning no data persistence is maintained between server restarts.
- **Multiple Projects:** The solution includes both API and Web projects that need to be run simultaneously.

## Getting Started

To set up and run this project, follow these steps:

### Prerequisites
- Ensure both the **API** and **Web** projects are running.
- Use [ngrok](https://ngrok.com/) or a similar service to tunnel and redirect traffic to the API server endpoint.

### Running the Application
1. Clone this repository.
    ```bash
    git clone https://github.com/YOUR-USERNAME/quick-snap-server.git
    ```
2. Run both the **API** and **Web** projects within the solution:
    - **API Project**: This serves as the backend for managing the account and picture data.
    - **Web Project**: This serves the frontend of the application.
  
3. Set up your API server endpoint with **ngrok** or a similar tool:
    ```bash
    ngrok http <PORT_OF_API_SERVER>
    ```
4. Configure the **API Endpoint** within the client-side [Quick Snap App](https://github.com/celophi/quick-snap-app) settings to point to the ngrok URL (e.g., `https://<ngrok-subdomain>.ngrok.io`).

## Notes
- **Cache Limitations**: Since data is stored in-memory, the server will lose all account and picture data when it shuts down. You can configure a persistent data store if needed.
- **API and Web Dependencies**: Make sure both projects are running and correctly configured to communicate with each other.

## License

This project is licensed under the MIT License.