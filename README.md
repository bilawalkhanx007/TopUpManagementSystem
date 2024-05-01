TopUpManagementSystem
Welcome to the TopUpManagementSystem repository! This project is built using .NET Core and follows best practices in software architecture and design. Below you'll find an overview of its features and implementation details.

Features
Fully Organized and Maintainable Code: The project is meticulously organized and structured for easy maintenance and scalability.
Entity Framework Core with Repository Pattern: Utilizes Entity Framework Core with a generic repository pattern for data access, promoting code reusability and maintainability.
Clean Onion Architecture with Domain-Driven Design (DDD): Follows a clean architecture approach with DDD principles, ensuring separation of concerns and business logic encapsulation.
CQRS Design Pattern with Mediator: Implements the Command Query Responsibility Segregation (CQRS) pattern along with Mediator for handling commands and queries separately, enhancing application performance and maintainability.
Error Logging: Logs errors into an external file for easy debugging and monitoring.
Swagger Documentation: Utilizes Swagger for API documentation, enabling easy exploration and testing of endpoints.
Fluent Validation: Implements Fluent Validation to handle incoming requests, ensuring data integrity and validation.
Global Exception Handling: Implements middleware for global exception handling, providing consistent error handling throughout the application.
Dependency Injection for Mapping: Utilizes dependency injection for mapping objects, promoting loose coupling and testability.
Follows SOLID Principles: Adheres to the SOLID principles for writing clean, maintainable, and extensible code.
User-specific Features:
Maximum 5 Active Top-Up Beneficiaries: Users can add up to 5 active top-up beneficiaries.
Nickname for Beneficiaries: Each top-up beneficiary must have a nickname with a maximum length of 20 characters.
View Available Top-Up Beneficiaries: Users can view available top-up beneficiaries.
View Available Top-Up Options: Users can view available top-up options: AED 5, AED 10, AED 20, AED 30, AED 50, AED 75, AED 100.
Maximum Top-Up Limits:
If a user is not verified, they can top up a maximum of AED 1,000 per calendar month per beneficiary.
If a user is verified, they can top up a maximum of AED 500 per calendar month per beneficiary.
The user can top up multiple beneficiaries but is limited to a total of AED 3,000 per month for all beneficiaries.
Transaction Charges: A charge of AED 1 is applied for every top-up transaction.
Balance Check and Debit: Users can only top up with an amount equal to or less than their balance retrieved from an external HTTP service. The balance should be debited first before the top-up transaction is attempted.
Getting Started
To get started with the TopUpManagementSystem, follow these steps:

Clone the repository: git clone https://github.com/your-username/TopUpManagementSystem.git
Open the solution in your preferred IDE.
Build the solution to restore dependencies: dotnet build
Run the application: dotnet run
Explore the API documentation using Swagger: https://localhost:{port}/swagger
Contributing
We welcome contributions to the TopUpManagementSystem project! To contribute:

Fork the repository.
Create a new branch: git checkout -b feature/my-feature
Make your changes and commit them: git commit -m 'Add some feature'
Push to the branch: git push origin feature/my-feature
Submit a pull request.
License
This project is licensed under the MIT License.

Acknowledgements
Special thanks to all contributors who have helped make this project possible.

This README now includes detailed information about the specific features related to top-up management, including user restrictions, transaction charges, and balance handling. Feel free to customize it further as needed!
