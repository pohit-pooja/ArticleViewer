# Article Viewer Application

This project is a Blazor WebAssembly application that displays articles using a REST API. It implements features like state management, error handling, and a user-friendly UI.

---

## Features

- **List View**: Displays a list of articles with summaries.
- **Detail View**: Shows full details of a selected article.
- **State Management**: Manages application state for articles, loading, and error status.
- **Error Handling**: Displays meaningful messages for loading and network errors.

---

## API Endpoints

- **List Articles**: `GET https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles`
- **Article Details**: `GET https://ps-dev-1-partnergateway.patientsky.dev/assignment/articles/{id}`

---

### Setup Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/article-viewer.git
   cd article-viewer
