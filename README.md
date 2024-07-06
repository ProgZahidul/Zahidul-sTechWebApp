## Zahidul-sTechWebApp

Zahidul-sTechWebApp is a comprehensive e-commerce web application built using ASP.NET MVC Core. This application demonstrates the use of MVC architecture along with essential features such as authentication, authorization, and detailed management of orders, products, and categories. It provides a seamless shopping experience with functionalities like adding items to the cart, viewing product details, and managing user accounts.

### Features

- **MVC Core**: Implements the Model-View-Controller design pattern for a clean and maintainable codebase.
- **Authentication**: Secure user login and registration functionality.
- **Authorization**: Role-based access control to protect sensitive areas of the application.
- **Order Details**: View and manage order information.
- **Add to Cart**: Users can add products to their shopping cart for purchase.
- **Product Details**: Detailed view of individual products.
- **Category Management**: Organize products into categories for easier browsing.
- **Repository Pattern**: Abstracts the data layer, making the application more flexible and testable.
- **Unit of Work Pattern**: Manages database transactions to ensure data integrity and consistency.

### Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Bootstrap for responsive design
- jQuery for interactive elements

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/ProgZahidul/Zahidul-sTechWebApp.git
   cd Zahidul-sTechWebApp
   ```

2. Set up the database:

   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Apply migrations to create the database schema:

     ```bash
     dotnet ef database update
     ```

3. Run the application:

   ```bash
   dotnet run
   ```

4. Open your browser and navigate to `https://localhost:7112`.

### Project Structure

- **Controllers**: Handles user input and interactions, updating the model and returning views.
- **Models**: Represents the application's data and business logic.
- **Views**: Displays the user interface and renders the model data.
- **Repositories**: Contains repository classes that encapsulate data access logic.
- **UnitOfWork**: Manages transactions and coordinates the repositories.
- **wwwroot**: Contains static files like CSS, JavaScript, and images.
