# IDCard Application

A Blazor WebAssembly application designed to generate ID card templates for university students. The application efficiently generates PDFs of ID card templates in batches for both staff and students. It is deployed offline, and can be deployed on various cloud platforms, including Azure.

## Features

- Dynamic ID card template generation for university students
- Batch PDF generation for staff and students' ID cards
- Seamless integration with SQL Server for data storage and management
- Limitation of uploading student CSV files using SQL Server Management Studio, with data to be provided from the application

## Installation

To get started with the IDCard Application, follow these steps:

1. Clone the repository to your local machine.

2. Navigate to the project directory.
   
3. Install the necessary dependencies.
4. install Sqlserver & sqlserver management studio
5. create an excell dummy data base on the Models
6. Run th Entity framework migration
7. upload the data to sqlserver db
   

9. Build the application.
   
10. Run the application.
   
## Deployment

The IDCard Application can be deployed offline or on a cloud platform like Azure. To deploy the application in Azure:

1. Log in to the Azure portal.
2. Create a new web app service.
3. Configure the deployment settings and upload the application files.
4. Configure the necessary environment variables.
5. Deploy the application.

For offline deployment, ensure you have the required runtime environment and dependencies installed.

## Technologies Used

- C#
- Blazor WebAssembly
- SQL Server
- PDF generation libraries (for example, iTextSharp or PdfSharp)
- Azure (optional)

## License


## Contributing

We welcome contributions from the community. To contribute to the project, please follow the guidelines outlined in [CONTRIBUTING.md](./CONTRIBUTING.md).

## Authors

- [Your Name](https://github.com/Danmanu44)

Feel free to reach out if you have any questions or suggestions.

## Acknowledgments



---

**Note:** This README template is a suggestion. Feel free to customize it according to your specific project requirements and details.


